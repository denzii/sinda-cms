#!/bin/bash
RED=$(tput setaf 1);
GREEN=$(tput setaf 2);
YELLOW=$(tput setaf 3);
NEUTRAL=$(tput sgr0);
PURPLE=$(tput setaf 5);

## FOR NOW: Duplicate these vars across all scripts
# How can they be passed around from a single source of truth safely?

GROUP_NAME="sinda-cms-grouptesttwo";
GROUP_EXISTS=$(az group exists -n $GROUP_NAME);
SERVICE_PLAN_NAME="sinda-cms-plantesttwo";
# IMPORTANT if you end up changing these, do not forget to also change the image for the sindacms inside docker-compose.yml file.
# How to keep them in sync without manual effort?
APP_NAME="sindacmstesttwo";
REGISTRY_NAME="sindatesttwo";
REGISTRY_URL="$REGISTRY_NAME.azurecr.io";
REGISTRY_URL_FULL="https://$REGISTRY_NAME.azurecr.io"
SOURCE_TAG="$APP_NAME"'app';
TARGET_TAG="$REGISTRY_URL/$SOURCE_TAG"':latest';
ACR_PASSWORD_PATH="./Secret/acrPassword.txt";

docker build --tag $SOURCE_TAG .
docker tag $SOURCE_TAG $TARGET_TAG

ACR_PASSWORD=$(az acr credential show --resource-group $GROUP_NAME --name $REGISTRY_NAME --query "passwords[0].value" --output tsv);
#Write the password into the txt file inside secrets, read from stdin at docker login (to get rid of the warning message)
echo "$ACR_PASSWORD" > $ACR_PASSWORD_PATH;
LOGIN_OUTPUT=$(docker login $REGISTRY_URL --username $REGISTRY_NAME --password-stdin < $ACR_PASSWORD_PATH);

if [ $? -eq 0 ] ; then
    printf "%40s\n" "${GREEN}$LOGIN_OUTPUT!${NEUTRAL}";
    printf "\n\n";
    
    printf "%40s\n" "${PURPLE}Attempting to do a deploy...${NEUTRAL}";
    docker push $TARGET_TAG
    if [ $? -eq 0 ] ; then
        printf "%40s\n" "${GREEN}Deploy was a success${NEUTRAL}";
        printf "\n\n";
    else
        printf "%40s\n" "${Red}Something went wrong with the deploy...${NEUTRAL}";
    fi
else
    printf "%40s\n" "${RED}Login to the docker / acr registry failed, won't be attempting a deploy... $LOGIN_OUTPUT ${NEUTRAL}";
fi