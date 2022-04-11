# Sinda Knowledge Base (MVP)
[![Build Status](https://dev.azure.com/sindagal/cms/_apis/build/status/denzii.sinda-cms?branchName=main)](https://dev.azure.com/sindagal/cms/_build/latest?definitionId=1&branchName=main)
![License](https://img.shields.io/badge/License-MIT-green)
![Language Count](https://img.shields.io/github/languages/count/denzii/sinda-cms)


This repository contains the code for a Web App used for demonstrating, documenting & standardizing **Sindagal Open Source**. 
## About Sindagal Open Source
Sindagal (sinda) is a toolset aiming to make developer life more convenient by:

* Organizing manual tasks into scripts so ideally, no steps are followed from any documentation more than once
* Organizing boilerplate code so ideally nothing is written twice
* Providing reusability & sharability across everything done by an individual or organisation

## Demo & Documentation

A live version could be found at https://sindagal.org

Kubernetes URL at https://sinda.vektio.com/ ( Meant to be only for playing around and not for production)

## Features
- Dynamic page content created using data fetched from DB (Except landing page)
- SQL Abstraction with Code first Migrations
- Containerized localhost development environment through Docker Compose 
- Automated production environment setup through Bash & Azure CLI
- Ability to debug through containers in both Visual Studio on Windows & Visual Studio Code on other operating systems
- CI/CD through Azure Devops
- Automations for Azure CLI setup through Bash
- Responsive Design (Best experience on desktop & mobile as a fallback)
## Authors

- Development, Devops & Automations by [@denzii](https://github.com/denzii)
- Bare metal Kubernetes Infrastructure for playing around by [@hushoca](https://github.com/hushoca)

## Contributing

Contributions as well as feedback are always welcome! Feel free to fork this repository, submit pull requests, open issues or contact me directly at my 
[Linkedin](https://www.linkedin.com/in/denizarca/) if there are any problems with the code or the documentation.
## Roadmap
- UI tweaks for usability on mobile, Colour Contrast Adjustments & Typography improvements
- Full refactor the codebase
- Security fixes such as factoring DB Credentials out of Docker Compose
- Upload/Download/Consume images from CDN
- Provide automation for Azure Devops CLI Setup
- Automate all Devops infrastructure resource creation & configure them with Azure App Service through Azure CLI & Bash
- CI Pipeline for Helm
- Provide a Restful API & Repository for editing site content while the app is deployed & running 
- Provide a Client Side Rendered Content Editor UI Using ReactJS (Webpack already configured to support JSX/TSX)
## Tech Stack

**Client:** Webpack, TypesScript, HTML5, SASS (CSS3)

**Server:** C#, Razor Pages, Entity Framework Core (MSSQL)

**Platform:** Docker, Docker Compose, Bash, Azure CLI

**Infra:** Azure Devops, Azure App Service, Azure Container Registry
