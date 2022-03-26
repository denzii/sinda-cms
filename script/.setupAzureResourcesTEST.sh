# #!/bin/bash

# # What does this script do?
# # 
# # How to run this script:
# # 1) cd into this repository's root directory
# # 2) chmod +x script/.setupAzureResources.sh && script/.setupAzureResources.sh

# RED=$(tput setaf 1);
# GREEN=$(tput setaf 2);
# YELLOW=$(tput setaf 3);
# NEUTRAL=$(tput sgr0);
# PURPLE=$(tput setaf 5);

# GROUP_NAME="sinda-cms-group";
# GROUP_EXISTS=$(az group exists -n $GROUP_NAME);
# SERVICE_PLAN_NAME="sinda-cms-plan";
# # IMPORTANT if you end up changing these, do not forget to also change the image for the sindacms inside docker-compose.yml file.
# APP_NAME="sindacms";
# REGISTRY_NAME="sinda";
# REGISTRY_URL="$REGISTRY_NAME.azurecr.io";
# REGISTRY_URL_FULL="https://$REGISTRY_NAME.azurecr.io"
# SOURCE_TAG="$APP_NAME"'app';
# TARGET_TAG="$REGISTRY_URL/$SOURCE_TAG"':latest';
# ACR_PASSWORD_PATH="./Secret/acrPassword.txt"

# printf "\n";

# # Build image locally
# printf "%40s\n" "${PURPLE}Attempting to build a local image with tag $SOURCE_TAG from the Dockerfile...${NEUTRAL}";
# docker build -t $SOURCE_TAG --file  Dockerfile .
# # in docs: docker build --tag appsvc-tutorial-custom-image .

# # Create resource group
# printf "\n";
# printf  "%40s\n" "${PURPLE}Checking Azure CLI Login status...${NEUTRAL}";

# if az account show > /dev/null 2>&1; then
#     printf "%40s\n" "${YELLOW}Azure account already logged in, skipping login step!${NEUTRAL}";
# else
#     printf "%40s\n" "${PURPLE}Executing azure login procedure...${NEUTRAL}";
#     az login;
#     printf "\n\n"
# fi

# printf "\n";
# printf "%40s\n" "${PURPLE}Attempting to create logical grouping for the azure resources to be created...${NEUTRAL}";
# az group create --name $GROUP_NAME --location westeurope;
# # in docs: az group create --name myResourceGroup --location westeurope

# # Push to container registry
# printf "\n";
# printf "%40s\n" "${PURPLE}Attempting to create a container registry for the repository...${NEUTRAL}";
# az acr create --name $REGISTRY_NAME --resource-group $GROUP_NAME --sku Basic --admin-enabled true
# # in docs: az acr create --name <registry-name> --resource-group myResourceGroup --sku Basic --admin-enabled true
# printf "\n\n";

# ACR_PASSWORD=$(az acr credential show --resource-group $GROUP_NAME --name $REGISTRY_NAME --query "passwords[0].value" --output tsv);
# # not documented
# echo "$ACR_PASSWORD" > $ACR_PASSWORD_PATH;

# printf "%40s\n" "${PURPLE}Logging into the registry at: $REGISTRY_URL ...${NEUTRAL}";
# docker login $REGISTRY_URL --username $REGISTRY_NAME --password-stdin < $ACR_PASSWORD_PATH
# # in docs:  docker login <registry-name>.azurecr.io --username <registry-username>
# printf "\n\n"

# printf "%40s\n" "${PURPLE}Attempting to tag the previously built image: $SOURCE_TAG with: $TARGET_TAG ...${NEUTRAL}";
# docker tag $SOURCE_TAG $TARGET_TAG
# # in docs:  docker tag appsvc-tutorial-custom-image <registry-name>.azurecr.io/appsvc-tutorial-custom-image:latest
# if [ $? -eq 0 ] ; then
#     printf "%40s\n" "${GREEN}Image had been tagged successfully!${NEUTRAL}";
# else
#     printf "%40s\n" "${RED}Something went wrong while tagging the image...${NEUTRAL}";
# fi
# printf "\n\n"

# printf "%40s\n" "${PURPLE}Attempting to push the image to ACR...${NEUTRAL}";
# docker push $TARGET_TAG
# # in docs: docker push <registry-name>.azurecr.io/appsvc-tutorial-custom-image:latest
# printf "\n\n"

# # Configure App service
# printf "%40s\n" "${PURPLE}Attempting to create a service plan for the repository...${NEUTRAL}";
# az appservice plan create --name $SERVICE_PLAN_NAME --resource-group $GROUP_NAME --is-linux;
# # in docs: az appservice plan create --name myAppServicePlan --resource-group myResourceGroup --is-linux
# printf "\n\n"

# printf "%40s\n" "${PURPLE}Attempting to create multicontainer webapp for this repository...${NEUTRAL}";
# az webapp create --resource-group $GROUP_NAME --plan $SERVICE_PLAN_NAME --name $APP_NAME --multicontainer-config-type compose --multicontainer-config-file docker-compose.yml;
# # in docs: az webapp create --resource-group myResourceGroup --plan myAppServicePlan --name <app-name> --deployment-container-image-name <registry-name>.azurecr.io/appsvc-tutorial-custom-image:latest
# printf "\n\n"

# printf "%40s\n" "${PURPLE}Attempting to set the required env vars on webapp appsettings...${NEUTRAL}";
# printf "%40s\n" "${PURPLE}Setting ACR Password fetched from Azure...${NEUTRAL}";
# az webapp config appsettings set --name $APP_NAME --resource-group $GROUP_NAME --settings DOCKER_REGISTRY_SERVER_PASSWORD=$ACR_PASSWORD > /dev/null 2>&1;

# printf "%40s\n" "${PURPLE}Setting Registry server username to: $REGISTRY_NAME ...${NEUTRAL}";
# az webapp config appsettings set --name $APP_NAME --resource-group $GROUP_NAME --settings DOCKER_REGISTRY_SERVER_USERNAME=$REGISTRY_NAME > /dev/null 2>&1;

# printf "%40s\n" "${PURPLE}Setting Registry server url to: $REGISTRY_URL_FULL ...${NEUTRAL}";
# az webapp config appsettings set --name $APP_NAME --resource-group $GROUP_NAME --settings DOCKER_REGISTRY_SERVER_URL=$REGISTRY_URL_FULL; 
# # in docs: az webapp config appsettings set --resource-group myResourceGroup --name <app-name> --settings WEBSITES_PORT=8000
# printf "\n\n"

# SUBSCRIPTION_ID=$(az account show --query id --output tsv);
# # in docs: az account show --query id --output tsv


# printf "%40s\n" "${PURPLE}Attempting to turn managed identity on in the webapp...${NEUTRAL}";
# az resource update --ids /subscriptions/$SUBSCRIPTION_ID/resourceGroups/$GROUP_NAME/providers/Microsoft.Web/sites/$APP_NAME/config/web --set properties.acrUseManagedIdentityCreds=True
# # in docs: az resource update --ids /subscriptions/<subscription-id>/resourceGroups/myResourceGroup/providers/Microsoft.Web/sites/<app-name>/config/web --set properties.acrUseManagedIdentityCreds=True
# printf "\n\n"

# PRINCIPAL_ID=$(az webapp identity assign --resource-group $GROUP_NAME --name $APP_NAME --query principalId --output tsv);
# # in docs: az webapp identity assign --resource-group myResourceGroup --name <app-name> --query principalId --output tsv

# printf "%40s\n" "${PURPLE}Attempting to assign the AcrPull role to the webapp...${NEUTRAL}";

# az role assignment create --assignee $PRINCIPAL_ID --scope /subscriptions/$SUBSCRIPTION_ID/resourceGroups/$GROUP_NAME/providers/Microsoft.ContainerRegistry/registries/$REGISTRY_NAME --role "AcrPull"
# if [ $? -eq 0 ] ; then
#     printf "%40s\n" "${YELLOW}Pull Role assignment yielded an error, this will be reattempted at the end of the procedure!${NEUTRAL}";
#     ROLE_ASSIGNMENT_SUCCESS=false
# fi

# printf "%40s\n" "${YELLOW}If you are seeing an error message here printed in red, please run this command after the whole procedure ends:${NEUTRAL}";
# printf "$ az role assignment create --assignee $PRINCIPAL_ID --scope /subscriptions/$SUBSCRIPTION_ID/resourceGroups/$GROUP_NAME/providers/Microsoft.ContainerRegistry/registries/$REGISTRY_NAME --role \"AcrPull\""
# # in docs: az role assignment create --assignee <principal-id> --scope /subscriptions/<subscription-id>/resourceGroups/myResourceGroup/providers/Microsoft.ContainerRegistry/registries/<registry-name> --role "AcrPull"
# printf "\n\n"

# printf "%40s\n" "${PURPLE}Attempting to do an initial multicontainer deploy for the repository...${NEUTRAL}";
# az webapp config container set \
# --name $APP_NAME \
# --resource-group $GROUP_NAME \
# --docker-custom-image-name $TARGET_TAG \
# --docker-registry-server-url $REGISTRY_URL_FULL \
# --docker-registry-server-password $ACR_PASSWORD \
# --docker-registry-server-user $REGISTRY_NAME \
# --multicontainer-config-file docker-compose.yml \
# --multicontainer-config-type compose
# # in docs: az webapp config container set --name <app-name> --resource-group myResourceGroup --docker-custom-image-name <registry-name>.azurecr.io/appsvc-tutorial-custom-image:latest --docker-registry-server-url https://<registry-name>.azurecr.io
# printf "\n\n"

# printf "%40s\n" "${PURPLE}Attempting to clean up the pushed images from the local machine...${NEUTRAL}";
# docker rmi $SOURCE_TAG
# docker rmi $TARGET_TAG

# if [ "$ROLE_ASSIGNMENT_SUCCESS" = false ] ; then
#     printf "%40s\n" "${PURPLE}Re-attempting AcrPull role assignment to the webapp...${NEUTRAL}";
#     az role assignment create --assignee $PRINCIPAL_ID --scope /subscriptions/$SUBSCRIPTION_ID/resourceGroups/$GROUP_NAME/providers/Microsoft.ContainerRegistry/registries/$REGISTRY_NAME --role "AcrPull"
# fi

# printf "%40s\n" "${GREEN}Setup of Azure Resources procedure has finished execution, if everything went okay, the initial deploy should now be available live...${NEUTRAL}";
# printf "\n"



# # first attempt at this was: 

# # #!/bin/bash
# # RED=$(tput setaf 1);
# # GREEN=$(tput setaf 2);
# # YELLOW=$(tput setaf 3);
# # NEUTRAL=$(tput sgr0);

# # GROUP_NAME="sinda-cms-slntest";
# # GROUP_EXISTS=$(az group exists -n $GROUP_NAME | tail -c 23);
# # SERVICE_PLAN_NAME="sinda-cms-plantest";
# # APP_NAME="sindagalcmstest";
# # REGISTRY_NAME="sindaregtest";
# # ACR_PASSWORD=$(cat ./Secret/acrPassword.txt | tail -c 23);
# # REGISTRY_URL="$REGISTRY_NAME.azurecr.io";
# # SOURCE_TAG="$APP_NAME"':app';
# # TARGET_TAG="$REGISTRY_URL/$APP_NAME"':latest';


# # printf "\n\n";
# # printf "Checking Azure CLI Login status...\n";

# # if az account show > /dev/null 2>&1; then
# #     printf "%40s\n" "${YELLOW}Azure account already logged in, skipping login step!${NEUTRAL}";
# # else
# #     printf "Executing azure login procedure...\n\n";
# #     az login;
# # fi

# # printf "Checking if the resource group for the repository exists...\n";


# # if $GROUP_EXISTS; then
# #     printf "%40s\n" "${YELLOW}Resource group exists, skipping its creation!${NEUTRAL}";
# # else
# #     printf "Attempting to create logical grouping for the azure resources to be created...";
# #     az group create --name $GROUP_NAME --location westeurope;
# # fi


# # printf "Checking if the appservice plan for the repository exists...\n";

# # az appservice plan show --name $SERVICE_PLAN_NAME --resource-group $GROUP_NAME > /dev/null 2>&1;

# # if [ $? -eq 0 ] ; then
# #     printf "%40s\n" "${YELLOW}Service Plan already exists, skipping its creation step!${NEUTRAL}";
# # else
# #     printf "Attempting to create a service plan for the repository...\n\n";
# #     az appservice plan create --name $SERVICE_PLAN_NAME --resource-group $GROUP_NAME --is-linux;
# # fi

# # APP_EXISTS_OUTPUT=$(az webapp list --resource-group $GROUP_NAME | grep $APP_NAME);

# # printf "Checking if the webapp for the repository exists...\n";

# # if [ -z "$APP_EXISTS_OUTPUT" ]; then
# #     printf "Attempting to create multicontainer webapp for this repository...\n\n";
# #     az webapp create --resource-group $GROUP_NAME --plan $SERVICE_PLAN_NAME --name $APP_NAME --multicontainer-config-type compose --multicontainer-config-file docker-compose.yml;
# # else
# #     printf "%40s\n" "${YELLOW}Webapp for this repository already exists, skipping its creation step!${NEUTRAL}";
# # fi

# # printf "Checking if the container registry for the repository exists...\n";
# # az acr show --name $REGISTRY_NAME > /dev/null 2>&1;

# # if [ $? -eq 0 ] ; then
# #     printf "%40s\n" "${YELLOW}Registry already exists, skipping its creation step!${NEUTRAL}";
# # else
# #     printf "Attempting to create a container registry for the repository...\n\n";
# #     az acr create --resource-group $GROUP_NAME --name $REGISTRY_NAME --sku Basic
# # fi
# #     printf "Attempting to enable admin for ACR...\n\n";

# #     az acr update -n $REGISTRY_NAME --admin-enabled true
# #     printf "%40s\n" "${YELLOW}Webapp & container registry had been configured but a system managed Identity must be enabled on the webapp & given an acrPull role MANUALLY!${NEUTRAL}";

# #     printf "%40s\n" "${YELLOW}Then onto: AppService => MyApp => Identity => Role Assignments => Add  Role Assignment ...${NEUTRAL}";
# #     printf "%40s\n" "${YELLOW}And finally: Container registry => Access Keys => Admin User Enabled... And copy one of the passwords into /Secret/acrPassword.txt ${NEUTRAL}";

# #     read "response?Confirmed the above & continue? [Y/n] "
# #     response=${response:l} #tolower
# #     if [[ $response =~ ^(yes|y| ) ]] || [[ -z $response ]]; then
# #         printf "Setting required env variables onto the webapp...\n";
# #         #only show the outs with the last call of this command to avoid dupe cmd outputs
# #         az webapp config appsettings set --name $APP_NAME --resource-group $GROUP_NAME --settings DOCKER_REGISTRY_SERVER_PASSWORD=$ACR_PASSWORD > /dev/null 2>&1;
# #         az webapp config appsettings set --name $APP_NAME --resource-group $GROUP_NAME --settings DOCKER_REGISTRY_SERVER_USERNAME=$APP_NAME > /dev/null 2>&1;
# #         az webapp config appsettings set --name $APP_NAME --resource-group $GROUP_NAME --settings DOCKER_REGISTRY_SERVER_URL=$REGISTRY_URL; 

# #         printf "Logging into the registry at: $REGISTRY_URL ...\n";
# #         # az acr login --name $REGISTRY_NAME --username $APP_NAME --password $ACR_PASSWORD
# #         docker login $REGISTRY_URL --username $REGISTRY_NAME --password-stdin < ./Secret/acrPassword.txt
# #         if [ $? -eq 0 ] ; then
# #             printf "%40s\n" "${GREEN}Image pushed, Location: $TARGET_TAG !${NEUTRAL}";
# #             printf "Attempting to build & tag a local image for the repository from the Dockerfile at root...";
# #             docker build -t $SOURCE_TAG --file  Dockerfile .

# #             if [ $? -eq 0 ] ; then
# #                 printf "%40s\n" "${GREEN}Image had been built, tagging it with $TARGET_TAG ...${NEUTRAL}";
# #                 docker tag $SOURCE_TAG $TARGET_TAG
# #                 if [ $? -eq 0 ] ; then
# #                 printf "%40s\n" "${GREEN}Image had been tagged!${NEUTRAL}";
# #                 else
# #                     printf "%40s\n" "${RED}Something went wrong while tagging the image...${NEUTRAL}";
# #                 fi
# #             else
# #                 printf "%40s\n" "${RED}Something went wrong while building the image...${NEUTRAL}";
# #             fi

# #             printf "Attempting to push the image to ACR...";
# #             docker push $TARGET_TAG

# #             if [ $? -eq 0 ] ; then
# #                 printf "%40s\n" "${GREEN}Image pushed, Location: $TARGET_TAG !${NEUTRAL}";
# #             else
# #                 printf  "%40s\n" "${RED}Something went wrong while pushing the image to $REGISTRY_URL ...${NEUTRAL}";
# #             fi

# #             printf "Attempting to clean up the pushed image from the local machine...";
# #             docker rmi $SOURCE_TAG
# #             docker rmi $TARGET_TAG

# #             printf "%40s\n" "${GREEN}Setup of Azure Resources procedure has finished execution, if everything went okay, the initial deploy should now be available live...${NEUTRAL}";
# #         else
# #             printf  "%40s\n" "${RED}Something went wrong while trying docker login, likely causes:${NEUTRAL}";
# #             printf  "%40s\n" "${RED} 1- Password may not be present or invalid in /Secret/acrPassword.txt${NEUTRAL}";
# #             printf  "%40s\n" "${RED} 2- Admin user may not be enabled on the Container Registry.${NEUTRAL}";

# #             printf  "%40s\n" "${RED} Please ensure they are okay and run the script again...${NEUTRAL}";
# #         fi 
# #     fi