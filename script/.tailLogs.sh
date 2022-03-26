#!/bin/bash

# TODO Find a way to share the vars across
GROUP_NAME="sinda-cms-groupt";
APP_NAME="sindacmst";

az webapp log tail --name $APP_NAME --resource-group $GROUP_NAME
