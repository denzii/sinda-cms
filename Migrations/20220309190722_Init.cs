using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SindaCMS.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    BrandName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BrandDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.BrandName);
                });

            migrationBuilder.CreateTable(
                name: "PageDetail",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SiteBrandName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageDetail", x => x.Name);
                    table.ForeignKey(
                        name: "FK_PageDetail_Sites_SiteBrandName",
                        column: x => x.SiteBrandName,
                        principalTable: "Sites",
                        principalColumn: "BrandName");
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    PageDetailName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.PageDetailName);
                    table.ForeignKey(
                        name: "FK_Pages_PageDetail_PageDetailName",
                        column: x => x.PageDetailName,
                        principalTable: "PageDetail",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tab",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PageName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tab", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Tab_Pages_PageName",
                        column: x => x.PageName,
                        principalTable: "Pages",
                        principalColumn: "PageDetailName");
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TabName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PageName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Header = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasMainContent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => new { x.Id, x.TabName, x.PageName });
                    table.UniqueConstraint("AK_Section_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Section_Pages_PageName",
                        column: x => x.PageName,
                        principalTable: "Pages",
                        principalColumn: "PageDetailName");
                    table.ForeignKey(
                        name: "FK_Section_Tab_TabName",
                        column: x => x.TabName,
                        principalTable: "Tab",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "Detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SectionKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectionId = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detail_Section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Section",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HTMLContent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DetailId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    content_type = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Srcset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Media = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HTMLContent", x => new { x.Id, x.DetailId });
                    table.ForeignKey(
                        name: "FK_HTMLContent_Detail_DetailId",
                        column: x => x.DetailId,
                        principalTable: "Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Detail",
                columns: new[] { "Id", "SectionId", "SectionKey", "Type" },
                values: new object[,]
                {
                    { 1, null, "terminal-introduction", 0 },
                    { 2, null, "terminal-introduction", 0 },
                    { 3, null, "terminal-introduction", 0 },
                    { 4, null, "terminal-setup", 0 },
                    { 5, null, "terminal-setup", 0 },
                    { 6, null, "terminal-setup", 3 },
                    { 7, null, "terminal-setup", 3 },
                    { 8, null, "terminal-setup", 3 },
                    { 9, null, "terminal-setup", 2 },
                    { 10, null, "terminal-setup", 0 },
                    { 11, null, "terminal-setup", 4 },
                    { 12, null, "terminal-usage", 0 },
                    { 13, null, "terminal-usage", 0 },
                    { 14, null, "terminal-usage", 0 },
                    { 15, null, "terminal-usage", 4 },
                    { 16, null, "terminal-usage", 0 },
                    { 17, null, "terminal-usage", 4 },
                    { 18, null, "terminal-usage", 0 },
                    { 19, null, "terminal-usage", 4 },
                    { 20, null, "terminal-usage", 2 },
                    { 21, null, "terminal-usage", 0 },
                    { 22, null, "terminal-usage", 4 },
                    { 23, null, "terminal-usage", 0 },
                    { 24, null, "scripts-introduction", 0 },
                    { 25, null, "scripts-introduction", 0 },
                    { 26, null, "scripts-introduction", 2 },
                    { 27, null, "scripts-terminal", 0 },
                    { 28, null, "scripts-ohmyposh", 0 },
                    { 29, null, "scripts-ohmyposh", 0 },
                    { 30, null, "scripts-ohmyposh", 3 },
                    { 31, null, "scripts-ohmyposh", 0 },
                    { 32, null, "scripts-ohmyposh", 3 },
                    { 33, null, "scripts-ohmyposh", 0 },
                    { 34, null, "scripts-ohmyposh", 0 },
                    { 35, null, "scripts-winterm", 0 },
                    { 36, null, "scripts-winterm", 0 },
                    { 37, null, "scripts-winterm", 3 },
                    { 38, null, "scripts-winterm", 0 },
                    { 39, null, "scripts-winterm", 4 },
                    { 40, null, "scripts-poshgit", 0 },
                    { 41, null, "scripts-poshgit", 0 },
                    { 42, null, "scripts-shell", 0 }
                });

            migrationBuilder.InsertData(
                table: "Detail",
                columns: new[] { "Id", "SectionId", "SectionKey", "Type" },
                values: new object[,]
                {
                    { 43, null, "scripts-wsl", 0 },
                    { 44, null, "scripts-wsl", 2 },
                    { 45, null, "scripts-wsl", 0 },
                    { 46, null, "scripts-wsl", 0 },
                    { 47, null, "scripts-wsl", 4 },
                    { 48, null, "scripts-wsl", 0 },
                    { 49, null, "scripts-wsl", 0 },
                    { 50, null, "scripts-wsl", 4 },
                    { 51, null, "scripts-wsl", 0 },
                    { 52, null, "scripts-wsl", 4 },
                    { 53, null, "scripts-wsl", 0 },
                    { 54, null, "scripts-wsl", 4 },
                    { 55, null, "scripts-wsl", 0 },
                    { 56, null, "scripts-wsl", 4 },
                    { 57, null, "scripts-wsl", 0 },
                    { 58, null, "scripts-wsl", 4 },
                    { 59, null, "scripts-wsl", 0 },
                    { 60, null, "scripts-wsl", 4 },
                    { 61, null, "scripts-virtual", 0 },
                    { 62, null, "scripts-docker", 0 },
                    { 63, null, "scripts-podman", 0 },
                    { 64, null, "scripts-sdk", 0 },
                    { 65, null, "scripts-sindamodule", 0 },
                    { 66, null, "scripts-sindamodule", 0 },
                    { 67, null, "scripts-sindamodule", 0 },
                    { 68, null, "scripts-sindamodule", 3 },
                    { 69, null, "scripts-sindamodule", 0 },
                    { 70, null, "scripts-sindamodule", 3 },
                    { 71, null, "scripts-sindamodule", 0 },
                    { 72, null, "scripts-sindamodule", 3 },
                    { 73, null, "scripts-sindamodule", 0 },
                    { 74, null, "scripts-sindamodule", 3 },
                    { 75, null, "scripts-sindamodule", 0 },
                    { 76, null, "scripts-sindamodule", 3 },
                    { 77, null, "scripts-sindamodule", 0 },
                    { 78, null, "scripts-sindamodule", 3 },
                    { 79, null, "scripts-sindamodule", 0 },
                    { 80, null, "scripts-boilerplate", 0 },
                    { 81, null, "scripts-portfolio", 0 },
                    { 82, null, "scripts-portfolio", 0 },
                    { 83, null, "boilerplate-introduction", 0 },
                    { 84, null, "boilerplate-portfolio", 0 }
                });

            migrationBuilder.InsertData(
                table: "Detail",
                columns: new[] { "Id", "SectionId", "SectionKey", "Type" },
                values: new object[,]
                {
                    { 85, null, "boilerplate-portfolio-setup", 0 },
                    { 86, null, "boilerplate-portfolio-setup", 3 },
                    { 87, null, "boilerplate-portfolio-setup", 0 },
                    { 88, null, "boilerplate-portfolio-setup", 3 },
                    { 89, null, "boilerplate-portfolio-setup", 0 },
                    { 90, null, "boilerplate-portfolio-setup", 3 },
                    { 91, null, "boilerplate-portfolio-setup", 3 },
                    { 92, null, "boilerplate-portfolio-setup", 3 },
                    { 93, null, "boilerplate-portfolio-setup", 0 },
                    { 94, null, "boilerplate-portfolio-setup", 4 },
                    { 95, null, "boilerplate-portfolio-hero", 0 },
                    { 96, null, "boilerplate-portfolio-hero", 0 },
                    { 97, null, "boilerplate-portfolio-hero", 3 },
                    { 98, null, "boilerplate-portfolio-hero", 0 },
                    { 99, null, "boilerplate-portfolio-hero", 4 },
                    { 100, null, "boilerplate-portfolio-hero", 0 },
                    { 101, null, "boilerplate-portfolio-hero", 4 },
                    { 102, null, "boilerplate-portfolio-hero", 0 },
                    { 103, null, "boilerplate-portfolio-hero", 4 },
                    { 104, null, "boilerplate-portfolio-hero", 0 },
                    { 105, null, "boilerplate-portfolio-hero", 4 },
                    { 106, null, "boilerplate-portfolio-body", 0 },
                    { 107, null, "boilerplate-portfolio-body", 4 },
                    { 108, null, "boilerplate-portfolio-body", 0 },
                    { 109, null, "boilerplate-portfolio-body", 0 },
                    { 110, null, "boilerplate-portfolio-body", 0 },
                    { 111, null, "boilerplate-portfolio-body", 4 },
                    { 112, null, "boilerplate-portfolio-body", 0 },
                    { 113, null, "boilerplate-portfolio-body", 0 }
                });

            migrationBuilder.InsertData(
                table: "Sites",
                columns: new[] { "BrandName", "BrandDescription" },
                values: new object[] { "Sinda", "Sindagal MIT" });

            migrationBuilder.InsertData(
                table: "HTMLContent",
                columns: new[] { "DetailId", "Id", "Language", "Type", "Value", "content_type" },
                values: new object[,]
                {
                    { 6, 10, "shell", 0, "git clone https://github.com/denzii/sinda-cli.git", 4 },
                    { 7, 11, "shell", 0, "cd sinda-cli", 4 },
                    { 8, 12, "shell", 0, "npm start", 4 },
                    { 30, 53, "shell", 0, "Get-PoshThemes", 4 },
                    { 32, 55, "shell", 0, "Set-PoshPrompt darkblood", 4 },
                    { 37, 66, "shell", 0, "wt -p \"Debian\" `; split-pane -p \"Windows PowerShell\" `;", 4 },
                    { 68, 124, "shell", 0, "Get-EnvState", 4 },
                    { 70, 126, "shell", 0, "Enable-WSLLegacy", 4 },
                    { 72, 128, "shell", 0, "Add-SindaDistro", 4 },
                    { 74, 130, "shell", 0, "Test-Elevation", 4 },
                    { 76, 132, "shell", 0, "Enable-WindowsTerminal", 4 },
                    { 78, 134, "shell", 0, "Disable-WindowsTerminal", 4 },
                    { 86, 155, "shell", 0, "git clone https://github.com/denzii/sinda-portfolio.git", 4 },
                    { 91, 156, "shell", 0, "npm install", 4 },
                    { 88, 157, "shell", 0, "npm i -g next", 4 },
                    { 92, 157, "shell", 0, "npm run dev", 4 },
                    { 90, 159, "shell", 0, "cd sinda-portfolio", 4 },
                    { 97, 170, "shell", 0, "code .", 4 }
                });

            migrationBuilder.InsertData(
                table: "HTMLContent",
                columns: new[] { "DetailId", "Id", "Type", "Value", "content_type" },
                values: new object[,]
                {
                    { 1, 1, 0, "Sindagal ", 1 },
                    { 1, 3, 0, " is a simple Node.js application which makes use of the popular JavaScript framework React. The goal is to make developer lives more convenient by wrapping around operating system level scripts and allowing their easy consumption.", 1 },
                    { 3, 5, 0, "On this page, you'll learn what the Sinda Command Line Interface brings to the table and how it can be consumed by setting it up from scratch and consuming some of the built in automation scripts on a Windows machine.", 1 },
                    { 4, 6, 0, "The project requires Node.js LTS and npm to be installed as a pre-requisite so if you do not already have them, now is a good time to set them up.", 1 },
                    { 4, 8, 0, "by Microsoft demonstrates how they could be set on a Windows machine using the Node Version Manager tool (NVM).", 1 },
                    { 5, 9, 0, "Once NVM & Node.js are configured, we could proceed to cloning the repository and running the app from the cloned source code. Its necessary to fork and/or clone the repository since the app itself requires access to the localhost machine so it can run powershell/bash scripts.", 1 },
                    { 9, 13, 0, "The app requires administrator rights to run Powershell / Bash scripts on localhost, if its run from a non-elevated terminal session, it will result in an error and not run.", 1 },
                    { 10, 14, 0, "The following image demonstrates the landing page for a successfully started CLI.", 1 },
                    { 12, 18, 0, "Consuming scripts from the app is pretty straight forward and takes only a few key-presses to achieve. As seen on the landing page image, the terminal prompt functions similarly to a single page app and the visible part of the terminal is hijacked by a", 1 },
                    { 12, 20, 0, "Component", 1 },
                    { 13, 21, 0, "The component itself detects the screen height and width and resizes accordingly. Having said that, a maximized terminal window is recommended for the best experience and the resizing  feature is only meant for the application startup. If the terminal window gets resized while the app is running, there are no guarantees for correct rendering of the component.", 1 },
                    { 14, 22, 0, "Once a key is pressed on the landing page, the survey component is rendered and the user is presented with all the available automation scripts... Navigation of the form is achieved through the <i>Up / Down / Enter & Esc </i> keys. This component is demonstrated in the following image.", 1 },
                    { 16, 26, 0, "For the sake of this tutorial, we are only going to be selecting the first three options. Once the selections are made, it is required to navigate to the last page of the survey and confirm the selections.  The \"proceed\" button will ask for a re-confirmation and esc key could be used to go back to the form.", 1 },
                    { 18, 30, 0, "Prior to making any changes to the machine, all the selected features and their corresponding scripts are listed and a confirmation is requested once more for extra safety.", 1 },
                    { 20, 34, 0, "For the time being, the scripts are executed syncronously and the results within the box are updated all at once.", 1 },
                    { 21, 35, 0, "The Standard Outputs as well as Errors for the executed commands are pushed above the component box in real-time. A finished session is demonstrated in the below image.", 1 },
                    { 23, 39, 0, "Thats all folks! See how easy it was to consume some powershell scripts? To see the full list of the existing scripts, please navigate to the scripts tab on this page.", 1 },
                    { 24, 40, 0, "As described in the Terminal tab, Sindagal comes with some built-in scripts and can also be extended to interface to personal scripts. The scripts are categorized as Terminal, Shell, Virtual, SDK & Boilerplate.", 1 },
                    { 24, 41, 0, " The CLI tool works by executing powershell / bash scripts which exist inside the code repository itself under the src/scripts directory.", 1 },
                    { 25, 42, 0, " On this page, we will be exploring the various details regarding those features and why they might come in handy for you or your organisation.", 1 },
                    { 26, 43, 0, "For the time being, everything is in the Minimum Viable Product stage & things might change in the future. Please report any problems or bugs to me personally through my ", 1 },
                    { 26, 45, 0, " Pull requests are welcome at the ", 1 },
                    { 27, 47, 0, "This category is where the scripts regarding the interactive terminal session reside. These will alter the look & feel of your interactions with your local shell.", 1 },
                    { 28, 48, 0, "By default, terminal prompts on Windows machines come with no support for user themes, lack descriptiveness and are not intuitive to use. Wouldn't it be nice if the sessions could be personalized & extended with additional information such as the time of command execution, git active branch names, battery level and more?", 1 }
                });

            migrationBuilder.InsertData(
                table: "HTMLContent",
                columns: new[] { "DetailId", "Id", "Type", "Value", "content_type" },
                values: new object[,]
                {
                    { 28, 49, 0, " Enter ", 1 },
                    { 28, 51, 0, " A shell framework for doing all of that! Historically this worked only on Windows but with Powershell going cross platform, it now works on Linux & Mac as well. ", 1 },
                    { 29, 52, 0, "The framework is easily configurable... All available themes could be reviewed by: ", 1 },
                    { 31, 54, 0, "changing the theme to \"Darkblood\": ", 1 },
                    { 33, 56, 0, "Having said that, it is also possible to configure it via code by adjusting an init script at a location which can be found from the Get-PoshThemes command. ", 1 },
                    { 34, 57, 0, "Oh My Posh relies on a specific font family in order to display its many glyphs properly, Sinda takes care of installing the ", 1 },
                    { 34, 59, 0, " for you!", 1 },
                    { 35, 60, 0, "The default Powershell / Command Prompt & WSL terminal apps are some-what primitive, those emulators damage productivity. They are difficult to impossible to standardize, they require switching between windows which can get tedious & confusing from time to time and they lack certain features when it comes to keyboard shortcuts.", 1 },
                    { 35, 62, 0, " intends to remedy the above problems by allowing multiple tabs, split screens, extensive keyboard macros and multi-shell support.", 1 },
                    { 35, 63, 0, " Tabs could contain any session ranging from Azure, WSL2, Remote SSH, Powershell & CMD!", 1 },
                    { 35, 64, 0, " This powerful open source tool also allows launching sessions programatically through powershell commands.", 1 },
                    { 36, 65, 0, "To start WSL Debian & Powershell sessions programatically: ", 1 },
                    { 38, 67, 0, "Results in the following interactive sessions:", 1 },
                    { 40, 71, 0, "As always, the stock functionality with Windows is lacked and this time its with Git on Powershell & Command Prompt... ", 1 },
                    { 41, 73, 0, "a powershell module, once imported, allows auto completion for all git commands. This makes life easier as less typing is required to navigate daily tasks.", 1 },
                    { 42, 74, 0, "The Shell category harbours everything which will alter the installed shell(s) themselves such as changing default powershell versions or installing WSL on localhost etc.", 1 },
                    { 43, 75, 0, "This is a pre configured WSL2 instance which had been exported and put online for easy consumption.", 1 },
                    { 43, 76, 0, " The purpose of this is to encapsulate basic linux setup and provide a ready developer environment for common tasks.", 1 },
                    { 43, 77, 0, " It comes with ", 1 },
                    { 43, 79, 0, " as well as ", 1 },
                    { 43, 81, 0, " Zsh is the default shell which OSX systems are shipped with and OhMyZsh is a framework for adding magic to it!", 1 },
                    { 44, 82, 0, "The features & plugins are not limited to the ones demonstrated below!", 1 },
                    { 45, 83, 0, "Themes could be configured on Oh My Zsh and all the themes which exist for Oh My Posh also exist for Oh My Zsh if not more! all existing ", 1 },
                    { 45, 85, 0, "could be found in the given link! ", 1 },
                    { 45, 86, 0, " The Sinda Ubuntu comes with the theme \"agnoster\" but this can easily be changed by amending the .zshrc file.", 1 },
                    { 46, 87, 0, "First look on the .zshrc file:", 1 },
                    { 48, 90, 0, "As shown in the image above, Oh My Zsh can be configured with many ", 1 },
                    { 48, 92, 0, " plugins which make life convenient! The Sinda Ubuntu comes with the git, debian, alias-finder, docker, command-not-found, thefuck & docker.", 1 },
                    { 48, 93, 0, " These of course can be changed by editing the plugins array. Below are some images demonstrating the Zsh & Oh My Zsh features further!", 1 },
                    { 49, 94, 0, "Thefuck:", 1 },
                    { 51, 97, 0, "Git branch display:", 1 },
                    { 53, 100, 0, "Auto complete & switch on tab key:", 1 },
                    { 55, 103, 0, "Autocorrect:", 1 },
                    { 57, 105, 0, "Alias finder:", 1 },
                    { 59, 108, 0, "Command not found:", 1 },
                    { 61, 111, 0, "The Virtualization category includes scripts for installing toolsets & software such as Docker / Podman which make it easier to consume / ship software by professionals.", 1 },
                    { 62, 112, 0, "This installs ", 1 },
                    { 62, 114, 0, " with the WSL2 backend through the chocolatey package manager. Historically very difficult to achieve but today its not even a few lines of code, what a time to be alive!", 1 },
                    { 63, 115, 0, "Much like Docker, ", 1 },
                    { 63, 117, 0, " is a software for managing OCI Containers, this installation is provided as an alternative for the ones who prefer it instead of Docker.", 1 },
                    { 64, 118, 0, "The scripts under this section are all about giving developers more power by making internal Sinda tools available. The tools function as encapsulation on certain tasks into one liners.", 1 },
                    { 65, 119, 0, "This is a Powershell module & an exact copy of the internal scripts used with the CLI tool wrapped in an easily importable format.", 1 }
                });

            migrationBuilder.InsertData(
                table: "HTMLContent",
                columns: new[] { "DetailId", "Id", "Type", "Value", "content_type" },
                values: new object[,]
                {
                    { 65, 120, 0, "the command imports the module located at src/script/Sindagal.psm1 into the powershell profile of the user using the machine", 1 },
                    { 65, 121, 0, "Once the module is imported, the developer gains direct access to all the features included in the CLI & more through direct powershell commands!", 1 },
                    { 66, 122, 0, "All the commands could be inspected in the file location mentioned within the CLI repository, however some of them are explained below.", 1 },
                    { 67, 123, 0, "To check the current state of your system for things such as os version, architecture, wsl2 support etc: ", 1 },
                    { 69, 125, 0, "To install WSL on legacy systems where WSL2 or wsl --install command are not supported ", 1 },
                    { 71, 127, 0, "To download & import the Sinda pre configured wsl2 instance:", 1 },
                    { 73, 129, 0, "Check if terminal session has admin rights:", 1 },
                    { 75, 131, 0, "Install & Configure Windows Terminal with Nerd Fonts:", 1 },
                    { 77, 133, 0, "Disable & delete Windows Terminal:", 1 },
                    { 79, 135, 0, "And many more!", 1 },
                    { 80, 136, 0, "The Boilerplate section contains scripts which clone Ready to go Sinda Codebases from github. The repositories are intended to solve common problems & be as easily personalized as possible.", 1 },
                    { 81, 137, 0, "This clones a reusable & extensible web portfolio template written with React using the NextJS framework. The repository could be found ", 1 },
                    { 81, 139, 0, "This simplistic portfolio itself has basic SEO optimizations, keyboard and developer accessibility; a performant ", 1 },
                    { 81, 141, 0, " score as well as good responsive UI/UX principles!", 1 },
                    { 81, 142, 0, " Feel free to change the data & reupload it to your favourite version-control website as you please!", 1 },
                    { 82, 143, 0, "For more information regarding this template & web theme, please refer to the Boilerplate tab on this page.", 1 },
                    { 83, 144, 0, "Do you have some boilerplate code which you always have to write from scratch? Are you in a hurry to get up and running with an MVP?", 1 },
                    { 83, 145, 0, " Sindagal Boilerplates will come to your rescue!", 1 },
                    { 84, 145, 0, "Planning to look for that next challange in your career but do not have time to fiddle with UI/UX or write the code for a portfolio website from scratch?", 1 },
                    { 83, 146, 0, " On this page, we will be exploring how to set up and work with existing code as well as how to extend them to our needs to save time from cumbersome work!", 1 },
                    { 84, 146, 0, " You can now rest easy with this ", 1 },
                    { 84, 148, 0, " This template simplistic enough to do the job and will hit the spot with its SEO optimizations, keyboard and developer accessibility; a performant ", 1 },
                    { 84, 150, 0, " score as well as good responsive UI/UX principles!", 1 },
                    { 84, 151, 0, " please find a live example at", 1 },
                    { 85, 153, 0, "This is a NextJS TypeScript project so NodeJS & npm are required as a prerequisite.", 1 },
                    { 85, 154, 0, "If those already exist on the machine or if you are using the pre configured WSL instance, its okay to proceed to cloning the repository.", 1 },
                    { 87, 156, 0, "Install Nextjs globally:", 1 },
                    { 89, 158, 0, "Move into the repository, install dependencies and run the app:", 1 },
                    { 93, 158, 0, "If everything went well, it's now okay to visit localhost:3000 in your favourite browser to see the site!", 1 },
                    { 95, 162, 0, "Not bad! In order to personalize it, we need to make a few tweaks.", 1 },
                    { 95, 163, 0, " The data is pulled into a single class at ", 1 },
                    { 95, 165, 0, " class for the most part and this is where we will spend most of our time.", 1 },
                    { 95, 166, 0, " having said that, the page title and the meta tags for SEO as well as canonical must also be changed for a fully personalized portfolio. In a NextJS project, these are stored in ", 1 },
                    { 95, 168, 0, " as per convention. It is planned to pull these into the data folder in the future as well!", 1 },
                    { 96, 169, 0, "Let's view the code in our favourite code editor and see how to go about the modifications!", 1 },
                    { 98, 171, 0, "To start things off, lets change the navigation bar contents by changing the ProjectOwner, PersonalURLs & PersonalBackground Objects as shown.", 1 },
                    { 100, 175, 0, " Icons for social media could be changed by supplying a name from the ", 1 },
                    { 100, 177, 0, " Icons. Additional navigation links such as \"instagram\" could also be added or removed if desired by altering the keys on the", 1 },
                    { 100, 179, 0, " class further. For demonstration purposes, lets remove the email icon while changing the other two icons.", 1 },
                    { 102, 183, 0, " The keys on the object ", 1 },
                    { 102, 185, 0, " are used to generate the sections below the hero section. If we wanted to add or remove or alter a section, all we would need to do is to alter the keys on it!", 1 },
                    { 102, 186, 0, " for the sake of this tutorial, let's remove the hobbies section and rename some of the others!", 1 }
                });

            migrationBuilder.InsertData(
                table: "HTMLContent",
                columns: new[] { "DetailId", "Id", "Type", "Value", "content_type" },
                values: new object[,]
                {
                    { 104, 190, 0, " Now that those are out of the way, its a good time to change the background and the headshot images which are located inside the ", 1 },
                    { 104, 192, 0, " directory, all that is required is to drop in the images in that directory and reference them inside the data class. The app is written flexible enough to allow the usage of different image names as-well!", 1 },
                    { 106, 195, 0, "We've come a long way and the results are just beautiful! Refresh the browser page to see that the website now looks like this: ", 1 },
                    { 107, 199, 0, "How about the body sections? Are they even flexible enough for personalization? They sure are! All that needs to be done is to alter the methods which are being called within the \"PersonalBackground\" method inside the data class.", 1 },
                    { 108, 200, 0, " The heading, date range & inner content are supplied within the same place, the inner content could be made bold, italic or emphasized on demand without touching any HTML.", 1 },
                    { 109, 201, 0, " If it's a semantic markup for your website which you are looking for; you can add emphasis and other things to certain text but also keep it unstyled.", 1 },
                    { 109, 202, 0, " This is a good idea if you would like your website to read well by screen readers so elements could be emphesized without changing the visual feeling...", 1 },
                    { 109, 203, 0, " The body elements could be given captions aswell by assigning the \"caption\" field a string value.", 1 },
                    { 110, 204, 0, "Example body section element code:", 1 },
                    { 112, 207, 0, "Only one thing remains, changing the meta content of the site! And this is as easy as going into the pages/_document.tsx", 1 },
                    { 112, 209, 0, " file and altering the given strings.", 1 },
                    { 112, 210, 0, " add in the full address of your domain as a canonical, change the tab title as you wish and amend the keywords to cater to your target audiences google searches.", 1 },
                    { 113, 211, 0, "That is all! Enjoy your Sinda Portfolio and do not forget to give a star or send your pull requests!", 1 },
                    { 113, 212, 0, " We will not be touching on how to deploy this website since it is using the stock CI/CD which is provided by Vercel for free on personal projects.", 1 },
                    { 113, 213, 0, " To find out more about deployments, visit their tutorials at ", 1 }
                });

            migrationBuilder.InsertData(
                table: "HTMLContent",
                columns: new[] { "DetailId", "Id", "Alt", "Src", "Type", "Value", "content_type" },
                values: new object[,]
                {
                    { 11, 17, "CLI Landing Page", "./img/cli-landing-page.png", 0, null, 6 },
                    { 15, 25, "CLI Survey Page", "./img/cli-survey-page.png", 0, null, 6 },
                    { 17, 29, "CLI Survey Page Confirmation", "./img/cli-survey-page-confirmation.png", 0, null, 6 },
                    { 19, 33, "CLI Survey Page Finalization", "./img/cli-survey-page-confirmation-2.png", 0, null, 6 },
                    { 22, 38, "CLI Survey Page Results", "./img/cli-survey-page-results.png", 0, null, 6 },
                    { 39, 70, "CLI Landing Page", "./img/winterm", 0, null, 6 },
                    { 47, 89, "First look on .zshrc file", "./img/zsh-rc.png", 0, null, 6 },
                    { 50, 96, "Thefuck demo", "./img/zsh-thefuck.png", 0, null, 6 },
                    { 52, 99, "git branch display demo", "./img/zsh-git-branch.png", 0, null, 6 },
                    { 54, 102, "auto complete  demo", "./img/zsh-tab-switch.png", 0, null, 6 },
                    { 56, 104, "auto correction demo", "./img/zsh-autocorrect.png", 0, null, 6 },
                    { 58, 107, "alias finder demo", "./img/zsh-alias-finder.png", 0, null, 6 },
                    { 60, 110, "command not found demo", "./img/zsh-command-not-found.png", 0, null, 6 },
                    { 94, 161, "Portfolio Landing Page", "./img/portfolio-landing-page.png", 0, null, 6 },
                    { 99, 174, "Portfolio Navbar modification", "./img/portfolio-navbar-name-diff.png", 0, null, 6 },
                    { 101, 182, "Portfolio Socialbar modification", "./img/portfolio-socialbar-diff.png", 0, null, 6 },
                    { 103, 189, "Portfolio Navbar elements modification", "./img/portfolio-navbar-elems-diff.png", 0, null, 6 },
                    { 105, 194, "Portfolio hero images modification", "./img/portfolio-hero-diff.png", 0, null, 6 },
                    { 107, 198, "Portfolio altered hero section", "./img/portfolio-altered-hero-diff.png", 0, null, 6 },
                    { 111, 206, "Portfolio body code example", "./img/portfolio-body-code.png", 0, null, 6 }
                });

            migrationBuilder.InsertData(
                table: "HTMLContent",
                columns: new[] { "DetailId", "Id", "Href", "Type", "Value", "content_type" },
                values: new object[,]
                {
                    { 1, 2, "https://github.com/denzii/sinda-cli", 0, "Command Line Interface", 2 },
                    { 4, 7, "https://docs.microsoft.com/en-us/windows/dev-environment/javascript/nodejs-on-windows", 0, "This tutorial", 2 },
                    { 12, 19, "https://github.com/vadimdemedes/ink", 0, "React Ink", 2 },
                    { 26, 44, "https://www.linkedin.com/in/denizarca/", 0, "Linkedin.", 2 },
                    { 26, 46, "https://github.com/denzii/sinda-cli", 0, "CLI repository.", 2 },
                    { 28, 50, "https://ohmyposh.dev/", 0, "Oh My Posh!", 2 },
                    { 34, 58, "https://github.com/ryanoasis/nerd-fonts", 0, "Nerd Fonts", 2 }
                });

            migrationBuilder.InsertData(
                table: "HTMLContent",
                columns: new[] { "DetailId", "Id", "Href", "Type", "Value", "content_type" },
                values: new object[,]
                {
                    { 35, 61, "https://docs.microsoft.com/en-us/windows/terminal/", 0, "Windows Terminal", 2 },
                    { 41, 72, "https://github.com/dahlbyk/posh-git", 0, "PoshGit", 2 },
                    { 43, 78, "https://www.zsh.org/", 0, "Zsh", 2 },
                    { 43, 80, "https://ohmyz.sh/", 0, "Oh My Zsh.", 2 },
                    { 45, 84, "https://github.com/ohmyzsh/ohmyzsh/wiki/Themes", 0, "Oh My Zsh Themes", 2 },
                    { 48, 91, "https://github.com/ohmyzsh/ohmyzsh/wiki/Plugins", 0, "plugins,", 2 },
                    { 62, 113, "https://www.docker.com/products/docker-desktop", 0, "Docker Desktop", 2 },
                    { 63, 116, "https://podman.io/", 0, "Podman", 2 },
                    { 81, 138, "https://github.com/denzii/sinda-portfolio", 0, "here.", 2 },
                    { 81, 140, "https://developers.google.com/web/tools/lighthouse", 0, "Chrome Lighthouse", 2 },
                    { 84, 147, "https://github.com/denzii/sinda-portfolio", 0, "web portfolio.", 2 },
                    { 84, 149, "https://developers.google.com/web/tools/lighthouse", 0, "Lighthouse", 2 },
                    { 84, 152, "https://denizarca.com", 0, "denizarca.com", 2 },
                    { 95, 164, "https://github.com/denzii/sinda-portfolio/blob/main/data/index.ts", 0, "data/index.ts", 2 },
                    { 95, 167, "https://github.com/denzii/sinda-portfolio/blob/main/pages/_document.tsx", 0, "pages/_document.tsx", 2 },
                    { 100, 176, "https://react-icons.github.io/react-icons/icons?name=fa", 0, "React Font Awesome", 2 },
                    { 100, 178, "https://github.com/denzii/sinda-portfolio/blob/main/interface/personalUrls.ts", 0, "interface/personalUrls.ts", 2 },
                    { 102, 184, "https://github.com/denzii/sinda-portfolio/blob/main/interface/background.ts", 0, "interface/background.ts", 2 },
                    { 104, 191, "https://github.com/denzii/sinda-portfolio/tree/main/public", 0, "public", 2 },
                    { 112, 208, "https://github.com/denzii/sinda-portfolio/tree/main/public", 0, "pages/_document.tsx", 2 },
                    { 113, 214, "https://nextjs.org/docs/deployment", 0, "nextjs.org/deployment", 2 }
                });

            migrationBuilder.InsertData(
                table: "HTMLContent",
                columns: new[] { "DetailId", "Id", "Media", "Srcset", "Type", "Value", "content_type" },
                values: new object[,]
                {
                    { 11, 15, "(max-width: 950px)", "./img/cli-landing-page-850w.png", 0, null, 5 },
                    { 11, 16, null, "./img/cli-landing-page.png", 0, null, 5 },
                    { 15, 23, "(max-width: 950px)", "./img/cli-survey-page-850w.png", 0, null, 5 },
                    { 15, 24, null, "./img/cli-survey-page.png", 0, null, 5 },
                    { 17, 27, "(max-width: 950px)", "./img/cli-survey-page-confirmation-850w.png", 0, null, 5 },
                    { 17, 28, null, "./img/cli-survey-page-confirmation.png", 0, null, 5 },
                    { 19, 31, "(max-width: 950px)", "./img/cli-survey-page-confirmation-2-850w.png", 0, null, 5 },
                    { 19, 32, null, "./img/cli-survey-page-confirmation-2.png", 0, null, 5 },
                    { 22, 36, "(max-width: 950px)", "./img/cli-survey-page-results-850w.png", 0, null, 5 },
                    { 22, 37, null, "./img/cli-survey-page-results.png", 0, null, 5 },
                    { 39, 68, "(max-width: 950px)", "./img/winterm-850w.png", 0, null, 5 },
                    { 39, 69, null, "./img/winterm.png", 0, null, 5 },
                    { 47, 88, null, "./img/zsh-rc.png", 0, null, 5 },
                    { 50, 95, null, "./img/zsh-thefuck.png", 0, null, 5 },
                    { 52, 98, null, "./img/zsh-git-branch.png", 0, null, 5 },
                    { 54, 101, null, "./img/zsh-tab-switch.png", 0, null, 5 },
                    { 58, 106, null, "./img/zsh-alias-finder.png", 0, null, 5 },
                    { 60, 109, null, "./img/zsh-command-not-found.png", 0, null, 5 },
                    { 94, 159, "(max-width: 950px)", "./img/portfolio-landing-page-850w.png", 0, null, 5 },
                    { 94, 160, null, "./img/portfolio-landing-page.png", 0, null, 5 },
                    { 99, 172, "(max-width: 950px)", "./img/portfolio-navbar-name-diff-850w.png", 0, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "HTMLContent",
                columns: new[] { "DetailId", "Id", "Media", "Srcset", "Type", "Value", "content_type" },
                values: new object[,]
                {
                    { 99, 173, null, "./img/portfolio-navbar-name-diff.png", 0, null, 5 },
                    { 101, 180, "(max-width: 950px)", "./img/portfolio-socialbar-diff-850w.png", 0, null, 5 },
                    { 101, 181, null, "./img/portfolio-socialbar-diff.png", 0, null, 5 },
                    { 103, 187, "(max-width: 950px)", "./img/portfolio-navbar-elems-diff-850w.png", 0, null, 5 },
                    { 103, 188, null, "./img/portfolio-navbar-elems-diff.png", 0, null, 5 },
                    { 105, 193, null, "./img/portfolio-hero-diff.png", 0, null, 5 },
                    { 107, 196, "(max-width: 950px)", "./img/portfolio-altered-hero-diff-850w.png", 0, null, 5 },
                    { 107, 197, null, "./img/portfolio-altered-hero-diff.png", 0, null, 5 },
                    { 111, 205, "(max-width: 950px)", "./img/portfolio-body-code.png", 0, null, 5 },
                    { 56, 215, null, "./img/zsh-autocorrect.png", 0, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "HTMLContent",
                columns: new[] { "DetailId", "Id", "Type", "Value", "content_type" },
                values: new object[] { 2, 4, 0, "For the time being, usages from within WSL & Unix based systems had been disabled.", 3 });

            migrationBuilder.InsertData(
                table: "PageDetail",
                columns: new[] { "Name", "SiteBrandName" },
                values: new object[,]
                {
                    { "Blog", "Sinda" },
                    { "Docs", "Sinda" },
                    { "Roadmap", "Sinda" }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                column: "PageDetailName",
                value: "Blog");

            migrationBuilder.InsertData(
                table: "Pages",
                column: "PageDetailName",
                value: "Docs");

            migrationBuilder.InsertData(
                table: "Pages",
                column: "PageDetailName",
                value: "Roadmap");

            migrationBuilder.InsertData(
                table: "Tab",
                columns: new[] { "Name", "PageName", "Status" },
                values: new object[,]
                {
                    { "Articles", "Blog", 1 },
                    { "Boilerplate", "Docs", 0 },
                    { "News", "Blog", 1 },
                    { "Philosophy", "Roadmap", 1 },
                    { "Scripts", "Docs", 0 },
                    { "Terminal", "Docs", 0 },
                    { "Vision", "Roadmap", 1 }
                });

            migrationBuilder.InsertData(
                table: "Section",
                columns: new[] { "Id", "PageName", "TabName", "HasMainContent", "Header" },
                values: new object[,]
                {
                    { "boilerplate-portfolio", "Docs", "Boilerplate", false, "1) Sinda Portfolio" },
                    { "boilerplate-portfolio-body", "Docs", "Boilerplate", false, "Changing the body section contents" },
                    { "scripts-boilerplate", "Docs", "Scripts", true, "Boilerplates & Codebases" },
                    { "scripts-introduction", "Docs", "Scripts", true, "Introduction" },
                    { "scripts-podman", "Docs", "Scripts", false, "2) Podman" },
                    { "scripts-winterm", "Docs", "Scripts", false, "2) Windows Terminal by Microsoft" },
                    { "scripts-wsl", "Docs", "Scripts", false, "1) SindaDistro" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detail_SectionId",
                table: "Detail",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_HTMLContent_DetailId",
                table: "HTMLContent",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PageDetail_SiteBrandName",
                table: "PageDetail",
                column: "SiteBrandName");

            migrationBuilder.CreateIndex(
                name: "IX_Section_PageName",
                table: "Section",
                column: "PageName");

            migrationBuilder.CreateIndex(
                name: "IX_Section_TabName",
                table: "Section",
                column: "TabName");

            migrationBuilder.CreateIndex(
                name: "IX_Tab_PageName",
                table: "Tab",
                column: "PageName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HTMLContent");

            migrationBuilder.DropTable(
                name: "Detail");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Tab");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "PageDetail");

            migrationBuilder.DropTable(
                name: "Sites");
        }
    }
}
