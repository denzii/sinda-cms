#!/bin/bash

# THE BELOW CODE IS DUPLICATED FROM the automation scripts in the CLI repo @https://github.com/denzii/sinda-cli/blob/main/src/script/index.sh
# TODO: Pull all scripts to their own virtualization layer in the future to share between repos?? (open to suggestions)
# commands put together from
# https://docs.microsoft.com/en-us/cli/azure/install-azure-cli-linux?pivots=apt

# Get packages needed for install
sudo apt-get update
sudo apt-get install ca-certificates curl apt-transport-https lsb-release gnupg

# Download and install the Microsoft signing key
curl -sL https://packages.microsoft.com/keys/microsoft.asc |
    gpg --dearmor |
    sudo tee /etc/apt/trusted.gpg.d/microsoft.gpg > /dev/null

# Add the Azure CLI software repository
AZ_REPO=$(lsb_release -cs)
echo "deb [arch=amd64] https://packages.microsoft.com/repos/azure-cli/ $AZ_REPO main" |
    sudo tee /etc/apt/sources.list.d/azure-cli.list

# Update repository information and install the azure-cli package
sudo apt-get update
sudo apt-get install azure-cli

# install jmespath terminal for better querying with the --query parameter
sudo wget https://github.com/jmespath/jp/releases/latest/download/jp-linux-amd64 \
  -O /usr/local/bin/jp  && sudo chmod +x /usr/local/bin/jp  

# add the azure devops extension
az extension add --name azure-devops

# add graph api for better querying
az extension add --name resource-graph