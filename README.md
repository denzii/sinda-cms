# sinda-cms
[![Build Status](https://dev.azure.com/sindagal/cms/_apis/build/status/denzii.sinda-cms?branchName=main)](https://dev.azure.com/sindagal/cms/_build/latest?definitionId=1&branchName=main)

To run the app locally:

1. cd into SindaCMS/client 
2. run npm start (will watch your files & push bundle in wwwroot folder. Works with .net6 hot reload)
3. double click on SindaCMS.sln in the root folder
4. run the application through Visual Studio

The app supports running through docker compose as well, just run it through docker in Visual Studio or Visual Studio Code (Through the docker plugin)


#TODOs
1. configure webpack to output css images with the same name or remove the bundle each time before creating new one with webpack --watch
2. configure webpack to detect entry points dynamically without specifying each file
