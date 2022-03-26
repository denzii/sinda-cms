#!/bin/bash

# What does this script do?
# Creates all the required resources on azure to allow deploying the repository on a multicontainer app service instance.

# How to run this script?
# 1) cd into this repository's root directory
# 2) Modify the variables at the top of the script to point to the resource names as you wish
# 2) chmod +x script/.setupAzureResources.sh && script/.setupAzureResources.sh

# Main Steps involved:
# 1)  Build & Tag Docker Image
# 2)  Login to Azure CLI if not logged in
# 3)  Create a resource group for this solution
# 4)  Create a container registry and configure it's admin access
# 5)  Get Admin pass and login to the registry using docker
# 6)  Push tagged local image to repository
# 7)  Create a service plan 
# 8)  Create an Azure App Service Webapp with initial configuration (Multicontainer)
# 9)  Set environment variables on the created webapp so it can communicate with the container registry
# 10) Turn system managed identity on for the webapp & assign the ACR Pull role to it so it can pull from the container registry
# 11) Attempt an initial deploy
# 12) Enable logging on the deployed containers
# 13) Enable CD on the containers by setting a webhook
# 14) Clear local resources which are left as a side effect of the procedure
# 15) Re attempt some of the known problematic commands if they had failed

RED=$(tput setaf 1);
GREEN=$(tput setaf 2);
YELLOW=$(tput setaf 3);
NEUTRAL=$(tput sgr0);
PURPLE=$(tput setaf 5);

GROUP_NAME="sinda-cms-grouptesttwo";
GROUP_EXISTS=$(az group exists -n $GROUP_NAME);
SERVICE_PLAN_NAME="sinda-cms-plantesttwo";
# IMPORTANT if you end up changing these, do not forget to also change the image for the sindacms inside docker-compose.yml file.
# How to keep them in sync without manual effort?
APP_NAME="sindacms";
REGISTRY_NAME="sinda";
REGISTRY_URL="$REGISTRY_NAME.azurecr.io";
REGISTRY_URL_FULL="https://$REGISTRY_NAME.azurecr.io"
SOURCE_TAG="$APP_NAME"'app';
TARGET_TAG="$REGISTRY_URL/$SOURCE_TAG"':latest';
ACR_PASSWORD_PATH="./Secret/acrPassword.txt"

printf "\n";

# Build image locally
printf "%40s\n" "${PURPLE}Attempting to build a local image with tag $SOURCE_TAG from the Dockerfile...${NEUTRAL}";
docker build -t $SOURCE_TAG --file  Dockerfile .

# Create resource group
printf "\n";
printf  "%40s\n" "${PURPLE}Checking Azure CLI Login status...${NEUTRAL}";

if az account show > /dev/null 2>&1; then
    printf "%40s\n" "${YELLOW}Azure account already logged in, skipping login step!${NEUTRAL}";
else
    printf "%40s\n" "${PURPLE}Executing azure login procedure...${NEUTRAL}";
    az login;
    printf "\n\n"
fi

printf "\n";
printf "%40s\n" "${PURPLE}Attempting to create logical grouping for the azure resources to be created...${NEUTRAL}";
az group create --name $GROUP_NAME --location westeurope;

# Push to container registry
printf "\n";
printf "%40s\n" "${PURPLE}Attempting to create a container registry for the repository...${NEUTRAL}";
az acr create --name $REGISTRY_NAME --resource-group $GROUP_NAME --sku Basic --admin-enabled true
printf "\n\n";

ACR_PASSWORD=$(az acr credential show --resource-group $GROUP_NAME --name $REGISTRY_NAME --query "passwords[0].value" --output tsv);
#Write the password into the txt file inside secrets, read from stdin at docker login (to get rid of the warning message)
echo "$ACR_PASSWORD" > $ACR_PASSWORD_PATH;

printf "%40s\n" "${PURPLE}Logging into the registry at: $REGISTRY_URL ...${NEUTRAL}";
LOGIN_OUTPUT=$(docker login $REGISTRY_URL --username $REGISTRY_NAME --password-stdin < $ACR_PASSWORD_PATH);

if [ $? -eq 0 ] ; then
    printf "%40s\n" "${GREEN}$LOGIN_OUTPUT!${NEUTRAL}";
    printf "\n\n";

    printf "%40s\n" "${PURPLE}Attempting to tag the previously built image: $SOURCE_TAG with: $TARGET_TAG ...${NEUTRAL}";
    docker tag $SOURCE_TAG $TARGET_TAG

    if [ $? -eq 0 ] ; then
        printf "%40s\n" "${GREEN}Image had been tagged successfully!${NEUTRAL}";
    else
        printf "%40s\n" "${RED}Something went wrong while tagging the image...${NEUTRAL}";
    fi
    printf "\n\n"

    printf "%40s\n" "${PURPLE}Attempting to push the image to ACR...${NEUTRAL}";
    docker push $TARGET_TAG

    printf "\n\n"

    # Configure App service
    printf "%40s\n" "${PURPLE}Attempting to create a service plan for the repository...${NEUTRAL}";
    az appservice plan create --name $SERVICE_PLAN_NAME --resource-group $GROUP_NAME --is-linux;
    printf "\n\n"

    printf "%40s\n" "${PURPLE}Attempting to create multicontainer webapp for this repository...${NEUTRAL}";
    az webapp create --resource-group $GROUP_NAME --plan $SERVICE_PLAN_NAME --name $APP_NAME --multicontainer-config-type compose --multicontainer-config-file docker-compose.yml;
    printf "\n\n"

    printf "%40s\n" "${PURPLE}Attempting to set the required env vars on webapp appsettings...${NEUTRAL}";
    printf "%40s\n" "${PURPLE}Setting ACR Password fetched from Azure...${NEUTRAL}";
    az webapp config appsettings set --name $APP_NAME --resource-group $GROUP_NAME --settings DOCKER_REGISTRY_SERVER_PASSWORD=$ACR_PASSWORD > /dev/null 2>&1;

    printf "%40s\n" "${PURPLE}Setting Registry server username to: $REGISTRY_NAME ...${NEUTRAL}";
    az webapp config appsettings set --name $APP_NAME --resource-group $GROUP_NAME --settings DOCKER_REGISTRY_SERVER_USERNAME=$REGISTRY_NAME > /dev/null 2>&1;

    printf "%40s\n" "${PURPLE}Setting Registry server url to: $REGISTRY_URL_FULL ...${NEUTRAL}";
    az webapp config appsettings set --name $APP_NAME --resource-group $GROUP_NAME --settings DOCKER_REGISTRY_SERVER_URL=$REGISTRY_URL_FULL; 
    printf "\n\n"

    SUBSCRIPTION_ID=$(az account show --query id --output tsv);

    printf "%40s\n" "${PURPLE}Attempting to turn managed identity on in the webapp...${NEUTRAL}";
    az resource update --ids /subscriptions/$SUBSCRIPTION_ID/resourceGroups/$GROUP_NAME/providers/Microsoft.Web/sites/$APP_NAME/config/web --set properties.acrUseManagedIdentityCreds=True
    printf "\n\n"

    PRINCIPAL_ID=$(az webapp identity assign --resource-group $GROUP_NAME --name $APP_NAME --query principalId --output tsv);

    printf "%40s\n" "${PURPLE}Attempting to assign the AcrPull role to the webapp...${NEUTRAL}";

    az role assignment create --assignee $PRINCIPAL_ID --scope /subscriptions/$SUBSCRIPTION_ID/resourceGroups/$GROUP_NAME/providers/Microsoft.ContainerRegistry/registries/$REGISTRY_NAME --role "AcrPull"
    if [ $? -ne 0 ] ; then
        printf "%40s\n" "${YELLOW}Pull Role assignment yielded an error, this will be re-attempted at the end of the procedure!${NEUTRAL}";
        ROLE_ASSIGNMENT_SUCCESS=false
    else
        ROLE_ASSIGNMENT_SUCCESS=true
    fi
    printf "\n\n"

    # Initial Deploy
    printf "%40s\n" "${PURPLE}Attempting to do an initial multicontainer deploy for the repository...${NEUTRAL}";
    az webapp config container set \
    --name $APP_NAME \
    --resource-group $GROUP_NAME \
    --docker-custom-image-name $TARGET_TAG \
    --docker-registry-server-url $REGISTRY_URL_FULL \
    --docker-registry-server-password $ACR_PASSWORD \
    --docker-registry-server-user $REGISTRY_NAME \
    --multicontainer-config-file docker-compose.yml \
    --multicontainer-config-type compose
    printf "\n\n"

    # Enable Logging on containers
    az webapp log config --name $APP_NAME --resource-group $GROUP_NAME --docker-container-logging filesystem
    # Local Resource Cleanup 
    printf "%40s\n" "${PURPLE}Attempting to clean up the pushed images from the local machine...${NEUTRAL}";
    docker rmi $SOURCE_TAG
    docker rmi $TARGET_TAG

    # Rerun select failed commands
    if [ "$ROLE_ASSIGNMENT_SUCCESS" = false ] ; then
        printf "\n\n"
        printf "%40s\n" "${PURPLE}Re-attempting AcrPull role assignment to the webapp...${NEUTRAL}";
        az role assignment create --assignee $PRINCIPAL_ID --scope /subscriptions/$SUBSCRIPTION_ID/resourceGroups/$GROUP_NAME/providers/Microsoft.ContainerRegistry/registries/$REGISTRY_NAME --role "AcrPull"
        if [ $? -ne 0 ] ; then
            printf "\n\n"
            printf "%40s\n" "${RED}Failed to assign Pull role once more, please run the following command manually and restart the app on the Azure UI if needed:${NEUTRAL}";
            printf "%40s\n" "${YELLOW}az role assignment create --assignee $PRINCIPAL_ID --scope /subscriptions/$SUBSCRIPTION_ID/resourceGroups/$GROUP_NAME/providers/Microsoft.ContainerRegistry/registries/$REGISTRY_NAME --role \"AcrPull\":${NEUTRAL}";
        fi
    fi



    # # Enable CI/CD 
    # printf "\n\n";
    # printf "%40s\n" "${PURPLE}Attempting to enable webhook for continuous deployment ...${NEUTRAL}";
    # CI_CD_URL=$(az webapp deployment container config --enable-cd true --name $APP_NAME --resource-group $GROUP_NAME --query CI_CD_URL --output tsv);
    # az acr webhook create --name appserviceCD --registry $REGISTRY_NAME --uri $CI_CD_URL --actions push --scope $TARGET_TAG
    
    # EVENT_ID=$(az acr webhook ping --name appserviceCD --registry $REGISTRY_NAME --query id --output tsv);
    
    # # first sed removes the [] characters
    # # second removes the " char at the end
    # # third removes the " char at the beginning
    # # xargs trims all white space
    # WH_PING_STATUS_CODE=$(az acr webhook list-events --name appserviceCD --registry $REGISTRY_NAME --query "[?id=='$EVENT_ID'].eventResponseMessage.statusCode" \
    # | sed 's/^.//' \
    # | sed 's/^.//;s/.$//' \
    # | sed 's/^.//' \
    # | xargs);
    
    # if [ "$WH_PING_STATUS_CODE" -eq "200" ] ; then
    #         printf "%40s\n" "${GREEN}Continuous Deployment had been registered successfully. Whenever the image on the registry gets updated, App service will know about it...${NEUTRAL}";
    # else
    #         printf "%40s\n" "${RED}Continuous Deployment could not be set at this time for some reason...${NEUTRAL}";
    # fi

    # Say goodbye
    printf "\n\n"
    printf "%40s\n" "${GREEN}Setup of Azure Resources procedure has finished execution, if everything went okay, the initial deploy should be available live in a few moments...${NEUTRAL}";
    printf "If you wish to tail the logs to watch the containers while they start up, run the following command:\n"
    printf "az webapp log tail --name $APP_NAME --resource-group $GROUP_NAME";
    printf "\n\n"
else
    printf "%40s\n" "${RED}Login to the docker / acr registry failed, won't be executing the rest of the script... $LOGIN_OUTPUT ${NEUTRAL}";
fi

printf "\n\n"
