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

# GROUP_NAME="sinda-cms-groupt";
# GROUP_EXISTS=$(az group exists -n $GROUP_NAME);
# SERVICE_PLAN_NAME="sinda-cms-plant";
# # IMPORTANT if you end up changing these, do not forget to also change the image for the sindacms inside docker-compose.yml file.
# APP_NAME="sindacmst";
# REGISTRY_NAME="sindat";
# REGISTRY_URL="$REGISTRY_NAME.azurecr.io";
# REGISTRY_URL_FULL="https://$REGISTRY_NAME.azurecr.io"
# SOURCE_TAG="$APP_NAME"'app';
# TARGET_TAG="$REGISTRY_URL/$SOURCE_TAG"':latest';
# ACR_PASSWORD_PATH="./Secret/acrPassword.txt"

# printf "\n";

# docker build -t $SOURCE_TAG --file  Dockerfile .
# az group create --name $GROUP_NAME --location westeurope;
# az group create --name myResourceGroup --location westeurope
# az acr create --name $REGISTRY_NAME --resource-group $GROUP_NAME --sku Basic --admin-enabled true
# ACR_PASSWORD=$(az acr credential show --resource-group $GROUP_NAME --name $REGISTRY_NAME --query "passwords[0].value" --output tsv);
# echo "$ACR_PASSWORD" > $ACR_PASSWORD_PATH;
# docker login $REGISTRY_URL --username $REGISTRY_NAME --password-stdin < $ACR_PASSWORD_PATH
# docker tag $SOURCE_TAG $TARGET_TAG
# docker push $TARGET_TAG
# az appservice plan create --name $SERVICE_PLAN_NAME --resource-group $GROUP_NAME --is-linux;
# az webapp create --resource-group $GROUP_NAME --plan $SERVICE_PLAN_NAME --name $APP_NAME --multicontainer-config-type compose --multicontainer-config-file docker-compose.yml;

# az webapp config appsettings set --name $APP_NAME --resource-group $GROUP_NAME --settings DOCKER_REGISTRY_SERVER_PASSWORD=$ACR_PASSWORD > /dev/null 2>&1;
# az webapp config appsettings set --name $APP_NAME --resource-group $GROUP_NAME --settings DOCKER_REGISTRY_SERVER_USERNAME=$REGISTRY_NAME > /dev/null 2>&1;
# az webapp config appsettings set --name $APP_NAME --resource-group $GROUP_NAME --settings DOCKER_REGISTRY_SERVER_URL=$REGISTRY_URL_FULL; 

# az webapp identity assign --resource-group myResourceGroup --name <app-name> --query principalId --output tsv
# az account show --query id --output tsv
# az role assignment create --assignee <principal-id> --scope /subscriptions/<subscription-id>/resourceGroups/myResourceGroup/providers/Microsoft.ContainerRegistry/registries/<registry-name> --role "AcrPull"
# az resource update --ids /subscriptions/<subscription-id>/resourceGroups/myResourceGroup/providers/Microsoft.Web/sites/<app-name>/config/web --set properties.acrUseManagedIdentityCreds=True
# az webapp config container set --name <app-name> --resource-group myResourceGroup --docker-custom-image-name <registry-name>.azurecr.io/appsvc-tutorial-custom-image:latest --docker-registry-server-url https://<registry-name>.azurecr.io
