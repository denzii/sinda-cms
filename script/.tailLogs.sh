#!/bin/bash

# TODO Find a way to share the vars across
GROUP_NAME="sinda-cms-group";
APP_NAME="sindacms";

az webapp log tail --name $APP_NAME --resource-group $GROUP_NAME
