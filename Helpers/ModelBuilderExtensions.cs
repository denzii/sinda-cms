using Microsoft.EntityFrameworkCore;
using SindaCMS.Models;

namespace SindaCMS.Helpers
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PageDetail>().HasOne(d => d.Site).WithMany(s => s.PageNames).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PageDetail>().HasData(
                new PageDetail { Index=0, Name = "Docs", SiteBrandName = "Sinda" },
                new PageDetail { Index=1, Name = "Blog", SiteBrandName = "Sinda" },
                new PageDetail { Index=2, Name = "Roadmap", SiteBrandName = "Sinda" }
            );

            modelBuilder.Entity<Site>().HasData(
                 new Site {
                     BrandName = "Sinda",
                     BrandDescription = "Sindagal MIT",
                 }
            );

            modelBuilder.Entity<Page>().HasData(
                new Page { PageDetailName = "Docs" },
                new Page { PageDetailName = "Blog" },
                new Page { PageDetailName = "Roadmap" }
            );

            modelBuilder.Entity<Tab>().HasOne(t => t.Page).WithMany(p => p.Tabs).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Tab>().HasData(
                new Tab { Index=0, PageName="Docs", Name = "Terminal", Status = SectionStatus.Public },
                new Tab { Index=1, PageName="Docs", Name = "Scripts", Status = SectionStatus.Public },
                new Tab { Index=2, PageName = "Docs", Name = "Boilerplate", Status = SectionStatus.Public },
                new Tab { Index=0, PageName = "Blog", Name = "Articles", Status = SectionStatus.Hidden },
                new Tab { Index=1, PageName = "Blog", Name = "News", Status = SectionStatus.Hidden },
                new Tab { Index=0, PageName = "Roadmap", Name = "Philosophy", Status = SectionStatus.Hidden },
                new Tab { Index=1, PageName = "Roadmap", Name = "Vision", Status = SectionStatus.Hidden }
            );

            modelBuilder.Entity<Section>().HasOne(s => s.Tab).WithMany(t => t.Sections).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Section>().HasKey(s => new { s.Id, s.TabName });
            modelBuilder.Entity<Section>().HasData(
                new Section
                {
                    TabName = "Terminal",
                    Index = 0,
                    Id = "terminal-introduction",
                    Header = "Introduction",
                    HasMainContent = true,
                },
                new Section
                {
                    TabName = "Terminal",
                    Index = 1,
                    Id = "terminal-setup",
                    Header = "Getting Started",
                    HasMainContent = false,
                },
                new Section
                {
                    TabName = "Terminal",
                    Index = 2,
                    Id = "terminal-usage",
                    Header = "Usage",
                    HasMainContent = false,

                },
                new Section
                {
                    TabName = "Scripts",
                    Index = 0,
                    Id = "scripts-introduction",
                    Header = "Introduction",
                    HasMainContent = true,
                },
                new Section
                {
                    TabName = "Scripts",
                    Index = 1,
                    Id = "scripts-terminal",
                    HasMainContent = true,
                    Header = "Terminal Extensions",

                },
                new Section
                {
                    TabName = "Scripts",
                    Index = 2,
                    Id = "scripts-ohmyposh",
                    Header = "1) Oh My Posh & Nerd Fonts",
                },
                new Section
                {
                    TabName = "Scripts",
                    Index = 3,
                    Id = "scripts-winterm",
                    Header = "2) Windows Terminal by Microsoft",

                },
                new Section
                {
                    TabName = "Scripts",
                    Index = 4,
                    Id = "scripts-poshgit",
                    Header = "3) Posh Git",
                },
                new Section
                {
                    TabName = "Scripts",
                    Index = 5,
                    Id = "scripts-shell",
                    Header = "Shell Modifications",
                    HasMainContent = true,
                },
                new Section
                {
                    TabName = "Scripts",
                    Index = 6,
                    Id = "scripts-wsl",
                    Header = "1) SindaDistro",
                   
                },
                new Section
                {
                    TabName = "Scripts",
                    Index = 7,
                    Id = "scripts-virtual",
                    Header = "Virtualization Software",
                    HasMainContent = true,
                },
                new Section
                {
                    TabName = "Scripts",
                    Index = 8,
                    Id = "scripts-docker",
                    Header = "1) Docker Desktop with WSL2 Backend",
                },
                new Section
                {
                    TabName = "Scripts",
                    Index = 9,
                    Id = "scripts-podman",
                    Header = "2) Podman",
                },
                new Section
                {
                    TabName = "Scripts",
                    Index = 10,
                    Id = "scripts-sdk",
                    Header = "SDK & Internal Tooling",
                    HasMainContent = true,
                },
                new Section
                {
                    TabName = "Scripts",
                    Index = 11,
                    Id = "scripts-sindamodule",
                    Header = "1) Sinda Developer Tools",
                },
                new Section
                {
                    TabName = "Scripts",
                    Index = 12,
                    Id = "scripts-boilerplate",
                    Header = "Boilerplates & Codebases",
                    HasMainContent = true,
                },
                new Section
                {
                    TabName = "Scripts",
                    Index = 13,
                    Id = "scripts-portfolio",
                    Header = "1) Sinda Portfolio",
                },
                new Section
                {
                    TabName = "Boilerplate",
                    Index = 0,
                    Id = "boilerplate-introduction",
                    Header = "Introduction",
                    HasMainContent = true,
                },
                new Section
                {
                    TabName = "Boilerplate",
                    Index = 1,
                    Id = "boilerplate-portfolio",
                    Header = "1) Sinda Portfolio",
                },
                new Section
                {
                    TabName = "Boilerplate",
                    Index = 2,
                    Id = "boilerplate-portfolio-setup",
                    Header = "Setting up the repository",
                },
                new Section
                {
                    TabName = "Boilerplate",
                    Index = 3,
                    Id = "boilerplate-portfolio-hero",
                    Header = "Changing the hero section content",
                    
                },
                new Section
                {
                    TabName = "Boilerplate",
                    Index = 4,
                    Id = "boilerplate-portfolio-body",
                    Header = "Changing the body section contents",
                
                }
            );
            modelBuilder.Entity<HTMLContent>()
                .HasDiscriminator<int>("content_type")
                .HasValue<HTMLContent>(1)
                .HasValue<LinkContent>(2)
                .HasValue<WarningContent>(3)
                .HasValue<CodeContent>(4)
                .HasValue<PictureSourceContent>(5)
                .HasValue<ImageContent>(6);
            modelBuilder.Entity<HTMLContent>().HasOne(c => c.Detail).WithMany(d => d.Contents).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<HTMLContent>().HasKey(c => new { c.Id, c.DetailId });

            modelBuilder.Entity<HTMLContent>().HasData(
                new HTMLContent { Id=1, DetailId=1, Value = "Sindagal " },
                new HTMLContent { Id=3, DetailId=1, Value = " is a simple Node.js application which makes use of the popular JavaScript framework React. The goal is to make developer lives more convenient by wrapping around operating system level scripts and allowing their easy consumption." },
                new HTMLContent { Id=5, DetailId=3, Value = "On this page, you'll learn what the Sinda Command Line Interface brings to the table and how it can be consumed by setting it up from scratch and consuming some of the built in automation scripts on a Windows machine." },
                new HTMLContent { Id = 6, DetailId = 4, Value = "The project requires Node.js LTS and npm to be installed as a pre-requisite so if you do not already have them, now is a good time to set them up." },
                new HTMLContent { Id = 8, DetailId = 4, Value = "by Microsoft demonstrates how they could be set on a Windows machine using the Node Version Manager tool (NVM)." },
                new HTMLContent { Id = 9, DetailId = 5, Value = "Once NVM & Node.js are configured, we could proceed to cloning the repository and running the app from the cloned source code. Its necessary to fork and/or clone the repository since the app itself requires access to the localhost machine so it can run powershell/bash scripts." },
                new HTMLContent { Id = 13, DetailId = 9, Value = "The app requires administrator rights to run Powershell / Bash scripts on localhost, if its run from a non-elevated terminal session, it will result in an error and not run." },
                new HTMLContent { Id = 14, DetailId = 10, Value = "The following image demonstrates the landing page for a successfully started CLI." },
                new HTMLContent { Id = 18, DetailId = 12, Value = "Consuming scripts from the app is pretty straight forward and takes only a few key-presses to achieve. As seen on the landing page image, the terminal prompt functions similarly to a single page app and the visible part of the terminal is hijacked by a" },
                new HTMLContent { Id = 20, DetailId = 12, Value = "Component" },
                new HTMLContent { Id = 21, DetailId = 13, Value = "The component itself detects the screen height and width and resizes accordingly. Having said that, a maximized terminal window is recommended for the best experience and the resizing  feature is only meant for the application startup. If the terminal window gets resized while the app is running, there are no guarantees for correct rendering of the component." },
                new HTMLContent { Id = 22, DetailId = 14, Value = "Once a key is pressed on the landing page, the survey component is rendered and the user is presented with all the available automation scripts... Navigation of the form is achieved through the <i>Up / Down / Enter & Esc </i> keys. This component is demonstrated in the following image." },
                new HTMLContent { Id = 26, DetailId = 16, Value = "For the sake of this tutorial, we are only going to be selecting the first three options. Once the selections are made, it is required to navigate to the last page of the survey and confirm the selections.  The \"proceed\" button will ask for a re-confirmation and esc key could be used to go back to the form." },
                new HTMLContent { Id = 30, DetailId = 18, Value = "Prior to making any changes to the machine, all the selected features and their corresponding scripts are listed and a confirmation is requested once more for extra safety." },
                new HTMLContent { Id = 34, DetailId = 20, Value = "For the time being, the scripts are executed syncronously and the results within the box are updated all at once." },
                new HTMLContent { Id = 35, DetailId = 21, Value = "The Standard Outputs as well as Errors for the executed commands are pushed above the component box in real-time. A finished session is demonstrated in the below image." },
                new HTMLContent { Id = 39, DetailId = 23, Value = "Thats all folks! See how easy it was to consume some powershell scripts? To see the full list of the existing scripts, please navigate to the scripts tab on this page." },
                new HTMLContent { Id = 40, DetailId = 24, Value = "As described in the Terminal tab, Sindagal comes with some built-in scripts and can also be extended to interface to personal scripts. The scripts are categorized as Terminal, Shell, Virtual, SDK & Boilerplate." },
                new HTMLContent { Id = 41, DetailId = 24, Value = " The CLI tool works by executing powershell / bash scripts which exist inside the code repository itself under the src/scripts directory." },
                new HTMLContent { Id = 42, DetailId = 25, Value = " On this page, we will be exploring the various details regarding those features and why they might come in handy for you or your organisation." },
                new HTMLContent { Id = 43, DetailId = 26, Value = "For the time being, everything is in the Minimum Viable Product stage & things might change in the future. Please report any problems or bugs to me personally through my " },
                new HTMLContent { Id = 45, DetailId = 26, Value = " Pull requests are welcome at the " },
                new HTMLContent { Id = 47, DetailId = 27, Value = "This category is where the scripts regarding the interactive terminal session reside. These will alter the look & feel of your interactions with your local shell." },
                new HTMLContent { Id = 48, DetailId = 28, Value = "By default, terminal prompts on Windows machines come with no support for user themes, lack descriptiveness and are not intuitive to use. Wouldn't it be nice if the sessions could be personalized & extended with additional information such as the time of command execution, git active branch names, battery level and more?" },
                new HTMLContent { Id = 49, DetailId = 28, Value = " Enter " },
                new HTMLContent { Id = 51, DetailId = 28, Value = " A shell framework for doing all of that! Historically this worked only on Windows but with Powershell going cross platform, it now works on Linux & Mac as well. " },
                new HTMLContent { Id = 52, DetailId = 29, Value = "The framework is easily configurable... All available themes could be reviewed by: " },
                new HTMLContent { Id = 54, DetailId = 31, Value = "changing the theme to \"Darkblood\": " },
                new HTMLContent { Id = 56, DetailId = 33, Value = "Having said that, it is also possible to configure it via code by adjusting an init script at a location which can be found from the Get-PoshThemes command. " },
                new HTMLContent { Id = 57, DetailId = 34, Value = "Oh My Posh relies on a specific font family in order to display its many glyphs properly, Sinda takes care of installing the " },
                new HTMLContent { Id = 59, DetailId = 34, Value = " for you!" },
                new HTMLContent { Id = 60, DetailId = 35, Value = "The default Powershell / Command Prompt & WSL terminal apps are some-what primitive, those emulators damage productivity. They are difficult to impossible to standardize, they require switching between windows which can get tedious & confusing from time to time and they lack certain features when it comes to keyboard shortcuts." },
                new HTMLContent { Id = 62, DetailId = 35, Value = " intends to remedy the above problems by allowing multiple tabs, split screens, extensive keyboard macros and multi-shell support." },
                new HTMLContent { Id = 63, DetailId = 35, Value = " Tabs could contain any session ranging from Azure, WSL2, Remote SSH, Powershell & CMD!" },
                new HTMLContent { Id = 64, DetailId = 35, Value = " This powerful open source tool also allows launching sessions programatically through powershell commands." },
                new HTMLContent { Id = 65, DetailId = 36, Value = "To start WSL Debian & Powershell sessions programatically: " },
                new HTMLContent { Id = 67, DetailId = 38, Value = "Results in the following interactive sessions:" },
                new HTMLContent { Id = 71, DetailId = 40, Value = "As always, the stock functionality with Windows is lacked and this time its with Git on Powershell & Command Prompt... " },
                new HTMLContent { Id = 73, DetailId = 41, Value = "a powershell module, once imported, allows auto completion for all git commands. This makes life easier as less typing is required to navigate daily tasks." },
                new HTMLContent { Id = 74, DetailId = 42, Value = "The Shell category harbours everything which will alter the installed shell(s) themselves such as changing default powershell versions or installing WSL on localhost etc." },
                new HTMLContent { Id = 75, DetailId = 43, Value = "This is a pre configured WSL2 instance which had been exported and put online for easy consumption." },
                new HTMLContent { Id = 76, DetailId = 43, Value = " The purpose of this is to encapsulate basic linux setup and provide a ready developer environment for common tasks." },
                new HTMLContent { Id = 77, DetailId = 43, Value = " It comes with " },
                new HTMLContent { Id = 79, DetailId = 43, Value = " as well as " },
                new HTMLContent { Id = 81, DetailId = 43, Value = " Zsh is the default shell which OSX systems are shipped with and OhMyZsh is a framework for adding magic to it!" },
                new HTMLContent { Id = 82, DetailId = 44, Value = "The features & plugins are not limited to the ones demonstrated below!" },
                new HTMLContent { Id = 83, DetailId = 45, Value = "Themes could be configured on Oh My Zsh and all the themes which exist for Oh My Posh also exist for Oh My Zsh if not more! all existing " },
                new HTMLContent { Id = 85, DetailId = 45, Value = "could be found in the given link! " },
                new HTMLContent { Id = 86, DetailId = 45, Value = " The Sinda Ubuntu comes with the theme \"agnoster\" but this can easily be changed by amending the .zshrc file." },
                new HTMLContent { Id = 87, DetailId = 46, Value = "First look on the .zshrc file:" },
                new HTMLContent { Id = 90, DetailId = 48, Value = "As shown in the image above, Oh My Zsh can be configured with many " },
                new HTMLContent { Id = 92, DetailId = 48, Value = " plugins which make life convenient! The Sinda Ubuntu comes with the git, debian, alias-finder, docker, command-not-found, thefuck & docker." },
                new HTMLContent { Id = 93, DetailId = 48, Value = " These of course can be changed by editing the plugins array. Below are some images demonstrating the Zsh & Oh My Zsh features further!" },
                new HTMLContent { Id = 94, DetailId = 49, Value = "Thefuck:" },
                new HTMLContent { Id = 97, DetailId = 51, Value = "Git branch display:" },
                new HTMLContent { Id = 100, DetailId = 53, Value = "Auto complete & switch on tab key:" },
                new HTMLContent { Id = 103, DetailId = 55, Value = "Autocorrect:" },
                new HTMLContent { Id = 105, DetailId = 57, Value = "Alias finder:" },
                new HTMLContent { Id = 108, DetailId = 59, Value = "Command not found:" },
                new HTMLContent { Id = 111, DetailId = 61, Value = "The Virtualization category includes scripts for installing toolsets & software such as Docker / Podman which make it easier to consume / ship software by professionals." },
                new HTMLContent { Id = 112, DetailId = 62, Value = "This installs " },
                new HTMLContent { Id = 114, DetailId = 62, Value = " with the WSL2 backend through the chocolatey package manager. Historically very difficult to achieve but today its not even a few lines of code, what a time to be alive!" },
                new HTMLContent { Id = 115, DetailId = 63, Value = "Much like Docker, " },
                new HTMLContent { Id = 117, DetailId = 63, Value = " is a software for managing OCI Containers, this installation is provided as an alternative for the ones who prefer it instead of Docker." },
                new HTMLContent { Id = 118, DetailId = 64, Value = "The scripts under this section are all about giving developers more power by making internal Sinda tools available. The tools function as encapsulation on certain tasks into one liners." },
                new HTMLContent { Id = 119, DetailId = 65, Value = "This is a Powershell module & an exact copy of the internal scripts used with the CLI tool wrapped in an easily importable format." },
                new HTMLContent { Id = 120, DetailId = 65, Value = "the command imports the module located at src/script/Sindagal.psm1 into the powershell profile of the user using the machine" },
                new HTMLContent { Id = 121, DetailId = 65, Value = "Once the module is imported, the developer gains direct access to all the features included in the CLI & more through direct powershell commands!" },
                new HTMLContent { Id = 122, DetailId = 66, Value = "All the commands could be inspected in the file location mentioned within the CLI repository, however some of them are explained below." },
                new HTMLContent { Id = 123, DetailId = 67, Value = "To check the current state of your system for things such as os version, architecture, wsl2 support etc: " },
                new HTMLContent { Id = 125, DetailId = 69, Value = "To install WSL on legacy systems where WSL2 or wsl --install command are not supported " },
                new HTMLContent { Id = 127, DetailId = 71, Value = "To download & import the Sinda pre configured wsl2 instance:" },
                new HTMLContent { Id = 129, DetailId = 73, Value = "Check if terminal session has admin rights:" },
                new HTMLContent { Id = 131, DetailId = 75, Value = "Install & Configure Windows Terminal with Nerd Fonts:" },
                new HTMLContent { Id = 133, DetailId = 77, Value = "Disable & delete Windows Terminal:" },
                new HTMLContent { Id = 135, DetailId = 79, Value = "And many more!" },
                new HTMLContent { Id = 136, DetailId = 80, Value = "The Boilerplate section contains scripts which clone Ready to go Sinda Codebases from github. The repositories are intended to solve common problems & be as easily personalized as possible." },
                new HTMLContent { Id = 137, DetailId = 81, Value = "This clones a reusable & extensible web portfolio template written with React using the NextJS framework. The repository could be found " },
                new HTMLContent { Id = 139, DetailId = 81, Value = "This simplistic portfolio itself has basic SEO optimizations, keyboard and developer accessibility; a performant " },
                new HTMLContent { Id = 141, DetailId = 81, Value = " score as well as good responsive UI/UX principles!" },
                new HTMLContent { Id = 142, DetailId = 81, Value = " Feel free to change the data & reupload it to your favourite version-control website as you please!" },
                new HTMLContent { Id = 143, DetailId = 82, Value = "For more information regarding this template & web theme, please refer to the Boilerplate tab on this page." },
                new HTMLContent { Id = 144, DetailId = 83, Value = "Do you have some boilerplate code which you always have to write from scratch? Are you in a hurry to get up and running with an MVP?" },
                new HTMLContent { Id = 145, DetailId = 83, Value = " Sindagal Boilerplates will come to your rescue!" },
                new HTMLContent { Id = 146, DetailId = 83, Value = " On this page, we will be exploring how to set up and work with existing code as well as how to extend them to our needs to save time from cumbersome work!" },
                new HTMLContent { Id = 145, DetailId = 84, Value = "Planning to look for that next challange in your career but do not have time to fiddle with UI/UX or write the code for a portfolio website from scratch?" },
                new HTMLContent { Id = 146, DetailId = 84, Value = " You can now rest easy with this " },
                new HTMLContent { Id = 148, DetailId = 84, Value = " This template simplistic enough to do the job and will hit the spot with its SEO optimizations, keyboard and developer accessibility; a performant " },
                new HTMLContent { Id = 150, DetailId = 84, Value = " score as well as good responsive UI/UX principles!" },
                new HTMLContent { Id = 151, DetailId = 84, Value = " please find a live example at" },
                new HTMLContent { Id = 153, DetailId = 85, Value = "This is a NextJS TypeScript project so NodeJS & npm are required as a prerequisite." },
                new HTMLContent { Id = 154, DetailId = 85, Value = "If those already exist on the machine or if you are using the pre configured WSL instance, its okay to proceed to cloning the repository." },
                new HTMLContent { Id = 156, DetailId = 87, Value = "Install Nextjs globally:" },
                new HTMLContent { Id = 158, DetailId = 89, Value = "Move into the repository, install dependencies and run the app:" },
                new HTMLContent { Id = 158, DetailId = 93, Value = "If everything went well, it's now okay to visit localhost:3000 in your favourite browser to see the site!" },
                new HTMLContent { Id = 162, DetailId = 95, Value = "Not bad! In order to personalize it, we need to make a few tweaks." },
                new HTMLContent { Id = 163, DetailId = 95, Value = " The data is pulled into a single class at " },
                new HTMLContent { Id = 165, DetailId = 95, Value = " class for the most part and this is where we will spend most of our time." },
                new HTMLContent { Id = 166, DetailId = 95, Value = " having said that, the page title and the meta tags for SEO as well as canonical must also be changed for a fully personalized portfolio. In a NextJS project, these are stored in " },
                new HTMLContent { Id = 168, DetailId = 95, Value = " as per convention. It is planned to pull these into the data folder in the future as well!" },
                new HTMLContent { Id = 169, DetailId = 96, Value = "Let's view the code in our favourite code editor and see how to go about the modifications!" },
                new HTMLContent { Id = 171, DetailId = 98, Value = "To start things off, lets change the navigation bar contents by changing the ProjectOwner, PersonalURLs & PersonalBackground Objects as shown." },
                new HTMLContent { Id = 175, DetailId = 100, Value = " Icons for social media could be changed by supplying a name from the " },
                new HTMLContent { Id = 177, DetailId = 100, Value = " Icons. Additional navigation links such as \"instagram\" could also be added or removed if desired by altering the keys on the" },
                new HTMLContent { Id = 179, DetailId = 100, Value = " class further. For demonstration purposes, lets remove the email icon while changing the other two icons." },
                new HTMLContent { Id = 183, DetailId = 102, Value = " The keys on the object " },
                new HTMLContent { Id = 185, DetailId = 102, Value = " are used to generate the sections below the hero section. If we wanted to add or remove or alter a section, all we would need to do is to alter the keys on it!" },
                new HTMLContent { Id = 186, DetailId = 102, Value = " for the sake of this tutorial, let's remove the hobbies section and rename some of the others!" },
                new HTMLContent { Id = 190, DetailId = 104, Value = " Now that those are out of the way, its a good time to change the background and the headshot images which are located inside the " },
                new HTMLContent { Id = 192, DetailId = 104, Value = " directory, all that is required is to drop in the images in that directory and reference them inside the data class. The app is written flexible enough to allow the usage of different image names as-well!" },
                new HTMLContent { Id = 195, DetailId = 106, Value = "We've come a long way and the results are just beautiful! Refresh the browser page to see that the website now looks like this: " },
                new HTMLContent { Id = 199, DetailId = 107, Value = "How about the body sections? Are they even flexible enough for personalization? They sure are! All that needs to be done is to alter the methods which are being called within the \"PersonalBackground\" method inside the data class." },
                new HTMLContent { Id = 200, DetailId = 108, Value = " The heading, date range & inner content are supplied within the same place, the inner content could be made bold, italic or emphasized on demand without touching any HTML." },
                new HTMLContent { Id = 201, DetailId = 109, Value = " If it's a semantic markup for your website which you are looking for; you can add emphasis and other things to certain text but also keep it unstyled." },
                new HTMLContent { Id = 202, DetailId = 109, Value = " This is a good idea if you would like your website to read well by screen readers so elements could be emphesized without changing the visual feeling..." },
                new HTMLContent { Id = 203, DetailId = 109, Value = " The body elements could be given captions aswell by assigning the \"caption\" field a string value." },
                new HTMLContent { Id = 204, DetailId = 110, Value = "Example body section element code:" },
                new HTMLContent { Id = 207, DetailId = 112, Value = "Only one thing remains, changing the meta content of the site! And this is as easy as going into the pages/_document.tsx" },
                new HTMLContent { Id = 209, DetailId = 112, Value = " file and altering the given strings." },
                new HTMLContent { Id = 210, DetailId = 112, Value = " add in the full address of your domain as a canonical, change the tab title as you wish and amend the keywords to cater to your target audiences google searches." },
                new HTMLContent { Id = 211, DetailId = 113, Value = "That is all! Enjoy your Sinda Portfolio and do not forget to give a star or send your pull requests!" },
                new HTMLContent { Id = 212, DetailId = 113, Value = " We will not be touching on how to deploy this website since it is using the stock CI/CD which is provided by Vercel for free on personal projects." },
                new HTMLContent { Id = 213, DetailId = 113, Value = " To find out more about deployments, visit their tutorials at " }
                );
            
            modelBuilder.Entity<LinkContent>().HasData(
                new LinkContent { Id = 2, DetailId = 1, Value = "Command Line Interface", Href = "https://github.com/denzii/sinda-cli" },
                new LinkContent { Id = 7, DetailId = 4, Value = "This tutorial", Href = "https://docs.microsoft.com/en-us/windows/dev-environment/javascript/nodejs-on-windows" },
                new LinkContent { Id = 19, DetailId = 12, Value = "React Ink", Href = "https://github.com/vadimdemedes/ink" },
                new LinkContent { Id = 44, DetailId = 26, Value = "Linkedin.", Href = "https://www.linkedin.com/in/denizarca/" },
                new LinkContent { Id = 46, DetailId = 26, Value = "CLI repository.", Href = "https://github.com/denzii/sinda-cli" },
                new LinkContent { Id = 50, DetailId = 28, Value = "Oh My Posh!", Href = "https://ohmyposh.dev/" },
                new LinkContent { Id = 58, DetailId = 34, Value = "Nerd Fonts", Href = "https://github.com/ryanoasis/nerd-fonts" },
                new LinkContent { Id = 61, DetailId = 35, Value = "Windows Terminal", Href = "https://docs.microsoft.com/en-us/windows/terminal/" },
                new LinkContent { Id = 72, DetailId = 41, Value = "PoshGit", Href = "https://github.com/dahlbyk/posh-git" },
                new LinkContent { Id = 78, DetailId = 43, Value = "Zsh", Href = "https://www.zsh.org/" },
                new LinkContent { Id = 80, DetailId = 43, Value = "Oh My Zsh.", Href = "https://ohmyz.sh/" },
                new LinkContent { Id = 84, DetailId = 45, Value = "Oh My Zsh Themes", Href = "https://github.com/ohmyzsh/ohmyzsh/wiki/Themes" },
                new LinkContent { Id = 91, DetailId = 48, Value = "plugins,", Href = "https://github.com/ohmyzsh/ohmyzsh/wiki/Plugins" },
                new LinkContent { Id = 113, DetailId = 62, Value = "Docker Desktop", Href = "https://www.docker.com/products/docker-desktop" },
                new LinkContent { Id = 116, DetailId = 63, Value = "Podman", Href = "https://podman.io/" },
                new LinkContent { Id = 138, DetailId = 81, Value = "here.", Href = "https://github.com/denzii/sinda-portfolio" },
                new LinkContent { Id = 140, DetailId = 81, Value = "Chrome Lighthouse", Href = "https://developers.google.com/web/tools/lighthouse" },
                new LinkContent { Id = 147, DetailId = 84, Value = "web portfolio.", Href = "https://github.com/denzii/sinda-portfolio" },
                new LinkContent { Id = 149, DetailId = 84, Value = "Lighthouse", Href = "https://developers.google.com/web/tools/lighthouse" },
                new LinkContent { Id = 152, DetailId = 84, Value = "denizarca.com", Href = "https://denizarca.com" },
                new LinkContent { Id = 164, DetailId = 95, Value = "data/index.ts", Href = "https://github.com/denzii/sinda-portfolio/blob/main/data/index.ts" },
                new LinkContent { Id = 167, DetailId = 95, Value = "pages/_document.tsx", Href = "https://github.com/denzii/sinda-portfolio/blob/main/pages/_document.tsx" },
                new LinkContent { Id = 176, DetailId = 100, Value = "React Font Awesome", Href = "https://react-icons.github.io/react-icons/icons?name=fa" },
                new LinkContent { Id = 178, DetailId = 100, Value = "interface/personalUrls.ts", Href = "https://github.com/denzii/sinda-portfolio/blob/main/interface/personalUrls.ts" },
                new LinkContent { Id = 184, DetailId = 102, Value = "interface/background.ts", Href = "https://github.com/denzii/sinda-portfolio/blob/main/interface/background.ts" },
                new LinkContent { Id = 191, DetailId = 104, Value = "public", Href = "https://github.com/denzii/sinda-portfolio/tree/main/public" },
                new LinkContent { Id = 208, DetailId = 112, Value = "pages/_document.tsx", Href = "https://github.com/denzii/sinda-portfolio/tree/main/public" },
                new LinkContent { Id = 214, DetailId = 113, Value = "nextjs.org/deployment", Href = "https://nextjs.org/docs/deployment" }
           );

            modelBuilder.Entity<WarningContent>().HasData(
                new WarningContent { Id=4, DetailId = 2, Value = "For the time being, usages from within WSL & Unix based systems had been disabled." }
                
            );

            modelBuilder.Entity<CodeContent>().HasData(
                new CodeContent { Id = 10, DetailId = 6, Language = "shell", Value = "git clone https://github.com/denzii/sinda-cli.git" },
                new CodeContent { Id = 12, DetailId = 8, Language = "shell", Value = "npm start" },
                new CodeContent { Id = 11, DetailId = 7, Language = "shell", Value = "cd sinda-cli" },
                new CodeContent { Id = 53, DetailId = 30, Language = "shell", Value = "Get-PoshThemes" },
                new CodeContent { Id = 55, DetailId = 32, Language = "shell", Value = "Set-PoshPrompt darkblood" },
                new CodeContent { Id = 66, DetailId = 37, Language = "shell", Value = "wt -p \"Debian\" `; split-pane -p \"Windows PowerShell\" `;" },
                new CodeContent { Id = 124, DetailId = 68, Language = "shell", Value = "Get-EnvState" },
                new CodeContent { Id = 126, DetailId = 70, Language = "shell", Value = "Enable-WSLLegacy" },
                new CodeContent { Id = 128, DetailId = 72, Language = "shell", Value = "Add-SindaDistro" },
                new CodeContent { Id = 130, DetailId = 74, Language = "shell", Value = "Test-Elevation" },
                new CodeContent { Id = 132, DetailId = 76, Language = "shell", Value = "Enable-WindowsTerminal" },
                new CodeContent { Id = 134, DetailId = 78, Language = "shell", Value = "Disable-WindowsTerminal" },
                new CodeContent { Id = 155, DetailId = 86, Language = "shell", Value = "git clone https://github.com/denzii/sinda-portfolio.git" },
                new CodeContent { Id = 157, DetailId = 88, Language = "shell", Value = "npm i -g next" },
                new CodeContent { Id = 159, DetailId = 90, Language = "shell", Value = "cd sinda-portfolio" },
                new CodeContent { Id = 156, DetailId = 91, Language = "shell", Value = "npm install" },
                new CodeContent { Id = 157, DetailId = 92, Language = "shell", Value = "npm run dev" },
                new CodeContent { Id = 170, DetailId = 97, Language = "shell", Value = "code ." }
            );

            modelBuilder.Entity<PictureSourceContent>().HasData(
                 new PictureSourceContent { Id = 15, DetailId = 11, Srcset = "./img/cli-landing-page-850w.png", Media = "(max-width: 950px)" },
                 new PictureSourceContent { Id = 16, DetailId = 11, Srcset = "./img/cli-landing-page.png" },
                 new PictureSourceContent { Id = 23, DetailId = 15, Srcset = "./img/cli-survey-page-850w.png", Media = "(max-width: 950px)" },
                 new PictureSourceContent { Id = 24, DetailId = 15, Srcset = "./img/cli-survey-page.png" },
                 new PictureSourceContent { Id = 27, DetailId = 17, Srcset = "./img/cli-survey-page-confirmation-850w.png", Media = "(max-width: 950px)" },
                 new PictureSourceContent { Id = 28, DetailId = 17, Srcset = "./img/cli-survey-page-confirmation.png" },
                 new PictureSourceContent { Id = 31, DetailId = 19, Srcset = "./img/cli-survey-page-confirmation-2-850w.png", Media = "(max-width: 950px)" },
                 new PictureSourceContent { Id = 32, DetailId = 19, Srcset = "./img/cli-survey-page-confirmation-2.png" },
                 new PictureSourceContent { Id = 36, DetailId = 22, Srcset = "./img/cli-survey-page-results-850w.png", Media = "(max-width: 950px)" },
                 new PictureSourceContent { Id = 37, DetailId = 22, Srcset = "./img/cli-survey-page-results.png" },
                 new PictureSourceContent { Id = 68, DetailId = 39, Srcset = "./img/winterm-850w.png", Media = "(max-width: 950px)" },
                 new PictureSourceContent { Id = 69, DetailId = 39, Srcset = "./img/winterm.png" },
                 new PictureSourceContent { Id = 88, DetailId = 47, Srcset = "./img/zsh-rc.png" },
                 new PictureSourceContent { Id = 95, DetailId = 50, Srcset = "./img/zsh-thefuck.png" },
                 new PictureSourceContent { Id = 98, DetailId = 52, Srcset = "./img/zsh-git-branch.png" },
                 new PictureSourceContent { Id = 101, DetailId = 54, Srcset = "./img/zsh-tab-switch.png" },
                 new PictureSourceContent { Id = 215, DetailId = 56, Srcset = "./img/zsh-autocorrect.png" },
                 new PictureSourceContent { Id = 106, DetailId = 58, Srcset = "./img/zsh-alias-finder.png" },
                 new PictureSourceContent { Id = 109, DetailId = 60, Srcset = "./img/zsh-command-not-found.png" },
                 new PictureSourceContent { Id = 159, DetailId = 94, Srcset = "./img/portfolio-landing-page-850w.png", Media = "(max-width: 950px)" },
                 new PictureSourceContent { Id = 160, DetailId = 94, Srcset = "./img/portfolio-landing-page.png" },
                 new PictureSourceContent { Id = 172, DetailId = 99, Srcset = "./img/portfolio-navbar-name-diff-850w.png", Media = "(max-width: 950px)" },
                 new PictureSourceContent { Id = 173, DetailId = 99, Srcset = "./img/portfolio-navbar-name-diff.png", },
                 new PictureSourceContent { Id = 180, DetailId = 101, Srcset = "./img/portfolio-socialbar-diff-850w.png", Media = "(max-width: 950px)" },
                 new PictureSourceContent { Id = 181, DetailId = 101, Srcset = "./img/portfolio-socialbar-diff.png", },
                 new PictureSourceContent { Id = 187, DetailId = 103, Srcset = "./img/portfolio-navbar-elems-diff-850w.png", Media = "(max-width: 950px)" },
                 new PictureSourceContent { Id = 188, DetailId = 103, Srcset = "./img/portfolio-navbar-elems-diff.png", },
                 new PictureSourceContent { Id = 193, DetailId = 105, Srcset = "./img/portfolio-hero-diff.png", },
                 new PictureSourceContent { Id = 196, DetailId = 107, Srcset = "./img/portfolio-altered-hero-diff-850w.png", Media = "(max-width: 950px)" },
                 new PictureSourceContent { Id = 197, DetailId = 107, Srcset = "./img/portfolio-altered-hero-diff.png", },
                 new PictureSourceContent { Id = 205, DetailId = 111, Srcset = "./img/portfolio-body-code.png", Media = "(max-width: 950px)" }
            );
            modelBuilder.Entity<ImageContent>().HasData(
                 new ImageContent { Id = 17, DetailId = 11, Src = "./img/cli-landing-page.png", Alt = "CLI Landing Page" },
                 new ImageContent { Id = 25, DetailId = 15, Src = "./img/cli-survey-page.png", Alt = "CLI Survey Page" },
                 new ImageContent { Id = 29, DetailId = 17, Src = "./img/cli-survey-page-confirmation.png", Alt = "CLI Survey Page Confirmation" },
                 new ImageContent { Id = 33, DetailId = 19, Src = "./img/cli-survey-page-confirmation-2.png", Alt = "CLI Survey Page Finalization" },
                 new ImageContent { Id = 38, DetailId = 22, Src = "./img/cli-survey-page-results.png", Alt = "CLI Survey Page Results" },
                 new ImageContent { Id = 70, DetailId = 39, Src = "./img/winterm", Alt = "CLI Landing Page" },
                 new ImageContent { Id = 89, DetailId = 47, Src = "./img/zsh-rc.png", Alt = "First look on .zshrc file" },
                 new ImageContent { Id = 96, DetailId = 50, Src = "./img/zsh-thefuck.png", Alt = "Thefuck demo" },
                 new ImageContent { Id = 99, DetailId = 52, Src = "./img/zsh-git-branch.png", Alt = "git branch display demo" },
                 new ImageContent { Id = 102, DetailId = 54, Src = "./img/zsh-tab-switch.png", Alt = "auto complete  demo" },
                 new ImageContent { Id = 104, DetailId = 56, Src = "./img/zsh-autocorrect.png", Alt = "auto correction demo" },
                 new ImageContent { Id = 107, DetailId = 58, Src = "./img/zsh-alias-finder.png", Alt = "alias finder demo" },
                 new ImageContent { Id = 110, DetailId = 60, Src = "./img/zsh-command-not-found.png", Alt = "command not found demo" },
                 new ImageContent { Id = 161, DetailId = 94, Src = "./img/portfolio-landing-page.png", Alt = "Portfolio Landing Page" },
                 new ImageContent { Id = 174, DetailId = 99, Src = "./img/portfolio-navbar-name-diff.png", Alt = "Portfolio Navbar modification" },
                 new ImageContent { Id = 182, DetailId = 101, Src = "./img/portfolio-socialbar-diff.png", Alt = "Portfolio Socialbar modification" },
                 new ImageContent { Id = 189, DetailId = 103, Src = "./img/portfolio-navbar-elems-diff.png", Alt = "Portfolio Navbar elements modification" },
                 new ImageContent { Id = 194, DetailId = 105, Src = "./img/portfolio-hero-diff.png", Alt = "Portfolio hero images modification" },
                 new ImageContent { Id = 198, DetailId = 107, Src = "./img/portfolio-altered-hero-diff.png", Alt = "Portfolio altered hero section" },
                 new ImageContent { Id = 206, DetailId = 111, Src = "./img/portfolio-body-code.png", Alt = "Portfolio body code example" }
            );
            
            modelBuilder.Entity<Detail>().HasMany(d => d.Contents).WithOne(c => c.Detail).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Detail>().HasOne(d => d.Section).WithMany(s => s.Details).HasPrincipalKey(s => s.Id);
            modelBuilder.Entity<Detail>().HasData(
                new Detail
                {
                    Id = 1,
                    SectionId = "terminal-introduction",
                },
                new Detail
                {
                    Id = 2,
                    SectionId = "terminal-introduction"
                },
                new Detail
                {
                    Id = 3,
                    SectionId = "terminal-introduction"
                },
                new Detail
                {
                    Id = 4,
                    SectionId = "terminal-setup",
                    Type = ContentType.Paragraph,

                },
                new Detail
                {
                    Id = 5,
                    SectionId = "terminal-setup",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 6,
                    SectionId = "terminal-setup",
                    Type = ContentType.Code,
                },
                new Detail
                {
                    Id = 7,
                    SectionId = "terminal-setup",
                    Type = ContentType.Code,
                },
                new Detail
                {
                    Id = 8,
                    SectionId = "terminal-setup",
                    Type = ContentType.Code,
                },
                new Detail
                {
                    Id = 9,
                    SectionId = "terminal-setup",
                    Type = ContentType.Warning,
                },
                new Detail
                {
                    Id = 10,
                    SectionId = "terminal-setup",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 11,
                    SectionId = "terminal-setup",
                    Type = ContentType.Picture,
                },
                new Detail
                {
                    Id = 12,
                    SectionId = "terminal-usage",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 13,
                    SectionId = "terminal-usage",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 14,
                    SectionId = "terminal-usage",
                    Type = ContentType.Paragraph,
                },
                new Detail
                  {
                      Id = 15,
                      SectionId = "terminal-usage",
                      Type = ContentType.Picture,
                },
                new Detail
                 {
                     Id = 16,
                     SectionId = "terminal-usage",
                     Type = ContentType.Paragraph,
                },
                new Detail
                 {
                     Id = 17,
                     SectionId = "terminal-usage",
                     Type = ContentType.Picture,

                },
                new Detail
                 {
                     Id = 18,
                     SectionId = "terminal-usage",
                     Type = ContentType.Paragraph,
                },
                new Detail
                 {
                     Id = 19,
                     SectionId = "terminal-usage",
                     Type = ContentType.Picture,
                },
                new Detail
                 {
                     Id = 20,
                     SectionId = "terminal-usage",
                     Type = ContentType.Warning,
                },
                new Detail
                 {
                     Id = 21,
                     SectionId = "terminal-usage",
                     Type = ContentType.Paragraph,
                },
                new Detail
                 {
                     Id = 22,
                     SectionId = "terminal-usage",
                     Type = ContentType.Picture,
                },
                new Detail
                 {
                     Id = 23,
                     SectionId = "terminal-usage",
                     Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 24,
                    SectionId = "scripts-introduction",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 25,
                    SectionId = "scripts-introduction",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 26,
                    SectionId = "scripts-introduction",
                    Type = ContentType.Warning,
                },
                new Detail
                {
                    Id = 27,
                    SectionId = "scripts-terminal",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 28,
                    SectionId = "scripts-ohmyposh",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 29,
                    SectionId = "scripts-ohmyposh",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 30,
                    SectionId = "scripts-ohmyposh",
                    Type = ContentType.Code,
                },
                new Detail
                {
                    Id = 31,
                    SectionId = "scripts-ohmyposh",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 32,
                    SectionId = "scripts-ohmyposh",
                    Type = ContentType.Code,
                },
                new Detail
                {
                    Id = 33,
                    SectionId = "scripts-ohmyposh",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 34,
                    SectionId = "scripts-ohmyposh",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 35,
                    SectionId = "scripts-winterm",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 36,
                    SectionId = "scripts-winterm",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 37,
                    SectionId = "scripts-winterm",
                    Type = ContentType.Code,
                },
                new Detail
                {
                    Id = 38,
                    SectionId = "scripts-winterm",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 39,
                    SectionId = "scripts-winterm",
                    Type = ContentType.Picture,
                },
                new Detail
                {
                    Id = 40,
                    SectionId = "scripts-poshgit",
                    Type = ContentType.Paragraph,

                },
                new Detail
                {
                    Id = 41,
                    SectionId = "scripts-poshgit",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 42,
                    SectionId = "scripts-shell",
                    Type = ContentType.Paragraph,
                },
                new Detail
               {
                   Id = 43,
                   SectionId = "scripts-wsl",
                   Type = ContentType.Paragraph,
                },
                new Detail
              {
                  Id = 44,
                  SectionId = "scripts-wsl",
                  Type = ContentType.Warning,
                },
                new Detail
               {
                   Id = 45,
                   SectionId = "scripts-wsl",
                   Type = ContentType.Paragraph,
                },
                new Detail
               {
                   Id = 46,
                   SectionId = "scripts-wsl",
                   Type = ContentType.Paragraph,
                },
                new Detail
               {
                   Id = 47,
                   SectionId = "scripts-wsl",
                   Type = ContentType.Picture,
                },
                new Detail
               {
                   Id = 48,
                   SectionId = "scripts-wsl",
                   Type = ContentType.Paragraph,
                },
                new Detail
               {
                   Id = 49,
                   SectionId = "scripts-wsl",
                   Type = ContentType.Paragraph,
                },
                new Detail
               {
                   Id = 50,
                   SectionId = "scripts-wsl",
                   Type = ContentType.Picture,

                },
                new Detail
               {
                   Id = 51,
                   SectionId = "scripts-wsl",
                   Type = ContentType.Paragraph,

                },
                new Detail
               {
                   Id = 52,
                   SectionId = "scripts-wsl",
                   Type = ContentType.Picture,
                },
                new Detail
               {
                   Id = 53,
                   SectionId = "scripts-wsl",
                   Type = ContentType.Paragraph,
                },
                new Detail
               {
                   Id = 54,
                   SectionId = "scripts-wsl",
                   Type = ContentType.Picture,
                },
                new Detail
               {
                   Id = 55,
                   SectionId = "scripts-wsl",
                   Type = ContentType.Paragraph,
                },
                new Detail
               {
                   Id = 56,
                   SectionId = "scripts-wsl",
                   Type = ContentType.Picture,

                },
                new Detail
               {
                   Id = 57,
                   SectionId = "scripts-wsl",
                   Type = ContentType.Paragraph,
                },
                new Detail
               {
                   Id = 58,
                   SectionId = "scripts-wsl",
                   Type = ContentType.Picture,
                },
                new Detail
               {
                   Id = 59,
                   SectionId = "scripts-wsl",
                   Type = ContentType.Paragraph,
                },
                new Detail
               {
                   Id = 60,
                   SectionId = "scripts-wsl",
                   Type = ContentType.Picture,
                },
                new Detail
                {
                    Id = 61,
                    SectionId = "scripts-virtual",
                    Type = ContentType.Paragraph,

                },
                new Detail
                {
                    Id = 62,
                    SectionId = "scripts-docker",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 63,
                    SectionId = "scripts-podman",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 64,
                    SectionId = "scripts-sdk",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 65,
                    SectionId = "scripts-sindamodule",
                    Type = ContentType.Paragraph,

                },
                new Detail
                {
                    Id = 66,
                    SectionId = "scripts-sindamodule",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 67,
                    SectionId = "scripts-sindamodule",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 68,
                    SectionId = "scripts-sindamodule",
                    Type = ContentType.Code,
                },
                new Detail
                {
                    Id = 69,
                    SectionId = "scripts-sindamodule",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 70,
                    SectionId = "scripts-sindamodule",
                    Type = ContentType.Code,
                },
                new Detail
                {
                    Id = 71,
                    SectionId = "scripts-sindamodule",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 72,
                    SectionId = "scripts-sindamodule",
                    Type = ContentType.Code,
                },
                new Detail
                {
                    Id = 73,
                    SectionId = "scripts-sindamodule",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 74,
                    SectionId = "scripts-sindamodule",
                    Type = ContentType.Code,
                },
                new Detail
                {
                    Id = 75,
                    SectionId = "scripts-sindamodule",
                    Type = ContentType.Paragraph,

                },
                new Detail
                {
                    Id = 76,
                    SectionId = "scripts-sindamodule",
                    Type = ContentType.Code,

                },
                new Detail
                {
                    Id = 77,
                    SectionId = "scripts-sindamodule",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 78,
                    SectionId = "scripts-sindamodule",
                    Type = ContentType.Code,
                },
                new Detail
                {
                    Id = 79,
                    SectionId = "scripts-sindamodule",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 80,
                    SectionId = "scripts-boilerplate",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 81,
                    SectionId = "scripts-portfolio",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 82,
                    SectionId = "scripts-portfolio",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 83,
                    SectionId = "boilerplate-introduction",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 84,
                    SectionId = "boilerplate-portfolio",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 85,
                    SectionId = "boilerplate-portfolio-setup",
                    Type = ContentType.Paragraph,

                },
                new Detail
                {
                    Id = 86,
                    SectionId = "boilerplate-portfolio-setup",
                    Type = ContentType.Code,
                },
                new Detail
                {
                    Id = 87,
                    SectionId = "boilerplate-portfolio-setup",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 88,
                    SectionId = "boilerplate-portfolio-setup",
                    Type = ContentType.Code,

                },
                new Detail
                {
                    Id = 89,
                    SectionId = "boilerplate-portfolio-setup",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 90,
                    SectionId = "boilerplate-portfolio-setup",
                    Type = ContentType.Code,
                },
                new Detail
                {
                    Id = 91,
                    SectionId = "boilerplate-portfolio-setup",
                    Type = ContentType.Code,
                },
                new Detail
                {
                    Id = 92,
                    SectionId = "boilerplate-portfolio-setup",
                    Type = ContentType.Code,
                },
                new Detail
                {
                    Id = 93,
                    SectionId = "boilerplate-portfolio-setup",
                    Type = ContentType.Paragraph,

                },
                new Detail
                {
                    Id = 94,
                    SectionId = "boilerplate-portfolio-setup",
                    Type = ContentType.Picture,
                },
                new Detail
                {
                    Id = 95,
                    SectionId = "boilerplate-portfolio-hero",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 96,
                    SectionId = "boilerplate-portfolio-hero",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 97,
                    SectionId = "boilerplate-portfolio-hero",
                    Type = ContentType.Code,
                },
                new Detail
                {
                    Id = 98,
                    SectionId = "boilerplate-portfolio-hero",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 99,
                    SectionId = "boilerplate-portfolio-hero",
                    Type = ContentType.Picture,
                },
                new Detail
                {
                    Id = 100,
                    SectionId = "boilerplate-portfolio-hero",
                    Type = ContentType.Paragraph,

                },
                new Detail
                {
                    Id = 101,
                    SectionId = "boilerplate-portfolio-hero",
                    Type = ContentType.Picture,

                },
                new Detail
                {
                    Id = 102,
                    SectionId = "boilerplate-portfolio-hero",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 103,
                    SectionId = "boilerplate-portfolio-hero",
                    Type = ContentType.Picture,
                },
                new Detail
                {
                    Id = 104,
                    SectionId = "boilerplate-portfolio-hero",
                    Type = ContentType.Paragraph,

                },
                new Detail
                {
                    Id = 105,
                    SectionId = "boilerplate-portfolio-hero",
                    Type = ContentType.Picture,
                },
                new Detail
                {
                    Id = 106,
                    SectionId = "boilerplate-portfolio-body",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 107,
                    SectionId = "boilerplate-portfolio-body",
                    Type = ContentType.Picture,
                },
                new Detail
                {
                    Id = 108,
                    SectionId = "boilerplate-portfolio-body",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 109,
                    SectionId = "boilerplate-portfolio-body",
                    Type = ContentType.Paragraph,

                },
                new Detail
                {
                    Id = 110,
                    SectionId = "boilerplate-portfolio-body",
                    Type = ContentType.Paragraph,

                },
                new Detail
                {
                    Id = 111,
                    SectionId = "boilerplate-portfolio-body",
                    Type = ContentType.Picture,
                },
                new Detail
                {
                    Id = 112,
                    SectionId = "boilerplate-portfolio-body",
                    Type = ContentType.Paragraph,
                },
                new Detail
                {
                    Id = 113,
                    SectionId = "boilerplate-portfolio-body",
                    Type = ContentType.Paragraph,
                }
            );





















            //        #region seedData
            //        modelBuilder.Entity<Site>().HasData(new Site
            //        {
            //            BrandName = "Sinda",
            //            PageNames = new List<PageName> {
            //                new PageName{ Name="Docs" },
            //                new PageName{ Name="Blog" },
            //                new PageName{Name= "Roadmap"}
            //            },
            //            BrandDescription = "Sindagal MIT",
            //        });
            //        modelBuilder.Entity<HTMLContent>()
            //            .HasDiscriminator<int>("content_type")
            //            .HasValue<LinkContent>(1)
            //            .HasValue<WarningContent>(2)
            //            .HasValue<PictureSourceContent>(3)
            //            .HasValue<ImageContent>(4)
            //            .HasValue<CodeContent>(5)
            //            .HasValue<HTMLContent>(;


            //        modelBuilder.Entity<HTMLContent>().HasData(
            //            new HTMLContent {Id=1, Value = "Sindagal " },
            //            new LinkContent { Id = 2, Value = "Command Line Interface", Href = "https://github.com/denzii/sinda-cli" },
            //            new HTMLContent { Id = 3, Value = " is a simple Node.js application which makes use of the popular JavaScript framework React. The goal is to make developer lives more convenient by wrapping around operating system level scripts and allowing their easy consumption." },
            //            new WarningContent { Id = 4, Value = "For the time being, usages from within WSL & Unix based systems had been disabled." },
            //            new HTMLContent { Id=5, Value = "On this page, you'll learn what the Sinda Command Line Interface brings to the table and how it can be consumed by setting it up from scratch and consuming some of the built in automation scripts on a Windows machine." },
            //            new HTMLContent { Id = 6, Value = "The project requires Node.js LTS and npm to be installed as a pre-requisite so if you do not already have them, now is a good time to set them up." },
            //            new LinkContent { Id = 7, Value = "This tutorial", Href = "https://docs.microsoft.com/en-us/windows/dev-environment/javascript/nodejs-on-windows" },
            //            new HTMLContent { Id = 8, Value = "by Microsoft demonstrates how they could be set on a Windows machine using the Node Version Manager tool (NVM)." },
            //            new HTMLContent { Id = 9, Value = "Once NVM & Node.js are configured, we could proceed to cloning the repository and running the app from the cloned source code. Its necessary to fork and/or clone the repository since the app itself requires access to the localhost machine so it can run powershell/bash scripts." },
            //            new CodeContent { Id = 10, Language = "shell", Value = "git clone https://github.com/denzii/sinda-cli.git" },
            //            new CodeContent { Id=11, Language = "shell", Value = "cd sinda-cli" },
            //            new CodeContent { Id=12, Language = "shell", Value = "npm start" },
            //            new HTMLContent { Id=13, Value = "The app requires administrator rights to run Powershell / Bash scripts on localhost, if its run from a non-elevated terminal session, it will result in an error and not run." },
            //            new HTMLContent { Id=14, Value = "The following image demonstrates the landing page for a successfully started CLI." },
            //            new PictureSourceContent { Id=15, Srcset = "./img/cli-landing-page-850w.png", Media = "(max-width: 950px)" },
            //            new PictureSourceContent { Id=16, Srcset = "./img/cli-landing-page.png" },
            //            new ImageContent { Id=17, Src = "./img/cli-landing-page.png", Alt = "CLI Landing Page" },
            //            new HTMLContent { Id=18, Value = "Consuming scripts from the app is pretty straight forward and takes only a few key-presses to achieve. As seen on the landing page image, the terminal prompt functions similarly to a single page app and the visible part of the terminal is hijacked by a" },
            //            new LinkContent { Id=19, Value = "React Ink", Href = "https://github.com/vadimdemedes/ink" },
            //            new HTMLContent { Id=20, Value = "Component" },
            //            new HTMLContent { Id=21, Value = "The component itself detects the screen height and width and resizes accordingly. Having said that, a maximized terminal window is recommended for the best experience and the resizing  feature is only meant for the application startup. If the terminal window gets resized while the app is running, there are no guarantees for correct rendering of the component." },
            //            new HTMLContent { Id=22, Value = "Once a key is pressed on the landing page, the survey component is rendered and the user is presented with all the available automation scripts... Navigation of the form is achieved through the <i>Up / Down / Enter & Esc </i> keys. This component is demonstrated in the following image." },
            //            new PictureSourceContent { Id=23, Srcset = "./img/cli-survey-page-850w.png", Media = "(max-width: 950px)" },
            //            new PictureSourceContent { Id=24, Srcset = "./img/cli-survey-page.png" },
            //            new ImageContent { Id=25, Src = "./img/cli-survey-page.png", Alt = "CLI Survey Page" },
            //            new PictureSourceContent { Id=26, Srcset = "./img/cli-survey-page-850w.png", Media = "(max-width: 950px)" },
            //            new PictureSourceContent { Id=27, Srcset = "./img/cli-survey-page.png" },
            //            new ImageContent { Id=28, Src = "./img/cli-survey-page.png", Alt = "CLI Survey Page" },
            //            new HTMLContent { Id=29, Value = "For the sake of this tutorial, we are only going to be selecting the first three options. Once the selections are made, it is required to navigate to the last page of the survey and confirm the selections.  The \"proceed\" button will ask for a re-confirmation and esc key could be used to go back to the form." },
            //            new PictureSourceContent { Id=30, Srcset = "./img/cli-survey-page-confirmation-850w.png", Media = "(max-width: 950px)" },
            //            new PictureSourceContent { Id=31, Srcset = "./img/cli-survey-page-confirmation.png" },
            //            new ImageContent { Id=32, Src = "./img/cli-survey-page-confirmation.png", Alt = "CLI Survey Page Confirmation" },
            //            new HTMLContent { Id=33, Value = "Prior to making any changes to the machine, all the selected features and their corresponding scripts are listed and a confirmation is requested once more for extra safety." },
            //            new PictureSourceContent { Id=34, Srcset = "./img/cli-survey-page-confirmation-2-850w.png", Media = "(max-width: 950px)" },
            //            new PictureSourceContent { Id=35, Srcset = "./img/cli-survey-page-confirmation-2.png" },
            //            new ImageContent { Id=36, Src = "./img/cli-survey-page-confirmation-2.png", Alt = "CLI Survey Page Finalization" },
            //            new HTMLContent { Id=37, Value = "For the time being, the scripts are executed syncronously and the results within the box are updated all at once." },
            //            new HTMLContent { Id=38, Value = "The Standard Outputs as well as Errors for the executed commands are pushed above the component box in real-time. A finished session is demonstrated in the below image." },
            //            new HTMLContent { Id=39, Value = "The Standard Outputs as well as Errors for the executed commands are pushed above the component box in real-time. A finished session is demonstrated in the below image." },
            //            new PictureSourceContent { Id=40, Srcset = "./img/cli-survey-page-results-850w.png", Media = "(max-width: 950px)" },
            //            new PictureSourceContent { Id=41, Srcset = "./img/cli-survey-page-results.png" },
            //            new ImageContent { Id=42, Src = "./img/cli-survey-page-results.png", Alt = "CLI Survey Page Results" },
            //            new HTMLContent { Id=43, Value = "Thats all folks! See how easy it was to consume some powershell scripts? To see the full list of the existing scripts, please navigate to the scripts tab on this page." },
            //            new HTMLContent { Id=44, Value = "As described in the Terminal tab, Sindagal comes with some built-in scripts and can also be extended to interface to personal scripts. The scripts are categorized as Terminal, Shell, Virtual, SDK & Boilerplate." },
            //            new HTMLContent { Id=45, Value = " The CLI tool works by executing powershell / bash scripts which exist inside the code repository itself under the src/scripts directory." },
            //            new HTMLContent { Id=46, Value = " On this page, we will be exploring the various details regarding those features and why they might come in handy for you or your organisation." },
            //            new HTMLContent { Id=47, Value = "For the time being, everything is in the Minimum Viable Product stage & things might change in the future. Please report any problems or bugs to me personally through my " },
            //            new LinkContent { Id=48, Value = "Linkedin.", Href = "https://www.linkedin.com/in/denizarca/" },
            //            new HTMLContent { Id=49, Value = " Pull requests are welcome at the " },
            //            new LinkContent { Id=50, Value = "CLI repository.", Href = "https://github.com/denzii/sinda-cli" },
            //            new HTMLContent { Id=51, Value = "This category is where the scripts regarding the interactive terminal session reside. These will alter the look & feel of your interactions with your local shell." },
            //            new HTMLContent { Id=52, Value = "By default, terminal prompts on Windows machines come with no support for user themes, lack descriptiveness and are not intuitive to use. Wouldn't it be nice if the sessions could be personalized & extended with additional information such as the time of command execution, git active branch names, battery level and more?" },
            //            new HTMLContent { Id=53, Value = " Enter " },
            //            new LinkContent { Id=54, Value = "Oh My Posh!", Href = "https://ohmyposh.dev/" },
            //            new HTMLContent { Id=55, Value = " A shell framework for doing all of that! Historically this worked only on Windows but with Powershell going cross platform, it now works on Linux & Mac as well. " },
            //            new HTMLContent { Id=56, Value = "The framework is easily configurable... All available themes could be reviewed by: " },
            //            new CodeContent { Id=57, Language = "shell", Value = "Get-PoshThemes" },
            //            new HTMLContent { Id=58, Value = "changing the theme to \"Darkblood\": " },
            //            new HTMLContent { Id=59, Value = "Having said that, it is also possible to configure it via code by adjusting an init script at a location which can be found from the Get-PoshThemes command. " },
            //            new HTMLContent { Id=60, Value = "Oh My Posh relies on a specific font family in order to display its many glyphs properly, Sinda takes care of installing the " },
            //            new LinkContent { Id=61, Value = "Nerd Fonts", Href = "https://github.com/ryanoasis/nerd-fonts" },
            //            new HTMLContent { Id=62, Value = " for you!" },
            //            new HTMLContent { Id=63, Value = "The default Powershell / Command Prompt & WSL terminal apps are some-what primitive, those emulators damage productivity. They are difficult to impossible to standardize, they require switching between windows which can get tedious & confusing from time to time and they lack certain features when it comes to keyboard shortcuts." },
            //            new LinkContent { Id=64, Value = "Windows Terminal", Href = "https://docs.microsoft.com/en-us/windows/terminal/" },
            //            new HTMLContent { Id=65, Value = " intends to remedy the above problems by allowing multiple tabs, split screens, extensive keyboard macros and multi-shell support." },
            //            new HTMLContent { Id=66, Value = " Tabs could contain any session ranging from Azure, WSL2, Remote SSH, Powershell & CMD!" },
            //            new HTMLContent { Id=67, Value = " This powerful open source tool also allows launching sessions programatically through powershell commands." },
            //            new HTMLContent { Id=68, Value = "To start WSL Debian & Powershell sessions programatically: " },
            //            new CodeContent { Id=69,  Language = "shell", Value = "wt -p \"Debian\" `; split-pane -p \"Windows PowerShell\" `;" },
            //            new HTMLContent { Id=70, Value = "Results in the following interactive sessions:" },
            //            new PictureSourceContent { Id=71, Srcset = "./img/winterm-850w.png", Media = "(max-width: 950px)" },
            //            new PictureSourceContent { Id=72, Srcset = "./img/winterm.png" },
            //            new ImageContent { Id=73, Src = "./img/winterm", Alt = "CLI Landing Page" },
            //            new HTMLContent { Id=74, Value = "As always, the stock functionality with Windows is lacked and this time its with Git on Powershell & Command Prompt... " },
            //            new LinkContent { Id=75, Value = "PoshGit", Href = "https://github.com/dahlbyk/posh-git" },
            //            new HTMLContent { Id=76, Value = "a powershell module, once imported, allows auto completion for all git commands. This makes life easier as less typing is required to navigate daily tasks." },
            //            new HTMLContent { Id=77, Value = "The Shell category harbours everything which will alter the installed shell(s) themselves such as changing default powershell versions or installing WSL on localhost etc." },
            //            new HTMLContent { Id=78, Value = "This is a pre configured WSL2 instance which had been exported and put online for easy consumption." },
            //            new HTMLContent { Id=79, Value = " The purpose of this is to encapsulate basic linux setup and provide a ready developer environment for common tasks." },
            //            new HTMLContent { Id=80, Value = " It comes with " },
            //            new LinkContent { Id=81, Value = "Zsh", Href = "https://www.zsh.org/" },
            //            new HTMLContent { Id=82, Value = " as well as " },
            //            new LinkContent { Id=83, Value = "Oh My Zsh.", Href = "https://ohmyz.sh/" },
            //            new HTMLContent { Id=84, Value = " Zsh is the default shell which OSX systems are shipped with and OhMyZsh is a framework for adding magic to it!" },
            //            new HTMLContent { Id=85, Value = "The features & plugins are not limited to the ones demonstrated below!" },
            //            new HTMLContent {Id=86, Value = "Themes could be configured on Oh My Zsh and all the themes which exist for Oh My Posh also exist for Oh My Zsh if not more! all existing " },
            //            new LinkContent { Id=87,Value = "Oh My Zsh Themes", Href = "https://github.com/ohmyzsh/ohmyzsh/wiki/Themes" },
            //            new HTMLContent { Id=88,Value = "could be found in the given link! " },
            //            new HTMLContent { Id=89, Value = " The Sinda Ubuntu comes with the theme \"agnoster\" but this can easily be changed by amending the .zshrc file." },
            //            new HTMLContent { Id=90, Value = "First look on the .zshrc file:" },
            //            new PictureSourceContent { Id=91, Srcset = "./img/zsh-rc.png" },
            //            new ImageContent { Id=92, Src = "./img/zsh-rc.png", Alt = "First look on .zshrc file" },
            //            new HTMLContent { Id=93, Value = "As shown in the image above, Oh My Zsh can be configured with many " },
            //            new LinkContent { Id=94, Value = "plugins,", Href = "https://github.com/ohmyzsh/ohmyzsh/wiki/Plugins" },
            //            new HTMLContent { Id=95, Value = " plugins which make life convenient! The Sinda Ubuntu comes with the git, debian, alias-finder, docker, command-not-found, thefuck & docker." },
            //            new HTMLContent { Id=96, Value = " These of course can be changed by editing the plugins array. Below are some images demonstrating the Zsh & Oh My Zsh features further!" },
            //            new HTMLContent { Id=97, Value = "Thefuck:" },
            //            new PictureSourceContent { Id=98, Srcset = "./img/zsh-thefuck.png" },
            //            new ImageContent { Id=99, Src = "./img/zsh-thefuck.png", Alt = "Thefuck demo" },
            //            new HTMLContent { Id=100, Value = "Git branch display:" },
            //            new PictureSourceContent { Id=101, Srcset = "./img/zsh-git-branch.png" },
            //            new ImageContent { Id=102, Src = "./img/zsh-git-branch.png", Alt = "git branch display demo" },
            //            new HTMLContent { Id=103, Value = "Auto complete & switch on tab key:" },
            //            new HTMLContent { Id=104,  Value = "Auto complete & switch on tab key:" },
            //            new HTMLContent { Id=105, Value = "Auto complete & switch on tab key:" },
            //            new PictureSourceContent { Id=106, Srcset = "./img/zsh-tab-switch.png" },
            //            new ImageContent { Id=107,  Src = "./img/zsh-tab-switch.png", Alt = "auto complete  demo" },
            //            new HTMLContent { Id=108, Value = "Autocorrect:" },
            //            new PictureSourceContent {Id=109, Srcset = "./img/zsh-autocorrect.png" },
            //            new ImageContent { Id=110, Src = "./img/zsh-autocorrect.png", Alt = "auto correction demo" },
            //            new HTMLContent { Id=111, Value = "Alias finder:" },
            //            new PictureSourceContent { Id=112, Srcset = "./img/zsh-alias-finder.png" },
            //            new ImageContent { Id=113, Src = "./img/zsh-alias-finder.png", Alt = "alias finder demo" },
            //            new HTMLContent { Id=114, Value = "Command not found:" },
            //            new PictureSourceContent { Id=115, Srcset = "./img/zsh-command-not-found.png" },
            //            new ImageContent { Id=116, Src = "./img/zsh-command-not-found.png", Alt = "command not found demo" },
            //            new HTMLContent { Id=117, Value = "The Virtualization category includes scripts for installing toolsets & software such as Docker / Podman which make it easier to consume / ship software by professionals." },
            //            new HTMLContent { Id=118, Value = "This installs " },
            //            new LinkContent { Id=119,  Value = "Docker Desktop", Href = "https://www.docker.com/products/docker-desktop" },
            //            new HTMLContent { Id=120, Value = " with the WSL2 backend through the chocolatey package manager. Historically very difficult to achieve but today its not even a few lines of code, what a time to be alive!" },
            //            new HTMLContent {Id=121, Value = "Much like Docker, " },
            //            new LinkContent { Id=122, Value = "Podman", Href = "https://podman.io/" },
            //            new HTMLContent { Id=123, Value = " is a software for managing OCI Containers, this installation is provided as an alternative for the ones who prefer it instead of Docker." },
            //            new HTMLContent { Id=124, Value = "The scripts under this section are all about giving developers more power by making internal Sinda tools available. The tools function as encapsulation on certain tasks into one liners." },
            //            new HTMLContent { Id=125, Value = "This is a Powershell module & an exact copy of the internal scripts used with the CLI tool wrapped in an easily importable format." },
            //            new HTMLContent { Id=126, Value = "the command imports the module located at src/script/Sindagal.psm1 into the powershell profile of the user using the machine" },
            //            new HTMLContent { Id=127, Value = "Once the module is imported, the developer gains direct access to all the features included in the CLI & more through direct powershell commands!" },
            //            new HTMLContent { Id=128, Value = "All the commands could be inspected in the file location mentioned within the CLI repository, however some of them are explained below." },
            //            new HTMLContent { Id=129, Value = "To check the current state of your system for things such as os version, architecture, wsl2 support etc: " },
            //            new CodeContent { Id=130, Language = "shell", Value = "Get-EnvState" },
            //            new HTMLContent { Id=140, Value = "To install WSL on legacy systems where WSL2 or wsl --install command are not supported " },
            //            new CodeContent { Id=141, Language = "shell", Value = "Enable-WSLLegacy" },
            //            new HTMLContent { Id=142, Value = "To download & import the Sinda pre configured wsl2 instance:" },
            //            new CodeContent { Id=143, Language = "shell", Value = "Add-SindaDistro" },
            //            new HTMLContent { Id=144, Value = "Check if terminal session has admin rights:" },
            //            new CodeContent { Id=145, Language = "shell", Value = "Test-Elevation" },
            //            new HTMLContent { Id=146, Value = "The Boilerplate section contains scripts which clone Ready to go Sinda Codebases from github. The repositories are intended to solve common problems & be as easily personalized as possible." },
            //            new HTMLContent { Id=147, Value = "Install & Configure Windows Terminal with Nerd Fonts:" },
            //            new CodeContent {Id=148, Language = "shell", Value = "Enable-WindowsTerminal" },
            //            new HTMLContent {Id=149, Value = "Disable & delete Windows Terminal:" },
            //            new CodeContent {Id=150, Language = "shell", Value = "Disable-WindowsTerminal" },
            //            new HTMLContent { Id=151, Value = "And many more!" },
            //            new HTMLContent {  Id=152, Value = "The Boilerplate section contains scripts which clone Ready to go Sinda Codebases from github. The repositories are intended to solve common problems & be as easily personalized as possible." },
            //             new HTMLContent { Id=153, Value = "This clones a reusable & extensible web portfolio template written with React using the NextJS framework. The repository could be found " },
            //            new LinkContent { Id=154, Value = "here.", Href = "https://github.com/denzii/sinda-portfolio" },
            //            new HTMLContent { Id=155, Value = "This simplistic portfolio itself has basic SEO optimizations, keyboard and developer accessibility; a performant " },
            //            new LinkContent { Id=156,Value = "Chrome Lighthouse", Href = "https://developers.google.com/web/tools/lighthouse" },
            //            new HTMLContent { Id=157, Value = " score as well as good responsive UI/UX principles!" },
            //            new HTMLContent { Id=158, Value = " Feel free to change the data & reupload it to your favourite version-control website as you please!" },
            //            new HTMLContent { Id=159, Value = "For more information regarding this template & web theme, please refer to the Boilerplate tab on this page." },
            //            new HTMLContent { Id=160, Value = "Do you have some boilerplate code which you always have to write from scratch? Are you in a hurry to get up and running with an MVP?" },
            //            new HTMLContent { Id=161, Value = " Sindagal Boilerplates will come to your rescue!" },
            //            new HTMLContent { Id=162, Value = " On this page, we will be exploring how to set up and work with existing code as well as how to extend them to our needs to save time from cumbersome work!" },
            //            new HTMLContent { Id=163, Value = "Planning to look for that next challange in your career but do not have time to fiddle with UI/UX or write the code for a portfolio website from scratch?" },
            //            new HTMLContent { Id=164, Value = " You can now rest easy with this " },
            //            new LinkContent { Id=165, Value = "web portfolio.", Href = "https://github.com/denzii/sinda-portfolio" },
            //            new HTMLContent { Id=166,Value = " This template simplistic enough to do the job and will hit the spot with its SEO optimizations, keyboard and developer accessibility; a performant " },
            //            new LinkContent { Id=167,Value = "Lighthouse", Href = "https://developers.google.com/web/tools/lighthouse" },
            //            new HTMLContent { Id=168,Value = " score as well as good responsive UI/UX principles!" },
            //            new HTMLContent { Id=169,Value = " please find a live example at" },
            //            new LinkContent { Id=170,Value = "denizarca.com", Href = "https://denizarca.com" },
            //            new HTMLContent { Id=171, Value = "This is a NextJS TypeScript project so NodeJS & npm are required as a prerequisite." },
            //            new HTMLContent { Id=172, Value = "If those already exist on the machine or if you are using the pre configured WSL instance, its okay to proceed to cloning the repository." },
            //            new CodeContent { Id=173,  Language = "shell", Value = "git clone https://github.com/denzii/sinda-portfolio.git" },
            //            new HTMLContent { Id=174, Value = "Install Nextjs globally:" },
            //            new CodeContent { Id=175, Language = "shell", Value = "npm i -g next" },
            //            new HTMLContent { Id=176, Value = "Move into the repository, install dependencies and run the app:" },
            //            new CodeContent { Id=177, Language = "shell", Value = "cd sinda-portfolio" },
            //            new CodeContent { Id=178, Language = "shell", Value = "npm install" },
            //            new CodeContent { Id=179, Language = "shell", Value = "npm run dev" },
            //            new HTMLContent { Id=180, Value = "If everything went well, it's now okay to visit localhost:3000 in your favourite browser to see the site!" },
            //            new PictureSourceContent { Id=181, Srcset = "./img/portfolio-landing-page-850w.png", Media = "(max-width: 950px)" },
            //            new PictureSourceContent { Id=182, Srcset = "./img/portfolio-landing-page.png" },
            //            new ImageContent { Id=183, Src = "./img/portfolio-landing-page.png", Alt = "Portfolio Landing Page" },
            //            new HTMLContent { Id=184, Value = "Not bad! In order to personalize it, we need to make a few tweaks." },
            //            new HTMLContent { Id=185, Value = " The data is pulled into a single class at " },
            //            new LinkContent { Id=186, Value = "data/index.ts", Href = "https://github.com/denzii/sinda-portfolio/blob/main/data/index.ts" },
            //            new HTMLContent { Id=187, Value = " class for the most part and this is where we will spend most of our time." },
            //            new HTMLContent { Id=188, Value = " having said that, the page title and the meta tags for SEO as well as canonical must also be changed for a fully personalized portfolio. In a NextJS project, these are stored in " },
            //            new LinkContent { Id=189, Value = "pages/_document.tsx", Href = "https://github.com/denzii/sinda-portfolio/blob/main/pages/_document.tsx" },
            //            new HTMLContent { Id=190, Value = " as per convention. It is planned to pull these into the data folder in the future as well!" },
            //            new HTMLContent { Id=191, Value = "Let's view the code in our favourite code editor and see how to go about the modifications!" },
            //            new CodeContent { Id=192, Language = "shell", Value = "code ." },
            //            new HTMLContent { Id=193, Value = "To start things off, lets change the navigation bar contents by changing the ProjectOwner, PersonalURLs & PersonalBackground Objects as shown." },
            //            new PictureSourceContent { Id=194, Srcset = "./img/portfolio-navbar-name-diff-850w.png", Media = "(max-width: 950px)" },
            //            new PictureSourceContent { Id=195, Srcset = "./img/portfolio-navbar-name-diff.png", },
            //            new ImageContent { Id=196, Src = "./img/portfolio-navbar-name-diff.png", Alt = "Portfolio Navbar modification" },
            //             new HTMLContent { Id=197, Value = " Icons for social media could be changed by supplying a name from the " },
            //            new LinkContent { Id=198, Value = "React Font Awesome", Href = "https://react-icons.github.io/react-icons/icons?name=fa" },
            //            new HTMLContent { Id=199, Value = " Icons. Additional navigation links such as \"instagram\" could also be added or removed if desired by altering the keys on the" },
            //            new LinkContent { Id=200, Value = "interface/personalUrls.ts", Href = "https://github.com/denzii/sinda-portfolio/blob/main/interface/personalUrls.ts" },
            //            new HTMLContent { Id=201, Value = " class further. For demonstration purposes, lets remove the email icon while changing the other two icons." },
            //            new PictureSourceContent { Id=202, Srcset = "./img/portfolio-socialbar-diff-850w.png", Media = "(max-width: 950px)" },
            //            new PictureSourceContent { Id=203, Srcset = "./img/portfolio-socialbar-diff.png", },
            //            new ImageContent { Id=204, Src = "./img/portfolio-socialbar-diff.png", Alt = "Portfolio Socialbar modification" },
            //            new HTMLContent { Id=205, Value = " The keys on the object " },
            //            new LinkContent { Id=206, Value = "interface/background.ts", Href = "https://github.com/denzii/sinda-portfolio/blob/main/interface/background.ts" },
            //            new HTMLContent { Id=207, Value = " are used to generate the sections below the hero section. If we wanted to add or remove or alter a section, all we would need to do is to alter the keys on it!" },
            //            new HTMLContent { Id=208, Value = " for the sake of this tutorial, let's remove the hobbies section and rename some of the others!" },
            //            new PictureSourceContent { Id=209, Srcset = "./img/portfolio-navbar-elems-diff-850w.png", Media = "(max-width: 950px)" },
            //            new PictureSourceContent { Id=210, Srcset = "./img/portfolio-navbar-elems-diff.png", },
            //            new ImageContent { Id=211, Src = "./img/portfolio-navbar-elems-diff.png", Alt = "Portfolio Navbar elements modification" },
            //            new HTMLContent { Id=212, Value = " Now that those are out of the way, its a good time to change the background and the headshot images which are located inside the " },
            //            new LinkContent {Id=213, Value = "public", Href = "https://github.com/denzii/sinda-portfolio/tree/main/public" },
            //            new HTMLContent {Id=214, Value = " directory, all that is required is to drop in the images in that directory and reference them inside the data class. The app is written flexible enough to allow the usage of different image names as-well!" },
            //            new PictureSourceContent {Id=215, Srcset = "./img/portfolio-hero-diff.png", },
            //            new ImageContent {Id=216, Src = "./img/portfolio-hero-diff.png", Alt = "Portfolio hero images modification" },
            //            new HTMLContent { Id=217, Value = "We've come a long way and the results are just beautiful! Refresh the browser page to see that the website now looks like this: " },
            //            new PictureSourceContent { Id=218, Srcset = "./img/portfolio-altered-hero-diff-850w.png", Media = "(max-width: 950px)" },
            //            new PictureSourceContent { Id=219, Srcset = "./img/portfolio-altered-hero-diff.png", },
            //            new ImageContent { Id=220, Src = "./img/portfolio-altered-hero-diff.png", Alt = "Portfolio altered hero section" },
            //            new HTMLContent { Id=221, Value = "How about the body sections? Are they even flexible enough for personalization? They sure are! All that needs to be done is to alter the methods which are being called within the \"PersonalBackground\" method inside the data class." },
            //            new HTMLContent { Id=222, Value = " The heading, date range & inner content are supplied within the same place, the inner content could be made bold, italic or emphasized on demand without touching any HTML." },
            //            new HTMLContent { Id=223, Value = " If it's a semantic markup for your website which you are looking for; you can add emphasis and other things to certain text but also keep it unstyled." },
            //            new HTMLContent { Id=224, Value = " This is a good idea if you would like your website to read well by screen readers so elements could be emphesized without changing the visual feeling..." },
            //            new HTMLContent { Id=225, Value = " The body elements could be given captions aswell by assigning the \"caption\" field a string value." },
            //            new HTMLContent { Id=226, Value = "Example body section element code:" },
            //            new PictureSourceContent { Id=227, Srcset = "./img/portfolio-body-code.png", Media = "(max-width: 950px)" },
            //            new ImageContent { Id=228, Src = "./img/portfolio-body-code.png", Alt = "Portfolio body code example" },
            //            new HTMLContent { Id=229, Value = "Only one thing remains, changing the meta content of the site! And this is as easy as going into the pages/_document.tsx" },
            //            new LinkContent {Id=230, Value = "pages/_document.tsx", Href = "https://github.com/denzii/sinda-portfolio/tree/main/public" },
            //            new HTMLContent {Id=231, Value = " file and altering the given strings." },
            //            new HTMLContent { Id=232, Value = " add in the full address of your domain as a canonical, change the tab title as you wish and amend the keywords to cater to your target audiences google searches." },
            //            new HTMLContent {Id=233, Value = "That is all! Enjoy your Sinda Portfolio and do not forget to give a star or send your pull requests!" },
            //            new HTMLContent {Id=234, Value = " We will not be touching on how to deploy this website since it is using the stock CI/CD which is provided by Vercel for free on personal projects." },
            //            new HTMLContent { Id=235, Value = " To find out more about deployments, visit their tutorials at " },
            //            new LinkContent {Id=236, Value = "nextjs.org/deployment", Href = "https://nextjs.org/docs/deployment" },
            //            new HTMLContent {Id=237, Value = "We've come a long way and the results are just beautiful! Refresh the browser page to see that the website now looks like this: " },
            //            new PictureSourceContent { Id=238, Srcset = "./img/portfolio-altered-hero-diff-850w.png", Media = "(max-width: 950px)" },
            //            new PictureSourceContent { Id=239, Srcset = "./img/portfolio-altered-hero-diff.png", },
            //            new ImageContent { Id=240, Src = "./img/portfolio-altered-hero-diff.png", Alt = "Portfolio altered hero section" },
            //            new HTMLContent { Id=241, Value = "How about the body sections? Are they even flexible enough for personalization? They sure are! All that needs to be done is to alter the methods which are being called within the \"PersonalBackground\" method inside the data class." },
            //            new HTMLContent {Id=242, Value = " The heading, date range & inner content are supplied within the same place, the inner content could be made bold, italic or emphasized on demand without touching any HTML." },
            //            new HTMLContent { Id=243, Value = " If it's a semantic markup for your website which you are looking for; you can add emphasis and other things to certain text but also keep it unstyled." },
            //            new HTMLContent { Id=244, Value = " This is a good idea if you would like your website to read well by screen readers so elements could be emphesized without changing the visual feeling..." },
            //            new HTMLContent {Id=245, Value = " The body elements could be given captions aswell by assigning the \"caption\" field a string value." },
            //            new HTMLContent { Id=246, Value = "Example body section element code:" },
            //            new PictureSourceContent { Id=247, Srcset = "./img/portfolio-body-code.png", Media = "(max-width: 950px)" },
            //            new ImageContent { Id=248, Src = "./img/portfolio-body-code.png", Alt = "Portfolio body code example" },
            //            new HTMLContent {Id=249, Value = "Only one thing remains, changing the meta content of the site! And this is as easy as going into the pages/_document.tsx" },
            //            new LinkContent {Id=250, Value = "pages/_document.tsx", Href = "https://github.com/denzii/sinda-portfolio/tree/main/public" },
            //            new HTMLContent {Id=251, Value = " file and altering the given strings." },
            //            new HTMLContent {Id=252, Value = " add in the full address of your domain as a canonical, change the tab title as you wish and amend the keywords to cater to your target audiences google searches." },
            //            new HTMLContent { Id=253, Value = "Only one thing remains, changing the meta content of the site! And this is as easy as going into the pages/_document.tsx" },
            //            new LinkContent { Id=254, Value = "pages/_document.tsx", Href = "https://github.com/denzii/sinda-portfolio/tree/main/public" },
            //            new HTMLContent { Id=255, Value = " file and altering the given strings." },
            //            new HTMLContent {Id=256, Value = " add in the full address of your domain as a canonical, change the tab title as you wish and amend the keywords to cater to your target audiences google searches." },
            //            new HTMLContent { Id=257, Value = "That is all! Enjoy your Sinda Portfolio and do not forget to give a star or send your pull requests!" },
            //            new HTMLContent { Id=258, Value = " We will not be touching on how to deploy this website since it is using the stock CI/CD which is provided by Vercel for free on personal projects." },
            //            new HTMLContent {Id=259, Value = " To find out more about deployments, visit their tutorials at " },
            //            new LinkContent { Id=260, Value = "nextjs.org/deployment", Href = "https://nextjs.org/docs/deployment" }
            //    );
            //        modelBuilder.Entity<Detail>().HasData(
            //            new Detail
            //            {
            //                Id=1,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "Sindagal " },
            //                //    new LinkContent{ Value= "Command Line Interface", Href="https://github.com/denzii/sinda-cli" },
            //                //    new HTMLContent{ Value= " is a simple Node.js application which makes use of the popular JavaScript framework React. The goal is to make developer lives more convenient by wrapping around operating system level scripts and allowing their easy consumption." }
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 2,

            //                //Contents = new List<HTMLContent> { new WarningContent { Value = "For the time being, usages from within WSL & Unix based systems had been disabled." } }
            //            },
            //            new Detail
            //            {
            //                Id = 3,

            //                //Contents = new List<HTMLContent> { new HTMLContent { Value = "On this page, you'll learn what the Sinda Command Line Interface brings to the table and how it can be consumed by setting it up from scratch and consuming some of the built in automation scripts on a Windows machine." } }
            //            },
            //             new Detail
            //             {
            //                 Id = 4,

            //                 Type = ContentType.Paragraph,
            //                 //Contents = new List<HTMLContent>{
            //                 //   new HTMLContent{ Value= "The project requires Node.js LTS and npm to be installed as a pre-requisite so if you do not already have them, now is a good time to set them up." },
            //                 //   new LinkContent{ Value="This tutorial", Href="https://docs.microsoft.com/en-us/windows/dev-environment/javascript/nodejs-on-windows"},
            //                 //   new HTMLContent{ Value= "by Microsoft demonstrates how they could be set on a Windows machine using the Node Version Manager tool (NVM)."}
            //                 //}
            //             },
            //            new Detail
            //            {
            //                Id = 5,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value="Once NVM & Node.js are configured, we could proceed to cloning the repository and running the app from the cloned source code. Its necessary to fork and/or clone the repository since the app itself requires access to the localhost machine so it can run powershell/bash scripts."}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 6,

            //                Type = ContentType.Code,
            //                //Contents = new List<HTMLContent>{
            //                //    new CodeContent{Language="shell", Value="git clone https://github.com/denzii/sinda-cli.git"}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 7,

            //                Type = ContentType.Code,
            //                //Contents = new List<HTMLContent>{
            //                    //new CodeContent{Language="shell", Value="cd sinda-cli"}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 8,

            //                Type = ContentType.Code,
            //                //Contents = new List<HTMLContent>{
            //                //    new CodeContent{Language="shell", Value="npm start"}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 9,

            //                Type = ContentType.Warning,
            //                //Contents = new List<HTMLContent> { new HTMLContent { Value = "The app requires administrator rights to run Powershell / Bash scripts on localhost, if its run from a non-elevated terminal session, it will result in an error and not run." } }
            //            },
            //            new Detail
            //            {
            //                Id = 10,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{Value="The following image demonstrates the landing page for a successfully started CLI."}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 11,

            //                Type = ContentType.Picture,
            //                //Contents = new List<HTMLContent>{
            //                //    new PictureSourceContent{ Srcset="./img/cli-landing-page-850w.png", Media="(max-width: 950px)"},
            //                //    new PictureSourceContent{ Srcset="./img/cli-landing-page.png"},
            //                //    new ImageContent{ Src="./img/cli-landing-page.png", Alt="CLI Landing Page"}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 12,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                    //new HTMLContent{ Value= "Consuming scripts from the app is pretty straight forward and takes only a few key-presses to achieve. As seen on the landing page image, the terminal prompt functions similarly to a single page app and the visible part of the terminal is hijacked by a" },
            //                    //new LinkContent{ Value="React Ink", Href="https://github.com/vadimdemedes/ink"},
            //                    //new HTMLContent{ Value= "Component" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 13,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent> { new HTMLContent { Value = "The component itself detects the screen height and width and resizes accordingly. Having said that, a maximized terminal window is recommended for the best experience and the resizing  feature is only meant for the application startup. If the terminal window gets resized while the app is running, there are no guarantees for correct rendering of the component." } }
            //            },
            //            new Detail
            //            {
            //                Id = 14,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent> { new HTMLContent { Value = "Once a key is pressed on the landing page, the survey component is rendered and the user is presented with all the available automation scripts... Navigation of the form is achieved through the <i>Up / Down / Enter & Esc </i> keys. This component is demonstrated in the following image." } }
            //            },
            //            new Detail
            //            {
            //                Id = 15,

            //                Type = ContentType.Picture,
            //            //    Contents = new List<HTMLContent>{
            //            //    new PictureSourceContent{ Srcset="./img/cli-survey-page-850w.png", Media="(max-width: 950px)"},
            //            //    new PictureSourceContent{ Srcset="./img/cli-survey-page.png"},
            //            //    new ImageContent{ Src="./img/cli-survey-page.png", Alt="CLI Survey Page"}
            //              //}
            //            },
            //            new Detail
            //            {
            //                Id = 16,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent> { new HTMLContent { Value = "For the sake of this tutorial, we are only going to be selecting the first three options. Once the selections are made, it is required to navigate to the last page of the survey and confirm the selections.  The \"proceed\" button will ask for a re-confirmation and esc key could be used to go back to the form." }, }
            //            },
            //            new Detail
            //            {
            //                Id = 17,

            //                Type = ContentType.Picture,
            //                //Contents = new List<HTMLContent>{
            //                //new PictureSourceContent{ Srcset="./img/cli-survey-page-confirmation-850w.png", Media="(max-width: 950px)"},
            //                //new PictureSourceContent{ Srcset="./img/cli-survey-page-confirmation.png"},
            //                //new ImageContent{ Src="./img/cli-survey-page-confirmation.png", Alt="CLI Survey Page Confirmation"}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 18,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent> { new HTMLContent { Value = "Prior to making any changes to the machine, all the selected features and their corresponding scripts are listed and a confirmation is requested once more for extra safety." } }
            //            },
            //            new Detail
            //            {
            //                Id = 19,

            //                Type = ContentType.Picture,
            //                //Contents = new List<HTMLContent>{
            //                //new PictureSourceContent{ Srcset="./img/cli-survey-page-confirmation-2-850w.png", Media="(max-width: 950px)"},
            //                //new PictureSourceContent{ Srcset="./img/cli-survey-page-confirmation-2.png"},
            //                //new ImageContent{ Src="./img/cli-survey-page-confirmation-2.png", Alt="CLI Survey Page Finalization"}
            //            //}
            //            },
            //            new Detail
            //            {
            //                Id = 20,

            //                Type = ContentType.Warning,
            //                //Contents = new List<HTMLContent> { new HTMLContent { Value = "For the time being, the scripts are executed syncronously and the results within the box are updated all at once." } }
            //            },
            //            new Detail
            //            {
            //                Id = 21,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent> { new HTMLContent { Value = "The Standard Outputs as well as Errors for the executed commands are pushed above the component box in real-time. A finished session is demonstrated in the below image." } }
            //            },
            //            new Detail
            //            {
            //                Id = 22,

            //                Type = ContentType.Picture,
            //                //Contents = new List<HTMLContent>{
            //                //new PictureSourceContent{ Srcset="./img/cli-survey-page-results-850w.png", Media="(max-width: 950px)"},
            //                //new PictureSourceContent{ Srcset="./img/cli-survey-page-results.png"},
            //                //new ImageContent{ Src="./img/cli-survey-page-results.png", Alt="CLI Survey Page Results"}
            //            //}
            //            },
            //            new Detail
            //            {
            //                Id = 23,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent> { new HTMLContent { Value = "Thats all folks! See how easy it was to consume some powershell scripts? To see the full list of the existing scripts, please navigate to the scripts tab on this page." } }
            //            },
            //            new Detail
            //            {
            //                Id = 24,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "As described in the Terminal tab, Sindagal comes with some built-in scripts and can also be extended to interface to personal scripts. The scripts are categorized as Terminal, Shell, Virtual, SDK & Boilerplate." },
            //                //    new HTMLContent{ Value= " The CLI tool works by executing powershell / bash scripts which exist inside the code repository itself under the src/scripts directory." } }
            //            },
            //            new Detail
            //            {
            //                Id = 25,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                    //new HTMLContent{ Value=" On this page, we will be exploring the various details regarding those features and why they might come in handy for you or your organisation."}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 26,

            //                Type = ContentType.Warning,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "For the time being, everything is in the Minimum Viable Product stage & things might change in the future. Please report any problems or bugs to me personally through my " },
            //                //    new LinkContent{ Value= "Linkedin.", Href="https://www.linkedin.com/in/denizarca/" },
            //                //    new HTMLContent{ Value= " Pull requests are welcome at the " },
            //                //    new LinkContent{ Value= "CLI repository.", Href="https://github.com/denzii/sinda-cli" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 27,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent> { new HTMLContent { Value = "This category is where the scripts regarding the interactive terminal session reside. These will alter the look & feel of your interactions with your local shell." } }
            //            },
            //            new Detail
            //            {
            //                Id = 28,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "By default, terminal prompts on Windows machines come with no support for user themes, lack descriptiveness and are not intuitive to use. Wouldn't it be nice if the sessions could be personalized & extended with additional information such as the time of command execution, git active branch names, battery level and more?" },
            //                //    new HTMLContent{ Value= " Enter " },
            //                //    new LinkContent{ Value= "Oh My Posh!", Href="https://ohmyposh.dev/" },
            //                //    new HTMLContent{ Value= " A shell framework for doing all of that! Historically this worked only on Windows but with Powershell going cross platform, it now works on Linux & Mac as well. " },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 29,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                    //new HTMLContent{ Value= "The framework is easily configurable... All available themes could be reviewed by: " },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 30,

            //                Type = ContentType.Code,
            //                //Contents = new List<HTMLContent>{
            //                //    new CodeContent{ Language="shell", Value= "Get-PoshThemes" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 31,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "changing the theme to \"Darkblood\": " },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 32,

            //                Type = ContentType.Code,
            //                //Contents = new List<HTMLContent>{
            //                //    new CodeContent{ Language="shell", Value= "Set-PoshPrompt darkblood" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 33,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "Having said that, it is also possible to configure it via code by adjusting an init script at a location which can be found from the Get-PoshThemes command. " },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 34,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                    //new HTMLContent { Value= "Oh My Posh relies on a specific font family in order to display its many glyphs properly, Sinda takes care of installing the " },
            //                    //new LinkContent { Value= "Nerd Fonts", Href="https://github.com/ryanoasis/nerd-fonts"},
            //                    //new HTMLContent { Value= " for you!" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 35,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "The default Powershell / Command Prompt & WSL terminal apps are some-what primitive, those emulators damage productivity. They are difficult to impossible to standardize, they require switching between windows which can get tedious & confusing from time to time and they lack certain features when it comes to keyboard shortcuts." },
            //                //    new LinkContent{ Value= "Windows Terminal", Href="https://docs.microsoft.com/en-us/windows/terminal/" },
            //                //    new HTMLContent{ Value= " intends to remedy the above problems by allowing multiple tabs, split screens, extensive keyboard macros and multi-shell support."},
            //                //    new HTMLContent{ Value= " Tabs could contain any session ranging from Azure, WSL2, Remote SSH, Powershell & CMD!"},
            //                //    new HTMLContent{ Value= " This powerful open source tool also allows launching sessions programatically through powershell commands."}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 36,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "To start WSL Debian & Powershell sessions programatically: "}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 37,

            //                Type = ContentType.Code,
            //                //Contents = new List<HTMLContent>{
            //                //    new CodeContent{ Language="shell", Value= "wt -p \"Debian\" `; split-pane -p \"Windows PowerShell\" `;" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 38,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                    //new HTMLContent{ Value= "Results in the following interactive sessions:"}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 39,

            //                Type = ContentType.Picture,
            //                //Contents = new List<HTMLContent>{
            //                //    new PictureSourceContent{ Srcset="./img/winterm-850w.png", Media="(max-width: 950px)"},
            //                //    new PictureSourceContent{ Srcset="./img/winterm.png"},
            //                //    new ImageContent{ Src="./img/winterm", Alt="CLI Landing Page"}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 40,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "As always, the stock functionality with Windows is lacked and this time its with Git on Powershell & Command Prompt... " },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 41,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new LinkContent{ Value="PoshGit", Href="https://github.com/dahlbyk/posh-git"},
            //                //    new HTMLContent{ Value= "a powershell module, once imported, allows auto completion for all git commands. This makes life easier as less typing is required to navigate daily tasks." },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 42,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent> { new HTMLContent { Value = "The Shell category harbours everything which will alter the installed shell(s) themselves such as changing default powershell versions or installing WSL on localhost etc." } }
            //            },
            //            new Detail
            //            {
            //                Id = 43,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "This is a pre configured WSL2 instance which had been exported and put online for easy consumption." },
            //                //    new HTMLContent{ Value= " The purpose of this is to encapsulate basic linux setup and provide a ready developer environment for common tasks." },
            //                //    new HTMLContent{ Value= " It comes with " },
            //                //    new LinkContent{ Value="Zsh", Href="https://www.zsh.org/"},
            //                //    new HTMLContent{ Value= " as well as " },
            //                //    new LinkContent{ Value="Oh My Zsh.", Href="https://ohmyz.sh/"},
            //                //    new HTMLContent{ Value= " Zsh is the default shell which OSX systems are shipped with and OhMyZsh is a framework for adding magic to it!" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 44,

            //                Type = ContentType.Warning,
            //                //Contents = new List<HTMLContent> { new HTMLContent { Value = "The features & plugins are not limited to the ones demonstrated below!" } }
            //            },
            //            new Detail
            //            {
            //                Id = 45,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "Themes could be configured on Oh My Zsh and all the themes which exist for Oh My Posh also exist for Oh My Zsh if not more! all existing " },
            //                //    new LinkContent{ Value="Oh My Zsh Themes", Href="https://github.com/ohmyzsh/ohmyzsh/wiki/Themes"},
            //                //    new HTMLContent{ Value= "could be found in the given link! " },
            //                //    new HTMLContent{ Value= " The Sinda Ubuntu comes with the theme \"agnoster\" but this can easily be changed by amending the .zshrc file." },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 46,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "First look on the .zshrc file:" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 47,

            //                Type = ContentType.Picture,
            //                //Contents = new List<HTMLContent>{
            //                //    new PictureSourceContent{ Srcset="./img/zsh-rc.png" },
            //                //    new ImageContent{ Src="./img/zsh-rc.png", Alt="First look on .zshrc file"}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 48,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "As shown in the image above, Oh My Zsh can be configured with many " },
            //                //    new LinkContent{ Value="plugins,", Href="https://github.com/ohmyzsh/ohmyzsh/wiki/Plugins"},
            //                //    new HTMLContent{ Value= " plugins which make life convenient! The Sinda Ubuntu comes with the git, debian, alias-finder, docker, command-not-found, thefuck & docker." },
            //                //    new HTMLContent{ Value= " These of course can be changed by editing the plugins array. Below are some images demonstrating the Zsh & Oh My Zsh features further!" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 49,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "Thefuck:" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 50,

            //                Type = ContentType.Picture,
            //                //Contents = new List<HTMLContent>{
            //                //    new PictureSourceContent{ Srcset="./img/zsh-thefuck.png" },
            //                //    new ImageContent{ Src="./img/zsh-thefuck.png", Alt="Thefuck demo"}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 51,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "Git branch display:" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 52,

            //                Type = ContentType.Picture,
            //                //Contents = new List<HTMLContent>{
            //                //    new PictureSourceContent{ Srcset="./img/zsh-git-branch.png" },
            //                //    new ImageContent{ Src="./img/zsh-git-branch.png", Alt="git branch display demo"}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 53,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "Auto complete & switch on tab key:" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 54,

            //                Type = ContentType.Picture,
            //                //Contents = new List<HTMLContent>{
            //                //    new PictureSourceContent{ Srcset="./img/zsh-tab-switch.png" },
            //                //    new ImageContent{ Src="./img/zsh-tab-switch.png", Alt="auto complete  demo"}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 55,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "Autocorrect:" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 56,

            //                Type = ContentType.Picture,
            //                //Contents = new List<HTMLContent>{
            //                //    new PictureSourceContent{ Srcset="./img/zsh-autocorrect.png" },
            //                //    new ImageContent{ Src="./img/zsh-autocorrect.png", Alt="auto correction demo"}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 57,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "Alias finder:" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 58,

            //                Type = ContentType.Picture,
            //                //Contents = new List<HTMLContent>{
            //                //    new PictureSourceContent{ Srcset="./img/zsh-alias-finder.png" },
            //                //    new ImageContent{ Src="./img/zsh-alias-finder.png", Alt="alias finder demo"}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 59,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "Command not found:" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 60,

            //                Type = ContentType.Picture,
            //                //Contents = new List<HTMLContent>{
            //                //    new PictureSourceContent{ Srcset="./img/zsh-command-not-found.png" },
            //                //    new ImageContent{ Src="./img/zsh-command-not-found.png", Alt="command not found demo"}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 61,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent> { new HTMLContent { Value = "The Virtualization category includes scripts for installing toolsets & software such as Docker / Podman which make it easier to consume / ship software by professionals." } }
            //            },
            //            new Detail
            //            {
            //                Id = 62,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "This installs " },
            //                //    new LinkContent{ Value="Docker Desktop", Href="https://www.docker.com/products/docker-desktop"},
            //                //    new HTMLContent{ Value= " with the WSL2 backend through the chocolatey package manager. Historically very difficult to achieve but today its not even a few lines of code, what a time to be alive!" },
            //                // }
            //            },
            //            new Detail
            //            {
            //                Id = 63,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "Much like Docker, " },
            //                //    new LinkContent{ Value="Podman", Href="https://podman.io/"},
            //                //    new HTMLContent{ Value= " is a software for managing OCI Containers, this installation is provided as an alternative for the ones who prefer it instead of Docker." },
            //                // }
            //            },
            //            new Detail
            //            {
            //                Id = 64,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent> { new HTMLContent { Value = "The scripts under this section are all about giving developers more power by making internal Sinda tools available. The tools function as encapsulation on certain tasks into one liners." } }
            //            },
            //             new Detail
            //             {
            //                 Id = 65,

            //                 Type = ContentType.Paragraph,
            //                 //Contents = new List<HTMLContent>{
            //                                    //new HTMLContent{ Value= "This is a Powershell module & an exact copy of the internal scripts used with the CLI tool wrapped in an easily importable format." },
            //                                    //new HTMLContent{ Value= "the command imports the module located at src/script/Sindagal.psm1 into the powershell profile of the user using the machine" },
            //                                    //new HTMLContent{ Value= "Once the module is imported, the developer gains direct access to all the features included in the CLI & more through direct powershell commands!" },
            //                                //}
            //             },
            //            new Detail
            //            {
            //                Id = 66,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "All the commands could be inspected in the file location mentioned within the CLI repository, however some of them are explained below." },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 67,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "To check the current state of your system for things such as os version, architecture, wsl2 support etc: "}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 68,

            //                Type = ContentType.Code,
            //                //Contents = new List<HTMLContent>{
            //                //    new CodeContent{ Language="shell", Value= "Get-EnvState" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 69,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "To install WSL on legacy systems where WSL2 or wsl --install command are not supported "}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 70,

            //                Type = ContentType.Code,
            //                //Contents = new List<HTMLContent>{
            //                //    new CodeContent{ Language="shell", Value= "Enable-WSLLegacy" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 71,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "To download & import the Sinda pre configured wsl2 instance:"}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 72,

            //                Type = ContentType.Code,
            //                //Contents = new List<HTMLContent>{
            //                //    new CodeContent{ Language="shell", Value= "Add-SindaDistro" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 73,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "Check if terminal session has admin rights:"}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 74,

            //                Type = ContentType.Code,
            //                //Contents = new List<HTMLContent>{
            //                //    new CodeContent{ Language="shell", Value= "Test-Elevation" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 75,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "Install & Configure Windows Terminal with Nerd Fonts:"}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 76,

            //                Type = ContentType.Code,
            //                //Contents = new List<HTMLContent>{
            //                //    new CodeContent{ Language="shell", Value= "Enable-WindowsTerminal" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 77,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "Disable & delete Windows Terminal:"}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 78,

            //                Type = ContentType.Code,
            //                //Contents = new List<HTMLContent>{
            //                //    new CodeContent{ Language="shell", Value= "Disable-WindowsTerminal" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 79,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //        new HTMLContent{ Value= "And many more!" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 80,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent> { new HTMLContent { Value = "The Boilerplate section contains scripts which clone Ready to go Sinda Codebases from github. The repositories are intended to solve common problems & be as easily personalized as possible." } }
            //            },
            //            new Detail
            //            {
            //                Id = 81,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "This clones a reusable & extensible web portfolio template written with React using the NextJS framework. The repository could be found " },
            //                //    new LinkContent{ Value="here.", Href="https://github.com/denzii/sinda-portfolio"},
            //                //    new HTMLContent{ Value= "This simplistic portfolio itself has basic SEO optimizations, keyboard and developer accessibility; a performant " },
            //                //    new LinkContent{ Value="Chrome Lighthouse", Href="https://developers.google.com/web/tools/lighthouse"},
            //                //    new HTMLContent{ Value= " score as well as good responsive UI/UX principles!" },
            //                //    new HTMLContent{ Value= " Feel free to change the data & reupload it to your favourite version-control website as you please!" },
            //                //  }
            //            },
            //            new Detail
            //            {
            //                Id = 82,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "For more information regarding this template & web theme, please refer to the Boilerplate tab on this page." },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 83,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "Do you have some boilerplate code which you always have to write from scratch? Are you in a hurry to get up and running with an MVP?" },
            //                //    new HTMLContent{ Value= " Sindagal Boilerplates will come to your rescue!" },
            //                //    new HTMLContent{ Value= " On this page, we will be exploring how to set up and work with existing code as well as how to extend them to our needs to save time from cumbersome work!" } }
            //           },
            //            new Detail
            //            {
            //                Id = 84,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "Planning to look for that next challange in your career but do not have time to fiddle with UI/UX or write the code for a portfolio website from scratch?" },
            //                //    new HTMLContent{ Value= " You can now rest easy with this " },
            //                //    new LinkContent{ Value="web portfolio.", Href="https://github.com/denzii/sinda-portfolio"},
            //                //    new HTMLContent{ Value= " This template simplistic enough to do the job and will hit the spot with its SEO optimizations, keyboard and developer accessibility; a performant " },
            //                //    new LinkContent{ Value="Lighthouse", Href="https://developers.google.com/web/tools/lighthouse"},
            //                //    new HTMLContent{ Value= " score as well as good responsive UI/UX principles!" },
            //                //    new HTMLContent{ Value= " please find a live example at" },
            //                //    new LinkContent{ Value="denizarca.com", Href="https://denizarca.com"} },
            //            },
            //            new Detail
            //            {
            //                Id = 85,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "This is a NextJS TypeScript project so NodeJS & npm are required as a prerequisite." },
            //                //    new HTMLContent{ Value= "If those already exist on the machine or if you are using the pre configured WSL instance, its okay to proceed to cloning the repository." },
            //                //},
            //            },
            //            new Detail
            //            {
            //                Id = 86,

            //                Type = ContentType.Code,
            //                //Contents = new List<HTMLContent>{
            //                //    new CodeContent{ Language="shell", Value= "git clone https://github.com/denzii/sinda-portfolio.git" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 87,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "Install Nextjs globally:" },
            //                //},
            //            },
            //            new Detail
            //            {
            //                Id = 88,

            //                Type = ContentType.Code,
            //                //Contents = new List<HTMLContent>{
            //                //    new CodeContent{ Language="shell", Value= "npm i -g next" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 89,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //        new HTMLContent{ Value= "Move into the repository, install dependencies and run the app:" },
            //                //    },

            //            },
            //            new Detail
            //            {
            //                Id = 90,

            //                Type = ContentType.Code,
            //                //Contents = new List<HTMLContent>{
            //                //    new CodeContent{ Language="shell", Value= "cd sinda-portfolio" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 91,

            //                Type = ContentType.Code,
            //                //Contents = new List<HTMLContent>{
            //                //    new CodeContent{ Language="shell", Value= "npm install" },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 92,

            //                Type = ContentType.Code,
            //                //Contents = new List<HTMLContent>{
            //                //    new CodeContent{ Language="shell", Value= "npm run dev" },
            //                //}
            //            },

            //            new Detail
            //            {
            //                Id = 93,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "If everything went well, it's now okay to visit localhost:3000 in your favourite browser to see the site!" },
            //                //},
            //            },
            //            new Detail
            //            {
            //                Id = 94,

            //                Type = ContentType.Picture,
            //                //Contents = new List<HTMLContent>{
            //                //    new PictureSourceContent{ Srcset="./img/portfolio-landing-page-850w.png", Media="(max-width: 950px)"},
            //                //    new PictureSourceContent{ Srcset="./img/portfolio-landing-page.png"},
            //                //    new ImageContent{ Src="./img/portfolio-landing-page.png", Alt="Portfolio Landing Page"}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 95,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "Not bad! In order to personalize it, we need to make a few tweaks." },
            //                //    new HTMLContent{ Value= " The data is pulled into a single class at " },
            //                //    new LinkContent{ Value="data/index.ts", Href="https://github.com/denzii/sinda-portfolio/blob/main/data/index.ts"},
            //                //    new HTMLContent{ Value= " class for the most part and this is where we will spend most of our time." },
            //                //    new HTMLContent{ Value= " having said that, the page title and the meta tags for SEO as well as canonical must also be changed for a fully personalized portfolio. In a NextJS project, these are stored in " },
            //                //    new LinkContent{ Value="pages/_document.tsx", Href="https://github.com/denzii/sinda-portfolio/blob/main/pages/_document.tsx"},
            //                //    new HTMLContent{ Value= " as per convention. It is planned to pull these into the data folder in the future as well!" },
            //                //},
            //            },
            //            new Detail
            //            {
            //                Id = 96,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "Let's view the code in our favourite code editor and see how to go about the modifications!" },
            //                //},
            //            },
            //            new Detail
            //            {
            //                Id = 97,

            //                Type = ContentType.Code,
            //                //Contents = new List<HTMLContent>{
            //                //    new CodeContent{ Language="shell", Value= "code ." },
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 98,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "To start things off, lets change the navigation bar contents by changing the ProjectOwner, PersonalURLs & PersonalBackground Objects as shown." },
            //                //},
            //            },
            //            new Detail
            //            {
            //                Id = 99,

            //                Type = ContentType.Picture,
            //                //Contents = new List<HTMLContent>{
            //                //    new PictureSourceContent{ Srcset="./img/portfolio-navbar-name-diff-850w.png", Media="(max-width: 950px)"},
            //                //    new PictureSourceContent{ Srcset="./img/portfolio-navbar-name-diff.png",},
            //                //    new ImageContent{ Src="./img/portfolio-navbar-name-diff.png", Alt="Portfolio Navbar modification"}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 100,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= " Icons for social media could be changed by supplying a name from the " },
            //                //    new LinkContent{ Value="React Font Awesome", Href="https://react-icons.github.io/react-icons/icons?name=fa"},
            //                //    new HTMLContent{ Value= " Icons. Additional navigation links such as \"instagram\" could also be added or removed if desired by altering the keys on the" },
            //                //    new LinkContent{ Value="interface/personalUrls.ts", Href="https://github.com/denzii/sinda-portfolio/blob/main/interface/personalUrls.ts"},
            //                //    new HTMLContent{ Value= " class further. For demonstration purposes, lets remove the email icon while changing the other two icons." },
            //                //},
            //            },
            //            new Detail
            //            {
            //                Id = 101,

            //                Type = ContentType.Picture,
            //                //Contents = new List<HTMLContent>{
            //                //    new PictureSourceContent{ Srcset="./img/portfolio-socialbar-diff-850w.png", Media="(max-width: 950px)"},
            //                //    new PictureSourceContent{ Srcset="./img/portfolio-socialbar-diff.png",},
            //                //    new ImageContent{ Src="./img/portfolio-socialbar-diff.png", Alt="Portfolio Socialbar modification"}
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 102,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= " The keys on the object " },
            //                //    new LinkContent{ Value="interface/background.ts", Href="https://github.com/denzii/sinda-portfolio/blob/main/interface/background.ts"},
            //                //    new HTMLContent{ Value= " are used to generate the sections below the hero section. If we wanted to add or remove or alter a section, all we would need to do is to alter the keys on it!" },
            //                //    new HTMLContent{ Value= " for the sake of this tutorial, let's remove the hobbies section and rename some of the others!" },
            //                //},
            //            },
            //            new Detail
            //            {
            //                Id = 103,

            //                Type = ContentType.Picture,
            //                //Contents = new List<HTMLContent>{
            //                //    new PictureSourceContent{ Srcset="./img/portfolio-navbar-elems-diff-850w.png", Media="(max-width: 950px)"},
            //                //    new PictureSourceContent{ Srcset="./img/portfolio-navbar-elems-diff.png",},
            //                //    new ImageContent{ Src="./img/portfolio-navbar-elems-diff.png", Alt="Portfolio Navbar elements modification" }
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 104,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= " Now that those are out of the way, its a good time to change the background and the headshot images which are located inside the " },
            //                //    new LinkContent{ Value="public", Href="https://github.com/denzii/sinda-portfolio/tree/main/public"},
            //                //    new HTMLContent{ Value= " directory, all that is required is to drop in the images in that directory and reference them inside the data class. The app is written flexible enough to allow the usage of different image names as-well!" },
            //                //},
            //            },
            //            new Detail
            //            {
            //                Id = 105,

            //                Type = ContentType.Picture,
            //                //Contents = new List<HTMLContent>{
            //                //    new PictureSourceContent{ Srcset="./img/portfolio-hero-diff.png",},
            //                //    new ImageContent{ Src="./img/portfolio-hero-diff.png", Alt="Portfolio hero images modification" }
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 106,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //   new HTMLContent{ Value= "We've come a long way and the results are just beautiful! Refresh the browser page to see that the website now looks like this: " },
            //                //},
            //            },
            //            new Detail
            //            {
            //                Id = 107,

            //                Type = ContentType.Picture,
            //                //Contents = new List<HTMLContent>{
            //                //    new PictureSourceContent{ Srcset="./img/portfolio-altered-hero-diff-850w.png", Media="(max-width: 950px)"},
            //                //    new PictureSourceContent{ Srcset="./img/portfolio-altered-hero-diff.png",},
            //                //    new ImageContent{ Src="./img/portfolio-altered-hero-diff.png", Alt="Portfolio altered hero section" }
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 108,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "How about the body sections? Are they even flexible enough for personalization? They sure are! All that needs to be done is to alter the methods which are being called within the \"PersonalBackground\" method inside the data class." },
            //                //    new HTMLContent{ Value= " The heading, date range & inner content are supplied within the same place, the inner content could be made bold, italic or emphasized on demand without touching any HTML." },

            //                //},
            //            },
            //            new Detail
            //            {
            //                Id = 109,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= " If it's a semantic markup for your website which you are looking for; you can add emphasis and other things to certain text but also keep it unstyled." },
            //                //    new HTMLContent{ Value= " This is a good idea if you would like your website to read well by screen readers so elements could be emphesized without changing the visual feeling..." },
            //                //    new HTMLContent{ Value= " The body elements could be given captions aswell by assigning the \"caption\" field a string value." },
            //                //},
            //            },
            //            new Detail
            //            {
            //                Id = 110,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "Example body section element code:" },
            //                //},
            //            },
            //            new Detail
            //            {
            //                Id = 111,

            //                Type = ContentType.Picture,
            //                //Contents = new List<HTMLContent>{
            //                //    new PictureSourceContent{ Srcset="./img/portfolio-body-code.png", Media="(max-width: 950px)"},
            //                //    new ImageContent{ Src="./img/portfolio-body-code.png", Alt="Portfolio body code example" }
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 112,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "Only one thing remains, changing the meta content of the site! And this is as easy as going into the pages/_document.tsx" },
            //                //    new LinkContent{ Value="pages/_document.tsx", Href="https://github.com/denzii/sinda-portfolio/tree/main/public"},
            //                //    new HTMLContent{ Value= " file and altering the given strings." },
            //                //    new HTMLContent{ Value= " add in the full address of your domain as a canonical, change the tab title as you wish and amend the keywords to cater to your target audiences google searches." },
            //                //},
            //            },
            //            new Detail
            //            {
            //                Id = 113,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "That is all! Enjoy your Sinda Portfolio and do not forget to give a star or send your pull requests!" },
            //                //    new HTMLContent{ Value= " We will not be touching on how to deploy this website since it is using the stock CI/CD which is provided by Vercel for free on personal projects." },
            //                //    new HTMLContent{ Value= " To find out more about deployments, visit their tutorials at " },
            //                //    new LinkContent{ Value="nextjs.org/deployment", Href="https://nextjs.org/docs/deployment"},
            //                //},
            //            },
            //            new Detail
            //            {
            //                Id = 114,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //     new HTMLContent{ Value= "We've come a long way and the results are just beautiful! Refresh the browser page to see that the website now looks like this: " },
            //                //},
            //            },
            //            new Detail
            //            {
            //                Id = 115,

            //                Type = ContentType.Picture,
            //                //Contents = new List<HTMLContent>{
            //                //    new PictureSourceContent{ Srcset="./img/portfolio-altered-hero-diff-850w.png", Media="(max-width: 950px)"},
            //                //    new PictureSourceContent{ Srcset="./img/portfolio-altered-hero-diff.png",},
            //                //    new ImageContent{ Src="./img/portfolio-altered-hero-diff.png", Alt="Portfolio altered hero section" }
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 116,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "How about the body sections? Are they even flexible enough for personalization? They sure are! All that needs to be done is to alter the methods which are being called within the \"PersonalBackground\" method inside the data class." },
            //                //    new HTMLContent{ Value= " The heading, date range & inner content are supplied within the same place, the inner content could be made bold, italic or emphasized on demand without touching any HTML." },

            //                //},
            //            },
            //            new Detail
            //            {
            //                Id = 117,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= " If it's a semantic markup for your website which you are looking for; you can add emphasis and other things to certain text but also keep it unstyled." },
            //                //    new HTMLContent{ Value= " This is a good idea if you would like your website to read well by screen readers so elements could be emphesized without changing the visual feeling..." },
            //                //    new HTMLContent{ Value= " The body elements could be given captions aswell by assigning the \"caption\" field a string value." },
            //                //},
            //            },
            //            new Detail
            //            {
            //                Id = 118,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "Example body section element code:" },
            //                //},
            //            },
            //            new Detail
            //            {
            //                Id = 119,

            //                Type = ContentType.Picture,
            //                //Contents = new List<HTMLContent>{
            //                //    new PictureSourceContent{ Srcset="./img/portfolio-body-code.png", Media="(max-width: 950px)"},
            //                //    new ImageContent{ Src="./img/portfolio-body-code.png", Alt="Portfolio body code example" }
            //                //}
            //            },
            //            new Detail
            //            {
            //                Id = 120,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "Only one thing remains, changing the meta content of the site! And this is as easy as going into the pages/_document.tsx" },
            //                //    new LinkContent{ Value="pages/_document.tsx", Href="https://github.com/denzii/sinda-portfolio/tree/main/public"},
            //                //    new HTMLContent{ Value= " file and altering the given strings." },
            //                //    new HTMLContent{ Value= " add in the full address of your domain as a canonical, change the tab title as you wish and amend the keywords to cater to your target audiences google searches." },
            //                //},
            //            },
            //            new Detail
            //            {
            //                Id = 121,

            //                Type = ContentType.Paragraph,
            //                //Contents = new List<HTMLContent>{
            //                //    new HTMLContent{ Value= "That is all! Enjoy your Sinda Portfolio and do not forget to give a star or send your pull requests!" },
            //                //    new HTMLContent{ Value= " We will not be touching on how to deploy this website since it is using the stock CI/CD which is provided by Vercel for free on personal projects." },
            //                //    new HTMLContent{ Value= " To find out more about deployments, visit their tutorials at " },
            //                //    new LinkContent{ Value="nextjs.org/deployment", Href="https://nextjs.org/docs/deployment"},
            //                //},
            //            }
            //        );


            //        modelBuilder.Entity<Section>().HasData(
            //                                new Section {
            //                                    Id="introduction",
            //                                    Header="Introduction",
            //                                    HasMainContent=true,
            //                                    //Details= new List<Detail>{
            //                                    //   new Detail{
            //                                    //        Contents= new List<HTMLContent>{
            //                                    //            new HTMLContent{ Value= "Sindagal " },
            //                                    //            new LinkContent{ Value= "Command Line Interface", Href="https://github.com/denzii/sinda-cli" },
            //                                    //            new HTMLContent{ Value= " is a simple Node.js application which makes use of the popular JavaScript framework React. The goal is to make developer lives more convenient by wrapping around operating system level scripts and allowing their easy consumption." }
            //                                    //        }
            //                                    //   },
            //                                    //   new Detail{
            //                                    //       Contents= new List<HTMLContent>{ new WarningContent{ Value= "For the time being, usages from within WSL & Unix based systems had been disabled." } }
            //                                    //   },
            //                                    //   new Detail{
            //                                    //       Contents= new List<HTMLContent>{ new HTMLContent { Value= "On this page, you'll learn what the Sinda Command Line Interface brings to the table and how it can be consumed by setting it up from scratch and consuming some of the built in automation scripts on a Windows machine." } }
            //                                    //   }
            //                                    //}
            //                                },
            //                                new Section{
            //                                  Id="setup",
            //                                  Header="Getting Started",
            //                                  HasMainContent=false,
            //                         //         Details= new List<Detail>{
            //                         //           new Detail{
            //                         //               Type=ContentType.Paragraph,
            //                         //               Contents= new List<HTMLContent>{
            //                         //                   new HTMLContent{ Value= "The project requires Node.js LTS and npm to be installed as a pre-requisite so if you do not already have them, now is a good time to set them up." },
            //                         //                   new LinkContent{ Value="This tutorial", Href="https://docs.microsoft.com/en-us/windows/dev-environment/javascript/nodejs-on-windows"},
            //                         //                   new HTMLContent{ Value= "by Microsoft demonstrates how they could be set on a Windows machine using the Node Version Manager tool (NVM)."}
            //                         //               }
            //                         //           },
            //                         //           new Detail{
            //                         //               Type=ContentType.Paragraph,
            //                         //               Contents= new List<HTMLContent>{
            //                         //                   new HTMLContent{ Value="Once NVM & Node.js are configured, we could proceed to cloning the repository and running the app from the cloned source code. Its necessary to fork and/or clone the repository since the app itself requires access to the localhost machine so it can run powershell/bash scripts."}
            //                         //               }
            //                         //           },
            //                         //           new Detail{
            //                         //               Type=ContentType.Code,
            //                         //               Contents= new List<HTMLContent>{
            //                         //                   new CodeContent{Language="shell", Value="git clone https://github.com/denzii/sinda-cli.git"}
            //                         //               }
            //                         //           },
            //                         //           new Detail{
            //                         //               Type=ContentType.Code,
            //                         //               Contents= new List<HTMLContent>{
            //                         //                   new CodeContent{Language="shell", Value="cd sinda-cli"}
            //                         //               }
            //                         //           },
            //                         //           new Detail{
            //                         //               Type=ContentType.Code,
            //                         //               Contents= new List<HTMLContent>{
            //                         //                   new CodeContent{Language="shell", Value="npm start"}
            //                         //               }
            //                         //           },
            //                         //           new Detail{
            //                         //               Type=ContentType.Warning,
            //                         //               Contents= new List<HTMLContent>{ new HTMLContent{ Value= "The app requires administrator rights to run Powershell / Bash scripts on localhost, if its run from a non-elevated terminal session, it will result in an error and not run." } }
            //                         //           },
            //                         //           new Detail{
            //                         //               Type=ContentType.Paragraph,
            //                         //               Contents= new List<HTMLContent>{
            //                         //                   new HTMLContent{Value="The following image demonstrates the landing page for a successfully started CLI."}
            //                         //               }
            //                         //           },
            //                         //           new Detail{
            //                         //               Type=ContentType.Picture,
            //                         //               Contents= new List<HTMLContent>{
            //                         //                   new PictureSourceContent{ Srcset="./img/cli-landing-page-850w.png", Media="(max-width: 950px)"},
            //                         //                   new PictureSourceContent{ Srcset="./img/cli-landing-page.png"},
            //                         //                   new ImageContent{ Src="./img/cli-landing-page.png", Alt="CLI Landing Page"}
            //                         //               }
            //                         //           },

            //                         //}
            //                       },
            //                       new Section {
            //                            Id="usage",
            //                            Header="Usage",
            //                            HasMainContent=false,
            //                         //   Details= new List<Detail>{
            //                         //      new Detail{
            //                         //           Type=ContentType.Paragraph,
            //                         //           Contents= new List<HTMLContent>{
            //                         //               new HTMLContent{ Value= "Consuming scripts from the app is pretty straight forward and takes only a few key-presses to achieve. As seen on the landing page image, the terminal prompt functions similarly to a single page app and the visible part of the terminal is hijacked by a" },
            //                         //               new LinkContent{ Value="React Ink", Href="https://github.com/vadimdemedes/ink"},
            //                         //               new HTMLContent{ Value= "Component" },
            //                         //           }

            //                         //      },
            //                         //      new Detail{
            //                         //          Type=ContentType.Paragraph,
            //                         //          Contents= new List<HTMLContent>{ new HTMLContent{ Value= "The component itself detects the screen height and width and resizes accordingly. Having said that, a maximized terminal window is recommended for the best experience and the resizing  feature is only meant for the application startup. If the terminal window gets resized while the app is running, there are no guarantees for correct rendering of the component." } }
            //                         //      },
            //                         //      new Detail{
            //                         //          Type=ContentType.Paragraph,
            //                         //          Contents= new List<HTMLContent>{ new HTMLContent{ Value= "Once a key is pressed on the landing page, the survey component is rendered and the user is presented with all the available automation scripts... Navigation of the form is achieved through the <i>Up / Down / Enter & Esc </i> keys. This component is demonstrated in the following image." } }
            //                         //      },
            //                         //      new Detail{
            //                         //       Type=ContentType.Picture,
            //                         //       Contents= new List<HTMLContent>{
            //                         //           new PictureSourceContent{ Srcset="./img/cli-survey-page-850w.png", Media="(max-width: 950px)"},
            //                         //           new PictureSourceContent{ Srcset="./img/cli-survey-page.png"},
            //                         //           new ImageContent{ Src="./img/cli-survey-page.png", Alt="CLI Survey Page"}
            //                         //       }
            //                         //     },
            //                         //     new Detail{
            //                         //          Type=ContentType.Paragraph,
            //                         //          Contents= new List<HTMLContent>{ new HTMLContent{  Value= "For the sake of this tutorial, we are only going to be selecting the first three options. Once the selections are made, it is required to navigate to the last page of the survey and confirm the selections.  The \"proceed\" button will ask for a re-confirmation and esc key could be used to go back to the form."},  }
            //                         //     },
            //                         //     new Detail{
            //                         //       Type=ContentType.Picture,
            //                         //       Contents= new List<HTMLContent>{
            //                         //           new PictureSourceContent{ Srcset="./img/cli-survey-page-confirmation-850w.png", Media="(max-width: 950px)"},
            //                         //           new PictureSourceContent{ Srcset="./img/cli-survey-page-confirmation.png"},
            //                         //           new ImageContent{ Src="./img/cli-survey-page-confirmation.png", Alt="CLI Survey Page Confirmation"}
            //                         //       }
            //                         //     },
            //                         //     new Detail{
            //                         //          Type=ContentType.Paragraph,
            //                         //          Contents= new List<HTMLContent>{ new HTMLContent{ Value= "Prior to making any changes to the machine, all the selected features and their corresponding scripts are listed and a confirmation is requested once more for extra safety."} }
            //                         //     },
            //                         //     new Detail{
            //                         //       Type=ContentType.Picture,
            //                         //       Contents= new List<HTMLContent>{
            //                         //           new PictureSourceContent{ Srcset="./img/cli-survey-page-confirmation-2-850w.png", Media="(max-width: 950px)"},
            //                         //           new PictureSourceContent{ Srcset="./img/cli-survey-page-confirmation-2.png"},
            //                         //           new ImageContent{ Src="./img/cli-survey-page-confirmation-2.png", Alt="CLI Survey Page Finalization"}
            //                         //       }
            //                         //     },
            //                         //     new Detail{
            //                         //       Type=ContentType.Warning,
            //                         //       Contents= new List<HTMLContent>{ new HTMLContent{ Value= "For the time being, the scripts are executed syncronously and the results within the box are updated all at once." } }
            //                         //     },
            //                         //     new Detail{
            //                         //          Type=ContentType.Paragraph,
            //                         //          Contents= new List<HTMLContent>{ new HTMLContent{ Value= "The Standard Outputs as well as Errors for the executed commands are pushed above the component box in real-time. A finished session is demonstrated in the below image."} }
            //                         //     },
            //                         //     new Detail{
            //                         //       Type=ContentType.Picture,
            //                         //       Contents= new List<HTMLContent>{
            //                         //           new PictureSourceContent{ Srcset="./img/cli-survey-page-results-850w.png", Media="(max-width: 950px)"},
            //                         //           new PictureSourceContent{ Srcset="./img/cli-survey-page-results.png"},
            //                         //           new ImageContent{ Src="./img/cli-survey-page-results.png", Alt="CLI Survey Page Results"}
            //                         //       }
            //                         //     },
            //                         //     new Detail{
            //                         //          Type=ContentType.Paragraph,
            //                         //          Contents= new List<HTMLContent>{ new HTMLContent{ Value= "Thats all folks! See how easy it was to consume some powershell scripts? To see the full list of the existing scripts, please navigate to the scripts tab on this page."} }
            //                         //     },
            //                         //}
            //                    },
            //                       new Section
            //                       {
            //                           Id = "Introduction",
            //                           Header = "Introduction",
            //                           HasMainContent = true,
            //                        //   Details = new List<Detail>{
            //                        //   new Detail{
            //                        //        Type=ContentType.Paragraph,
            //                        //        Contents= new List<HTMLContent>{
            //                        //            new HTMLContent{ Value= "As described in the Terminal tab, Sindagal comes with some built-in scripts and can also be extended to interface to personal scripts. The scripts are categorized as Terminal, Shell, Virtual, SDK & Boilerplate." },
            //                        //            new HTMLContent{ Value= " The CLI tool works by executing powershell / bash scripts which exist inside the code repository itself under the src/scripts directory." } }
            //                        //   },
            //                        //   new Detail {
            //                        //        Type=ContentType.Paragraph,
            //                        //        Contents=new List<HTMLContent>{
            //                        //            new HTMLContent{ Value=" On this page, we will be exploring the various details regarding those features and why they might come in handy for you or your organisation."}
            //                        //        }
            //                        //   },
            //                        //   new Detail{
            //                        //       Type=ContentType.Warning,
            //                        //       Contents= new List<HTMLContent>{
            //                        //           new HTMLContent{ Value= "For the time being, everything is in the Minimum Viable Product stage & things might change in the future. Please report any problems or bugs to me personally through my " },
            //                        //           new LinkContent{ Value= "Linkedin.", Href="https://www.linkedin.com/in/denizarca/" },
            //                        //           new HTMLContent{ Value= " Pull requests are welcome at the " },
            //                        //           new LinkContent{ Value= "CLI repository.", Href="https://github.com/denzii/sinda-cli" },
            //                        //       }
            //                        //   },
            //                        //}
            //                       },
            //                    new Section
            //                    {
            //                        Id = "terminal",
            //                        HasMainContent = true,
            //                        Header = "Terminal Extensions",
            //                        //Details = new List<Detail>{
            //                        //   new Detail{
            //                        //       Type=ContentType.Paragraph,
            //                        //       Contents= new List<HTMLContent>{ new HTMLContent{ Value= "This category is where the scripts regarding the interactive terminal session reside. These will alter the look & feel of your interactions with your local shell." } }
            //                        //   }
            //                        //}
            //                    },
            //                    new Section
            //                    {
            //                        Id = "ohmyposh",
            //                        Header = "1) Oh My Posh & Nerd Fonts",
            //                        //Details = new List<Detail>{
            //                        //   new Detail{
            //                        //        Type=ContentType.Paragraph,
            //                        //        Contents= new List<HTMLContent>{
            //                        //           new HTMLContent{ Value= "By default, terminal prompts on Windows machines come with no support for user themes, lack descriptiveness and are not intuitive to use. Wouldn't it be nice if the sessions could be personalized & extended with additional information such as the time of command execution, git active branch names, battery level and more?" },
            //                        //           new HTMLContent{ Value= " Enter " },
            //                        //           new LinkContent{ Value= "Oh My Posh!", Href="https://ohmyposh.dev/" },
            //                        //           new HTMLContent{ Value= " A shell framework for doing all of that! Historically this worked only on Windows but with Powershell going cross platform, it now works on Linux & Mac as well. " },
            //                        //        }
            //                        //   },
            //                        //   new Detail{
            //                        //       Type=ContentType.Paragraph,
            //                        //       Contents= new List<HTMLContent>{
            //                        //           new HTMLContent{ Value= "The framework is easily configurable... All available themes could be reviewed by: " },
            //                        //       }
            //                        //   },
            //                        //   new Detail{
            //                        //        Type=ContentType.Code,
            //                        //        Contents= new List<HTMLContent>{
            //                        //           new CodeContent{ Language="shell", Value= "Get-PoshThemes" },
            //                        //        }
            //                        //   },
            //                        //   new Detail{
            //                        //       Type=ContentType.Paragraph,
            //                        //       Contents= new List<HTMLContent>{
            //                        //           new HTMLContent{ Value= "changing the theme to \"Darkblood\": " },
            //                        //       }
            //                        //   },
            //                        //   new Detail{
            //                        //        Type=ContentType.Code,
            //                        //        Contents= new List<HTMLContent>{
            //                        //           new CodeContent{ Language="shell", Value= "Set-PoshPrompt darkblood" },
            //                        //        }
            //                        //   },
            //                        //   new Detail{
            //                        //       Type=ContentType.Paragraph,
            //                        //       Contents= new List<HTMLContent>{
            //                        //           new HTMLContent{ Value= "Having said that, it is also possible to configure it via code by adjusting an init script at a location which can be found from the Get-PoshThemes command. " },
            //                        //       }
            //                        //   },
            //                        //   new Detail{
            //                        //       Type=ContentType.Paragraph,
            //                        //       Contents= new List<HTMLContent>{
            //                        //           new HTMLContent { Value= "Oh My Posh relies on a specific font family in order to display its many glyphs properly, Sinda takes care of installing the " },
            //                        //           new LinkContent { Value= "Nerd Fonts", Href="https://github.com/ryanoasis/nerd-fonts"},
            //                        //           new HTMLContent { Value= " for you!" },
            //                        //       }
            //                        //   }
            //                        //}
            //                    },
            //                    new Section
            //                    {
            //                        Id = "winterm",
            //                        Header = "2) Windows Terminal by Microsoft",
            //                     //   Details = new List<Detail>{
            //                     //   new Detail{
            //                     //       Type=ContentType.Paragraph,
            //                     //       Contents= new List<HTMLContent>{
            //                     //           new HTMLContent{ Value= "The default Powershell / Command Prompt & WSL terminal apps are some-what primitive, those emulators damage productivity. They are difficult to impossible to standardize, they require switching between windows which can get tedious & confusing from time to time and they lack certain features when it comes to keyboard shortcuts." },
            //                     //           new LinkContent{ Value= "Windows Terminal", Href="https://docs.microsoft.com/en-us/windows/terminal/" },
            //                     //           new HTMLContent{ Value= " intends to remedy the above problems by allowing multiple tabs, split screens, extensive keyboard macros and multi-shell support."},
            //                     //           new HTMLContent{ Value= " Tabs could contain any session ranging from Azure, WSL2, Remote SSH, Powershell & CMD!"},
            //                     //           new HTMLContent{ Value= " This powerful open source tool also allows launching sessions programatically through powershell commands."}
            //                     //       }
            //                     //   },
            //                     //   new Detail{
            //                     //       Type=ContentType.Paragraph,
            //                     //       Contents= new List<HTMLContent>{
            //                     //           new HTMLContent{ Value= "To start WSL Debian & Powershell sessions programatically: "}
            //                     //       }
            //                     //   },
            //                     //   new Detail{
            //                     //       Type=ContentType.Code,
            //                     //       Contents= new List<HTMLContent>{
            //                     //           new CodeContent{ Language="shell", Value= "wt -p \"Debian\" `; split-pane -p \"Windows PowerShell\" `;" },
            //                     //       }
            //                     //   },
            //                     //   new Detail{
            //                     //       Type=ContentType.Paragraph,
            //                     //       Contents= new List<HTMLContent>{
            //                     //           new HTMLContent{ Value= "Results in the following interactive sessions:"}
            //                     //       }
            //                     //   },
            //                     //   new Detail{
            //                     //       Type=ContentType.Picture,
            //                     //       Contents= new List<HTMLContent>{
            //                     //           new PictureSourceContent{ Srcset="./img/winterm-850w.png", Media="(max-width: 950px)"},
            //                     //           new PictureSourceContent{ Srcset="./img/winterm.png"},
            //                     //           new ImageContent{ Src="./img/winterm", Alt="CLI Landing Page"}
            //                     //       }
            //                     //   },
            //                     //}
            //                    },
            //                    new Section
            //                    {
            //                        Id = "poshgit",
            //                        Header = "3) Posh Git",
            //                        //Details = new List<Detail>{
            //                        //   new Detail{
            //                        //        Type=ContentType.Paragraph,
            //                        //        Contents= new List<HTMLContent>{
            //                        //            new HTMLContent{ Value= "As always, the stock functionality with Windows is lacked and this time its with Git on Powershell & Command Prompt... " },
            //                        //        }
            //                        //   },
            //                        //   new Detail{
            //                        //        Type=ContentType.Paragraph,
            //                        //        Contents= new List<HTMLContent>{
            //                        //            new LinkContent{ Value="PoshGit", Href="https://github.com/dahlbyk/posh-git"},
            //                        //            new HTMLContent{ Value= "a powershell module, once imported, allows auto completion for all git commands. This makes life easier as less typing is required to navigate daily tasks." },
            //                        //       }
            //                        //   },
            //                        //}
            //                    },
            //                    new Section
            //                    {
            //                        Id = "shell",
            //                        Header = "Shell Modifications",
            //                        HasMainContent = true,
            //                        //Details = new List<Detail>{
            //                           //new Detail{
            //                           //    Type=ContentType.Paragraph,
            //                           //    Contents= new List<HTMLContent>{ new HTMLContent{ Value= "The Shell category harbours everything which will alter the installed shell(s) themselves such as changing default powershell versions or installing WSL on localhost etc." } }
            //                           //},
            //                        //}
            //                    },
            //                    new Section
            //                    {
            //                        Id = "wsl",
            //                        Header = "1) SindaDistro",
            //                        //Details = new List<Detail>{
            //                        //   new Detail{
            //                        //        Type=ContentType.Paragraph,
            //                        //        Contents= new List<HTMLContent>{
            //                        //            new HTMLContent{ Value= "This is a pre configured WSL2 instance which had been exported and put online for easy consumption." },
            //                        //            new HTMLContent{ Value= " The purpose of this is to encapsulate basic linux setup and provide a ready developer environment for common tasks." },
            //                        //            new HTMLContent{ Value= " It comes with " },
            //                        //            new LinkContent{ Value="Zsh", Href="https://www.zsh.org/"},
            //                        //            new HTMLContent{ Value= " as well as " },
            //                        //            new LinkContent{ Value="Oh My Zsh.", Href="https://ohmyz.sh/"},
            //                        //            new HTMLContent{ Value= " Zsh is the default shell which OSX systems are shipped with and OhMyZsh is a framework for adding magic to it!" },
            //                        //        }
            //                        //   },
            //                        //  new Detail{
            //                        //    Type=ContentType.Warning,
            //                        //    Contents= new List<HTMLContent>{ new HTMLContent{ Value= "The features & plugins are not limited to the ones demonstrated below!" } }
            //                        //  },
            //                        //   new Detail{
            //                        //        Type=ContentType.Paragraph,
            //                        //        Contents= new List<HTMLContent>{
            //                        //            new HTMLContent{ Value= "Themes could be configured on Oh My Zsh and all the themes which exist for Oh My Posh also exist for Oh My Zsh if not more! all existing " },
            //                        //            new LinkContent{ Value="Oh My Zsh Themes", Href="https://github.com/ohmyzsh/ohmyzsh/wiki/Themes"},
            //                        //            new HTMLContent{ Value= "could be found in the given link! " },
            //                        //            new HTMLContent{ Value= " The Sinda Ubuntu comes with the theme \"agnoster\" but this can easily be changed by amending the .zshrc file." },
            //                        //        }
            //                        //   },
            //                        //   new Detail{
            //                        //        Type=ContentType.Paragraph,
            //                        //        Contents= new List<HTMLContent>{
            //                        //            new HTMLContent{ Value= "First look on the .zshrc file:" },
            //                        //        }
            //                        //   },
            //                        //   new Detail{
            //                        //        Type=ContentType.Picture,
            //                        //        Contents= new List<HTMLContent>{
            //                        //            new PictureSourceContent{ Srcset="./img/zsh-rc.png" },
            //                        //            new ImageContent{ Src="./img/zsh-rc.png", Alt="First look on .zshrc file"}
            //                        //        }
            //                        //   },
            //                        //   new Detail{
            //                        //        Type=ContentType.Paragraph,
            //                        //        Contents= new List<HTMLContent>{
            //                        //            new HTMLContent{ Value= "As shown in the image above, Oh My Zsh can be configured with many " },
            //                        //            new LinkContent{ Value="plugins,", Href="https://github.com/ohmyzsh/ohmyzsh/wiki/Plugins"},
            //                        //            new HTMLContent{ Value= " plugins which make life convenient! The Sinda Ubuntu comes with the git, debian, alias-finder, docker, command-not-found, thefuck & docker." },
            //                        //            new HTMLContent{ Value= " These of course can be changed by editing the plugins array. Below are some images demonstrating the Zsh & Oh My Zsh features further!" },
            //                        //        }
            //                        //   },
            //                        //   new Detail{
            //                        //        Type=ContentType.Paragraph,
            //                        //        Contents= new List<HTMLContent>{
            //                        //            new HTMLContent{ Value= "Thefuck:" },
            //                        //        }
            //                        //   },
            //                        //   new Detail{
            //                        //        Type=ContentType.Picture,
            //                        //        Contents= new List<HTMLContent>{
            //                        //            new PictureSourceContent{ Srcset="./img/zsh-thefuck.png" },
            //                        //            new ImageContent{ Src="./img/zsh-thefuck.png", Alt="Thefuck demo"}
            //                        //        }
            //                        //   },
            //                        //   new Detail{
            //                        //        Type=ContentType.Paragraph,
            //                        //        Contents= new List<HTMLContent>{
            //                        //            new HTMLContent{ Value= "Git branch display:" },
            //                        //        }
            //                        //   },
            //                        //   new Detail{
            //                        //        Type=ContentType.Picture,
            //                        //        Contents= new List<HTMLContent>{
            //                        //            new PictureSourceContent{ Srcset="./img/zsh-git-branch.png" },
            //                        //            new ImageContent{ Src="./img/zsh-git-branch.png", Alt="git branch display demo"}
            //                        //        }
            //                        //   },
            //                        //   new Detail{
            //                        //        Type=ContentType.Paragraph,
            //                        //        Contents= new List<HTMLContent>{
            //                        //            new HTMLContent{ Value= "Auto complete & switch on tab key:" },
            //                        //        }
            //                        //   },
            //                        //   new Detail{
            //                        //        Type=ContentType.Picture,
            //                        //        Contents= new List<HTMLContent>{
            //                        //            new PictureSourceContent{ Srcset="./img/zsh-tab-switch.png" },
            //                        //            new ImageContent{ Src="./img/zsh-tab-switch.png", Alt="auto complete  demo"}
            //                        //        }
            //                        //   },
            //                        //   new Detail{
            //                        //        Type=ContentType.Paragraph,
            //                        //        Contents= new List<HTMLContent>{
            //                        //            new HTMLContent{ Value= "Autocorrect:" },
            //                        //        }
            //                        //   },
            //                        //   new Detail{
            //                        //        Type=ContentType.Picture,
            //                        //        Contents= new List<HTMLContent>{
            //                        //            new PictureSourceContent{ Srcset="./img/zsh-autocorrect.png" },
            //                        //            new ImageContent{ Src="./img/zsh-autocorrect.png", Alt="auto correction demo"}
            //                        //        }
            //                        //   },
            //                        //   new Detail{
            //                        //        Type=ContentType.Paragraph,
            //                        //        Contents= new List<HTMLContent>{
            //                        //            new HTMLContent{ Value= "Alias finder:" },
            //                        //        }
            //                        //   },
            //                        //   new Detail{
            //                        //        Type=ContentType.Picture,
            //                        //        Contents= new List<HTMLContent>{
            //                        //            new PictureSourceContent{ Srcset="./img/zsh-alias-finder.png" },
            //                        //            new ImageContent{ Src="./img/zsh-alias-finder.png", Alt="alias finder demo"}
            //                        //        }
            //                        //   },
            //                        //   new Detail{
            //                        //        Type=ContentType.Paragraph,
            //                        //        Contents= new List<HTMLContent>{
            //                        //            new HTMLContent{ Value= "Command not found:" },
            //                        //        }
            //                        //   },
            //                        //   new Detail{
            //                        //        Type=ContentType.Picture,
            //                        //        Contents= new List<HTMLContent>{
            //                        //            new PictureSourceContent{ Srcset="./img/zsh-command-not-found.png" },
            //                        //            new ImageContent{ Src="./img/zsh-command-not-found.png", Alt="command not found demo"}
            //                        //        }
            //                        //   },
            //                        //}
            //                    },
            //                    new Section
            //                    {
            //                        Id = "virtual",
            //                        Header = "Virtualization Software",
            //                        HasMainContent = true,
            //                        //Details = new List<Detail>{
            //                        //   new Detail{
            //                        //       Type=ContentType.Paragraph,
            //                        //       Contents= new List<HTMLContent>{ new HTMLContent { Value= "The Virtualization category includes scripts for installing toolsets & software such as Docker / Podman which make it easier to consume / ship software by professionals." } }
            //                        //   },
            //                        //}
            //                    },
            //                    new Section
            //                    {
            //                        Id = "docker",
            //                        Header = "1) Docker Desktop with WSL2 Backend",
            //                        //Details = new List<Detail>{
            //                           //new Detail{
            //                           //     Type=ContentType.Paragraph,
            //                           //     Contents= new List<HTMLContent>{
            //                           //         new HTMLContent{ Value= "This installs " },
            //                           //         new LinkContent{ Value="Docker Desktop", Href="https://www.docker.com/products/docker-desktop"},
            //                           //         new HTMLContent{ Value= " with the WSL2 backend through the chocolatey package manager. Historically very difficult to achieve but today its not even a few lines of code, what a time to be alive!" },
            //                           //     }
            //                           //},
            //                     //}
            //                    },
            //                    new Section
            //                    {
            //                        Id = "podman",
            //                        Header = "2) Podman",
            //                     //   Details = new List<Detail>{
            //                     //      new Detail{
            //                     //           Type=ContentType.Paragraph,
            //                     //           Contents= new List<HTMLContent>{
            //                     //               new HTMLContent{ Value= "Much like Docker, " },
            //                     //               new LinkContent{ Value="Podman", Href="https://podman.io/"},
            //                     //               new HTMLContent{ Value= " is a software for managing OCI Containers, this installation is provided as an alternative for the ones who prefer it instead of Docker." },
            //                     //           }
            //                     //      },
            //                     //}
            //                    },
            //                   new Section
            //                   {
            //                       Id = "sdk",
            //                       Header = "SDK & Internal Tooling",
            //                       HasMainContent = true,
            //                       //Details = new List<Detail>{
            //                       //    new Detail{
            //                       //        Type=ContentType.Paragraph,
            //                       //        Contents= new List<HTMLContent>{ new HTMLContent { Value= "The scripts under this section are all about giving developers more power by making internal Sinda tools available. The tools function as encapsulation on certain tasks into one liners." } }
            //                       //    },
            //                       // }
            //                   },
            //                    new Section
            //                    {
            //                        Id = "sindamodule",
            //                        Header = "1) Sinda Developer Tools",
            //                     //   Details = new List<Detail>{
            //                     //      new Detail{
            //                     //           Type=ContentType.Paragraph,
            //                     //           Contents= new List<HTMLContent>{
            //                     //               new HTMLContent{ Value= "This is a Powershell module & an exact copy of the internal scripts used with the CLI tool wrapped in an easily importable format." },
            //                     //               new HTMLContent{ Value= "the command imports the module located at src/script/Sindagal.psm1 into the powershell profile of the user using the machine" },
            //                     //               new HTMLContent{ Value= "Once the module is imported, the developer gains direct access to all the features included in the CLI & more through direct powershell commands!" },
            //                     //           }
            //                     //      },
            //                     //      new Detail{
            //                     //           Type=ContentType.Paragraph,
            //                     //           Contents= new List<HTMLContent>{
            //                     //               new HTMLContent{ Value= "All the commands could be inspected in the file location mentioned within the CLI repository, however some of them are explained below." },
            //                     //           }
            //                     //      },
            //                     //   new Detail{
            //                     //       Type=ContentType.Paragraph,
            //                     //       Contents= new List<HTMLContent>{
            //                     //           new HTMLContent{ Value= "To check the current state of your system for things such as os version, architecture, wsl2 support etc: "}
            //                     //       }
            //                     //   },
            //                     //   new Detail{
            //                     //       Type=ContentType.Code,
            //                     //       Contents= new List<HTMLContent>{
            //                     //           new CodeContent{ Language="shell", Value= "Get-EnvState" },
            //                     //       }
            //                     //   },
            //                     //   new Detail{
            //                     //       Type=ContentType.Paragraph,
            //                     //       Contents= new List<HTMLContent>{
            //                     //           new HTMLContent{ Value= "To install WSL on legacy systems where WSL2 or wsl --install command are not supported "}
            //                     //       }
            //                     //   },
            //                     //   new Detail{
            //                     //       Type=ContentType.Code,
            //                     //       Contents= new List<HTMLContent>{
            //                     //           new CodeContent{ Language="shell", Value= "Enable-WSLLegacy" },
            //                     //       }
            //                     //   },
            //                     //   new Detail{
            //                     //       Type=ContentType.Paragraph,
            //                     //       Contents= new List<HTMLContent>{
            //                     //           new HTMLContent{ Value= "To download & import the Sinda pre configured wsl2 instance:"}
            //                     //       }
            //                     //   },
            //                     //   new Detail{
            //                     //       Type=ContentType.Code,
            //                     //       Contents= new List<HTMLContent>{
            //                     //           new CodeContent{ Language="shell", Value= "Add-SindaDistro" },
            //                     //       }
            //                     //   },
            //                     //   new Detail{
            //                     //       Type=ContentType.Paragraph,
            //                     //       Contents= new List<HTMLContent>{
            //                     //           new HTMLContent{ Value= "Check if terminal session has admin rights:"}
            //                     //       }
            //                     //   },
            //                     //   new Detail{
            //                     //       Type=ContentType.Code,
            //                     //       Contents= new List<HTMLContent>{
            //                     //           new CodeContent{ Language="shell", Value= "Test-Elevation" },
            //                     //       }
            //                     //   },
            //                     //   new Detail{
            //                     //       Type=ContentType.Paragraph,
            //                     //       Contents= new List<HTMLContent>{
            //                     //           new HTMLContent{ Value= "Install & Configure Windows Terminal with Nerd Fonts:"}
            //                     //       }
            //                     //   },
            //                     //   new Detail{
            //                     //       Type=ContentType.Code,
            //                     //       Contents= new List<HTMLContent>{
            //                     //           new CodeContent{ Language="shell", Value= "Enable-WindowsTerminal" },
            //                     //       }
            //                     //   },
            //                     //   new Detail{
            //                     //       Type=ContentType.Paragraph,
            //                     //       Contents= new List<HTMLContent>{
            //                     //           new HTMLContent{ Value= "Disable & delete Windows Terminal:"}
            //                     //       }
            //                     //   },
            //                     //   new Detail{
            //                     //       Type=ContentType.Code,
            //                     //       Contents= new List<HTMLContent>{
            //                     //           new CodeContent{ Language="shell", Value= "Disable-WindowsTerminal" },
            //                     //       }
            //                     //   },
            //                     //   new Detail{
            //                     //           Type=ContentType.Paragraph,
            //                     //           Contents= new List<HTMLContent>{
            //                     //               new HTMLContent{ Value= "And many more!" },
            //                     //           }
            //                     //      },
            //                     //}
            //                    },
            //                   new Section
            //                   {
            //                       Id = "boilerplate",
            //                       Header = "Boilerplates & Codebases",
            //                       HasMainContent = true,
            //                       //Details = new List<Detail>{
            //                       //    new Detail{
            //                       //        Type=ContentType.Paragraph,
            //                       //        Contents= new List<HTMLContent>{ new HTMLContent { Value= "The Boilerplate section contains scripts which clone Ready to go Sinda Codebases from github. The repositories are intended to solve common problems & be as easily personalized as possible." } }
            //                       //    }
            //                       // }
            //                   },
            //                    new Section
            //                    {
            //                        Id = "portfolio",
            //                        Header = "1) Sinda Portfolio",
            //                     //   Details = new List<Detail>{
            //                     //      new Detail{
            //                     //           Type=ContentType.Paragraph,
            //                     //           Contents= new List<HTMLContent>{
            //                     //               new HTMLContent{ Value= "This clones a reusable & extensible web portfolio template written with React using the NextJS framework. The repository could be found " },
            //                     //               new LinkContent{ Value="here.", Href="https://github.com/denzii/sinda-portfolio"},
            //                     //               new HTMLContent{ Value= "This simplistic portfolio itself has basic SEO optimizations, keyboard and developer accessibility; a performant " },
            //                     //               new LinkContent{ Value="Chrome Lighthouse", Href="https://developers.google.com/web/tools/lighthouse"},
            //                     //               new HTMLContent{ Value= " score as well as good responsive UI/UX principles!" },
            //                     //               new HTMLContent{ Value= " Feel free to change the data & reupload it to your favourite version-control website as you please!" },
            //                     //           }
            //                     //      },
            //                     //      new Detail{
            //                     //           Type=ContentType.Paragraph,
            //                     //           Contents= new List<HTMLContent>{
            //                     //               new HTMLContent{ Value= "For more information regarding this template & web theme, please refer to the Boilerplate tab on this page." },
            //                     //           }
            //                     //      },
            //                     //}
            //                    },
            //                     new Section
            //                     {
            //                         Id = "Introduction",
            //                         Header = "Introduction",
            //                         HasMainContent = true,
            //                        // Details = new List<Detail>{
            //                        //   new Detail{
            //                        //        Type=ContentType.Paragraph,
            //                        //        Contents= new List<HTMLContent>{
            //                        //            new HTMLContent{ Value= "Do you have some boilerplate code which you always have to write from scratch? Are you in a hurry to get up and running with an MVP?" },
            //                        //            new HTMLContent{ Value= " Sindagal Boilerplates will come to your rescue!" },
            //                        //            new HTMLContent{ Value= " On this page, we will be exploring how to set up and work with existing code as well as how to extend them to our needs to save time from cumbersome work!" } }
            //                        //   },
            //                        //}
            //                     },
            //                    new Section
            //                    {
            //                        Id = "portfolio",
            //                        Header = "1) Sinda Portfolio",
            //                        //Details = new List<Detail>{
            //                        //   new Detail{
            //                        //       Type=ContentType.Paragraph,
            //                        //       Contents= new List<HTMLContent>{
            //                        //           new HTMLContent{ Value= "Planning to look for that next challange in your career but do not have time to fiddle with UI/UX or write the code for a portfolio website from scratch?" },
            //                        //           new HTMLContent{ Value= " You can now rest easy with this " },
            //                        //           new LinkContent{ Value="web portfolio.", Href="https://github.com/denzii/sinda-portfolio"},
            //                        //           new HTMLContent{ Value= " This template simplistic enough to do the job and will hit the spot with its SEO optimizations, keyboard and developer accessibility; a performant " },
            //                        //           new LinkContent{ Value="Lighthouse", Href="https://developers.google.com/web/tools/lighthouse"},
            //                        //           new HTMLContent{ Value= " score as well as good responsive UI/UX principles!" },
            //                        //           new HTMLContent{ Value= " please find a live example at" },
            //                        //           new LinkContent{ Value="denizarca.com", Href="https://denizarca.com"} },
            //                        //   }
            //                        //}
            //                    },
            //                    new Section
            //                    {
            //                        Id = "portfolioSetup",
            //                        Header = "Setting up the repository",
            //                        //Details = new List<Detail>{
            //                           //new Detail{
            //                           //    Type=ContentType.Paragraph,
            //                           //    Contents= new List<HTMLContent>{
            //                           //        new HTMLContent{ Value= "This is a NextJS TypeScript project so NodeJS & npm are required as a prerequisite." },
            //                           //        new HTMLContent{ Value= "If those already exist on the machine or if you are using the pre configured WSL instance, its okay to proceed to cloning the repository." },
            //                           //        },

            //                           //},
            //                           //new Detail{
            //                           //     Type=ContentType.Code,
            //                           //     Contents= new List<HTMLContent>{
            //                           //         new CodeContent{ Language="shell", Value= "git clone https://github.com/denzii/sinda-portfolio.git" },
            //                           //     }
            //                           // },
            //                           // new Detail{
            //                           //     Type=ContentType.Paragraph,
            //                           //     Contents= new List<HTMLContent>{
            //                           //        new HTMLContent{ Value= "Install Nextjs globally:" },
            //                           //     },
            //                           // },
            //                           // new Detail{
            //                           //     Type=ContentType.Code,
            //                           //     Contents= new List<HTMLContent>{
            //                           //        new CodeContent{ Language="shell", Value= "npm i -g next" },
            //                           //     }
            //                           // },
            //                           // new Detail{
            //                           //        Type=ContentType.Paragraph,
            //                           //        Contents= new List<HTMLContent>{
            //                           //            new HTMLContent{ Value= "Move into the repository, install dependencies and run the app:" },
            //                           //        },

            //                           //    },
            //                           // new Detail{
            //                           //     Type=ContentType.Code,
            //                           //     Contents= new List<HTMLContent>{
            //                           //         new CodeContent{ Language="shell", Value= "cd sinda-portfolio" },
            //                           //     }
            //                           // },
            //                           // new Detail{
            //                           //     Type=ContentType.Code,
            //                           //     Contents= new List<HTMLContent>{
            //                           //         new CodeContent{ Language="shell", Value= "npm install" },
            //                           //     }
            //                           // },
            //                           // new Detail{
            //                           //     Type=ContentType.Code,
            //                           //     Contents= new List<HTMLContent>{
            //                           //         new CodeContent{ Language="shell", Value= "npm run dev" },
            //                           //     }
            //                           // },

            //                           // new Detail{
            //                           //     Type=ContentType.Paragraph,
            //                           //     Contents= new List<HTMLContent>{
            //                           //         new HTMLContent{ Value= "If everything went well, it's now okay to visit localhost:3000 in your favourite browser to see the site!" },
            //                           //     },
            //                           // },
            //                           // new Detail{
            //                           //     Type=ContentType.Picture,
            //                           //     Contents= new List<HTMLContent>{
            //                           //         new PictureSourceContent{ Srcset="./img/portfolio-landing-page-850w.png", Media="(max-width: 950px)"},
            //                           //         new PictureSourceContent{ Srcset="./img/portfolio-landing-page.png"},
            //                           //         new ImageContent{ Src="./img/portfolio-landing-page.png", Alt="Portfolio Landing Page"}
            //                           //     }
            //                           // },


            //                        //}

            //                    },
            //                    new Section
            //                    {
            //                        Id = "portfolioHero",
            //                        Header = "Changing the hero section content",
            //                        //Details = new List<Detail>{
            //                            //new Detail{
            //                            //    Type=ContentType.Paragraph,
            //                            //    Contents= new List<HTMLContent>{
            //                            //        new HTMLContent{ Value= "Not bad! In order to personalize it, we need to make a few tweaks." },
            //                            //        new HTMLContent{ Value= " The data is pulled into a single class at " },
            //                            //        new LinkContent{ Value="data/index.ts", Href="https://github.com/denzii/sinda-portfolio/blob/main/data/index.ts"},
            //                            //        new HTMLContent{ Value= " class for the most part and this is where we will spend most of our time." },
            //                            //        new HTMLContent{ Value= " having said that, the page title and the meta tags for SEO as well as canonical must also be changed for a fully personalized portfolio. In a NextJS project, these are stored in " },
            //                            //        new LinkContent{ Value="pages/_document.tsx", Href="https://github.com/denzii/sinda-portfolio/blob/main/pages/_document.tsx"},
            //                            //        new HTMLContent{ Value= " as per convention. It is planned to pull these into the data folder in the future as well!" },
            //                            //    },
            //                            //},
            //                            //new Detail{
            //                            //    Type=ContentType.Paragraph,
            //                            //    Contents= new List<HTMLContent>{
            //                            //        new HTMLContent{ Value= "Let's view the code in our favourite code editor and see how to go about the modifications!" },
            //                            //    },
            //                            //},
            //                            //new Detail{
            //                            //    Type=ContentType.Code,
            //                            //    Contents= new List<HTMLContent>{
            //                            //        new CodeContent{ Language="shell", Value= "code ." },
            //                            //    }
            //                            //},
            //                            //new Detail{
            //                            //    Type=ContentType.Paragraph,
            //                            //    Contents= new List<HTMLContent>{
            //                            //        new HTMLContent{ Value= "To start things off, lets change the navigation bar contents by changing the ProjectOwner, PersonalURLs & PersonalBackground Objects as shown." },
            //                            //    },
            //                            //},
            //                            //new Detail{
            //                            //    Type=ContentType.Picture,
            //                            //    Contents= new List<HTMLContent>{
            //                            //        new PictureSourceContent{ Srcset="./img/portfolio-navbar-name-diff-850w.png", Media="(max-width: 950px)"},
            //                            //        new PictureSourceContent{ Srcset="./img/portfolio-navbar-name-diff.png",},
            //                            //        new ImageContent{ Src="./img/portfolio-navbar-name-diff.png", Alt="Portfolio Navbar modification"}
            //                            //    }
            //                            //},
            //                            //new Detail{
            //                            //    Type=ContentType.Paragraph,
            //                            //    Contents= new List<HTMLContent>{
            //                            //        new HTMLContent{ Value= " Icons for social media could be changed by supplying a name from the " },
            //                            //        new LinkContent{ Value="React Font Awesome", Href="https://react-icons.github.io/react-icons/icons?name=fa"},
            //                            //        new HTMLContent{ Value= " Icons. Additional navigation links such as \"instagram\" could also be added or removed if desired by altering the keys on the" },
            //                            //        new LinkContent{ Value="interface/personalUrls.ts", Href="https://github.com/denzii/sinda-portfolio/blob/main/interface/personalUrls.ts"},
            //                            //        new HTMLContent{ Value= " class further. For demonstration purposes, lets remove the email icon while changing the other two icons." },
            //                            //    },
            //                            //},
            //                            //new Detail{
            //                            //    Type=ContentType.Picture,
            //                            //    Contents= new List<HTMLContent>{
            //                            //        new PictureSourceContent{ Srcset="./img/portfolio-socialbar-diff-850w.png", Media="(max-width: 950px)"},
            //                            //        new PictureSourceContent{ Srcset="./img/portfolio-socialbar-diff.png",},
            //                            //        new ImageContent{ Src="./img/portfolio-socialbar-diff.png", Alt="Portfolio Socialbar modification"}
            //                            //    }
            //                            //},
            //                            //new Detail{
            //                            //    Type=ContentType.Paragraph,
            //                            //    Contents= new List<HTMLContent>{
            //                            //        new HTMLContent{ Value= " The keys on the object " },
            //                            //        new LinkContent{ Value="interface/background.ts", Href="https://github.com/denzii/sinda-portfolio/blob/main/interface/background.ts"},
            //                            //        new HTMLContent{ Value= " are used to generate the sections below the hero section. If we wanted to add or remove or alter a section, all we would need to do is to alter the keys on it!" },
            //                            //        new HTMLContent{ Value= " for the sake of this tutorial, let's remove the hobbies section and rename some of the others!" },
            //                            //    },
            //                            //},
            //                            //new Detail{
            //                            //    Type=ContentType.Picture,
            //                            //    Contents= new List<HTMLContent>{
            //                            //        new PictureSourceContent{ Srcset="./img/portfolio-navbar-elems-diff-850w.png", Media="(max-width: 950px)"},
            //                            //        new PictureSourceContent{ Srcset="./img/portfolio-navbar-elems-diff.png",},
            //                            //        new ImageContent{ Src="./img/portfolio-navbar-elems-diff.png", Alt="Portfolio Navbar elements modification" }
            //                            //    }
            //                            //},
            //                            //new Detail{
            //                            //    Type=ContentType.Paragraph,
            //                            //    Contents= new List<HTMLContent>{
            //                            //        new HTMLContent{ Value= " Now that those are out of the way, its a good time to change the background and the headshot images which are located inside the " },
            //                            //        new LinkContent{ Value="public", Href="https://github.com/denzii/sinda-portfolio/tree/main/public"},
            //                            //        new HTMLContent{ Value= " directory, all that is required is to drop in the images in that directory and reference them inside the data class. The app is written flexible enough to allow the usage of different image names as-well!" },
            //                            //    },
            //                            //},
            //                            //new Detail{
            //                            //    Type=ContentType.Picture,
            //                            //    Contents= new List<HTMLContent>{
            //                            //        new PictureSourceContent{ Srcset="./img/portfolio-hero-diff.png",},
            //                            //        new ImageContent{ Src="./img/portfolio-hero-diff.png", Alt="Portfolio hero images modification" }
            //                            //    }
            //                            //},

            //                        //}
            //                    },
            //                    new Section
            //                    {
            //                        Id = "portfolioBody",
            //                        Header = "Changing the body section contents",
            //                        //Details = new List<Detail>{
            //                           // new Detail{
            //                           //     Type=ContentType.Paragraph,
            //                           //     Contents= new List<HTMLContent>{
            //                           //         new HTMLContent{ Value= "We've come a long way and the results are just beautiful! Refresh the browser page to see that the website now looks like this: " },
            //                           //     },
            //                           // },
            //                           // new Detail{
            //                           //     Type=ContentType.Picture,
            //                           //     Contents= new List<HTMLContent>{
            //                           //         new PictureSourceContent{ Srcset="./img/portfolio-altered-hero-diff-850w.png", Media="(max-width: 950px)"},
            //                           //         new PictureSourceContent{ Srcset="./img/portfolio-altered-hero-diff.png",},
            //                           //         new ImageContent{ Src="./img/portfolio-altered-hero-diff.png", Alt="Portfolio altered hero section" }
            //                           //     }
            //                           // },
            //                           // new Detail{
            //                           //     Type=ContentType.Paragraph,
            //                           //     Contents= new List<HTMLContent>{
            //                           //         new HTMLContent{ Value= "How about the body sections? Are they even flexible enough for personalization? They sure are! All that needs to be done is to alter the methods which are being called within the \"PersonalBackground\" method inside the data class." },
            //                           //         new HTMLContent{ Value= " The heading, date range & inner content are supplied within the same place, the inner content could be made bold, italic or emphasized on demand without touching any HTML." },

            //                           //     },
            //                           // },
            //                           // new Detail{
            //                           //     Type=ContentType.Paragraph,
            //                           //     Contents= new List<HTMLContent>{
            //                           //         new HTMLContent{ Value= " If it's a semantic markup for your website which you are looking for; you can add emphasis and other things to certain text but also keep it unstyled." },
            //                           //         new HTMLContent{ Value= " This is a good idea if you would like your website to read well by screen readers so elements could be emphesized without changing the visual feeling..." },
            //                           //         new HTMLContent{ Value= " The body elements could be given captions aswell by assigning the \"caption\" field a string value." },
            //                           //     },
            //                           // },
            //                           //new Detail{
            //                           //     Type=ContentType.Paragraph,
            //                           //     Contents= new List<HTMLContent>{
            //                           //         new HTMLContent{ Value= "Example body section element code:" },
            //                           //     },
            //                           // },
            //                           //new Detail{
            //                           //     Type=ContentType.Picture,
            //                           //     Contents= new List<HTMLContent>{
            //                           //         new PictureSourceContent{ Srcset="./img/portfolio-body-code.png", Media="(max-width: 950px)"},
            //                           //         new ImageContent{ Src="./img/portfolio-body-code.png", Alt="Portfolio body code example" }
            //                           //     }
            //                           // },
            //                           // new Detail{
            //                           //     Type=ContentType.Paragraph,
            //                           //     Contents= new List<HTMLContent>{
            //                           //         new HTMLContent{ Value= "Only one thing remains, changing the meta content of the site! And this is as easy as going into the pages/_document.tsx" },
            //                           //         new LinkContent{ Value="pages/_document.tsx", Href="https://github.com/denzii/sinda-portfolio/tree/main/public"},
            //                           //         new HTMLContent{ Value= " file and altering the given strings." },
            //                           //         new HTMLContent{ Value= " add in the full address of your domain as a canonical, change the tab title as you wish and amend the keywords to cater to your target audiences google searches." },
            //                           //     },
            //                           // },
            //                           // new Detail{
            //                           //     Type=ContentType.Paragraph,
            //                           //     Contents= new List<HTMLContent>{
            //                           //         new HTMLContent{ Value= "That is all! Enjoy your Sinda Portfolio and do not forget to give a star or send your pull requests!" },
            //                           //         new HTMLContent{ Value= " We will not be touching on how to deploy this website since it is using the stock CI/CD which is provided by Vercel for free on personal projects." },
            //                           //         new HTMLContent{ Value= " To find out more about deployments, visit their tutorials at " },
            //                           //         new LinkContent{ Value="nextjs.org/deployment", Href="https://nextjs.org/docs/deployment"},
            //                           //     },
            //                           // },
            //                        //}
            //                    }
            //        );

            //        modelBuilder.Entity<PageTab>().HasData(
            //    new PageTab { Name = "Philosophy", Status = SectionStatus.Hidden },
            //    new PageTab { Name = "Vision", Status = SectionStatus.Hidden },
            //    new PageTab { Name = "Articles", Status = SectionStatus.Hidden },
            //    new PageTab { Name = "News", Status = SectionStatus.Hidden },
            //    new PageTab  {
            //        Name = "Terminal",
            //        Status = SectionStatus.Public,
            //        //Sections = new List<Section> {
            //    //                        new Section {
            //    //                            Id="introduction",
            //    //                            Header="Introduction",
            //    //                            HasMainContent=true,
            //    //                            Details= new List<Detail>{
            //    //                               new Detail{
            //    //                                    Contents= new List<HTMLContent>{
            //    //                                        new HTMLContent{ Value= "Sindagal " },
            //    //                                        new LinkContent{ Value= "Command Line Interface", Href="https://github.com/denzii/sinda-cli" },
            //    //                                        new HTMLContent{ Value= " is a simple Node.js application which makes use of the popular JavaScript framework React. The goal is to make developer lives more convenient by wrapping around operating system level scripts and allowing their easy consumption." }
            //    //                                    }
            //    //                               },
            //    //                               new Detail{
            //    //                                   Contents= new List<HTMLContent>{ new WarningContent{ Value= "For the time being, usages from within WSL & Unix based systems had been disabled." } }
            //    //                               },
            //    //                               new Detail{
            //    //                                   Contents= new List<HTMLContent>{ new HTMLContent { Value= "On this page, you'll learn what the Sinda Command Line Interface brings to the table and how it can be consumed by setting it up from scratch and consuming some of the built in automation scripts on a Windows machine." } }
            //    //                               }
            //    //                            }
            //    //                        },
            //    //                        new Section{
            //    //                          Id="setup",
            //    //                          Header="Getting Started",
            //    //                          HasMainContent=false,
            //    //                          Details= new List<Detail>{
            //    //                            new Detail{
            //    //                                Type=ContentType.Paragraph,
            //    //                                Contents= new List<HTMLContent>{
            //    //                                    new HTMLContent{ Value= "The project requires Node.js LTS and npm to be installed as a pre-requisite so if you do not already have them, now is a good time to set them up." },
            //    //                                    new LinkContent{ Value="This tutorial", Href="https://docs.microsoft.com/en-us/windows/dev-environment/javascript/nodejs-on-windows"},
            //    //                                    new HTMLContent{ Value= "by Microsoft demonstrates how they could be set on a Windows machine using the Node Version Manager tool (NVM)."}
            //    //                                }
            //    //                            },
            //    //                            new Detail{
            //    //                                Type=ContentType.Paragraph,
            //    //                                Contents= new List<HTMLContent>{
            //    //                                    new HTMLContent{ Value="Once NVM & Node.js are configured, we could proceed to cloning the repository and running the app from the cloned source code. Its necessary to fork and/or clone the repository since the app itself requires access to the localhost machine so it can run powershell/bash scripts."}
            //    //                                }
            //    //                            },
            //    //                            new Detail{
            //    //                                Type=ContentType.Code,
            //    //                                Contents= new List<HTMLContent>{
            //    //                                    new CodeContent{Language="shell", Value="git clone https://github.com/denzii/sinda-cli.git"}
            //    //                                }
            //    //                            },
            //    //                            new Detail{
            //    //                                Type=ContentType.Code,
            //    //                                Contents= new List<HTMLContent>{
            //    //                                    new CodeContent{Language="shell", Value="cd sinda-cli"}
            //    //                                }
            //    //                            },
            //    //                            new Detail{
            //    //                                Type=ContentType.Code,
            //    //                                Contents= new List<HTMLContent>{
            //    //                                    new CodeContent{Language="shell", Value="npm start"}
            //    //                                }
            //    //                            },
            //    //                            new Detail{
            //    //                                Type=ContentType.Warning,
            //    //                                Contents= new List<HTMLContent>{ new HTMLContent{ Value= "The app requires administrator rights to run Powershell / Bash scripts on localhost, if its run from a non-elevated terminal session, it will result in an error and not run." } }
            //    //                            },
            //    //                            new Detail{
            //    //                                Type=ContentType.Paragraph,
            //    //                                Contents= new List<HTMLContent>{
            //    //                                    new HTMLContent{Value="The following image demonstrates the landing page for a successfully started CLI."}
            //    //                                }
            //    //                            },
            //    //                            new Detail{
            //    //                                Type=ContentType.Picture,
            //    //                                Contents= new List<HTMLContent>{
            //    //                                    new PictureSourceContent{ Srcset="./img/cli-landing-page-850w.png", Media="(max-width: 950px)"},
            //    //                                    new PictureSourceContent{ Srcset="./img/cli-landing-page.png"},
            //    //                                    new ImageContent{ Src="./img/cli-landing-page.png", Alt="CLI Landing Page"}
            //    //                                }
            //    //                            },

            //    //                 }
            //    //               },
            //    //               new Section {
            //    //                    Id="usage",
            //    //                    Header="Usage",
            //    //                    HasMainContent=false,
            //    //                    Details= new List<Detail>{
            //    //                       new Detail{
            //    //                            Type=ContentType.Paragraph,
            //    //                            Contents= new List<HTMLContent>{
            //    //                                new HTMLContent{ Value= "Consuming scripts from the app is pretty straight forward and takes only a few key-presses to achieve. As seen on the landing page image, the terminal prompt functions similarly to a single page app and the visible part of the terminal is hijacked by a" },
            //    //                                new LinkContent{ Value="React Ink", Href="https://github.com/vadimdemedes/ink"},
            //    //                                new HTMLContent{ Value= "Component" },
            //    //                            }

            //    //                       },
            //    //                       new Detail{
            //    //                           Type=ContentType.Paragraph,
            //    //                           Contents= new List<HTMLContent>{ new HTMLContent{ Value= "The component itself detects the screen height and width and resizes accordingly. Having said that, a maximized terminal window is recommended for the best experience and the resizing  feature is only meant for the application startup. If the terminal window gets resized while the app is running, there are no guarantees for correct rendering of the component." } }
            //    //                       },
            //    //                       new Detail{
            //    //                           Type=ContentType.Paragraph,
            //    //                           Contents= new List<HTMLContent>{ new HTMLContent{ Value= "Once a key is pressed on the landing page, the survey component is rendered and the user is presented with all the available automation scripts... Navigation of the form is achieved through the <i>Up / Down / Enter & Esc </i> keys. This component is demonstrated in the following image." } }
            //    //                       },
            //    //                       new Detail{
            //    //                        Type=ContentType.Picture,
            //    //                        Contents= new List<HTMLContent>{
            //    //                            new PictureSourceContent{ Srcset="./img/cli-survey-page-850w.png", Media="(max-width: 950px)"},
            //    //                            new PictureSourceContent{ Srcset="./img/cli-survey-page.png"},
            //    //                            new ImageContent{ Src="./img/cli-survey-page.png", Alt="CLI Survey Page"}
            //    //                        }
            //    //                      },
            //    //                      new Detail{
            //    //                           Type=ContentType.Paragraph,
            //    //                           Contents= new List<HTMLContent>{ new HTMLContent{  Value= "For the sake of this tutorial, we are only going to be selecting the first three options. Once the selections are made, it is required to navigate to the last page of the survey and confirm the selections.  The \"proceed\" button will ask for a re-confirmation and esc key could be used to go back to the form."},  }
            //    //                      },
            //    //                      new Detail{
            //    //                        Type=ContentType.Picture,
            //    //                        Contents= new List<HTMLContent>{
            //    //                            new PictureSourceContent{ Srcset="./img/cli-survey-page-confirmation-850w.png", Media="(max-width: 950px)"},
            //    //                            new PictureSourceContent{ Srcset="./img/cli-survey-page-confirmation.png"},
            //    //                            new ImageContent{ Src="./img/cli-survey-page-confirmation.png", Alt="CLI Survey Page Confirmation"}
            //    //                        }
            //    //                      },
            //    //                      new Detail{
            //    //                           Type=ContentType.Paragraph,
            //    //                           Contents= new List<HTMLContent>{ new HTMLContent{ Value= "Prior to making any changes to the machine, all the selected features and their corresponding scripts are listed and a confirmation is requested once more for extra safety."} }
            //    //                      },
            //    //                      new Detail{
            //    //                        Type=ContentType.Picture,
            //    //                        Contents= new List<HTMLContent>{
            //    //                            new PictureSourceContent{ Srcset="./img/cli-survey-page-confirmation-2-850w.png", Media="(max-width: 950px)"},
            //    //                            new PictureSourceContent{ Srcset="./img/cli-survey-page-confirmation-2.png"},
            //    //                            new ImageContent{ Src="./img/cli-survey-page-confirmation-2.png", Alt="CLI Survey Page Finalization"}
            //    //                        }
            //    //                      },
            //    //                      new Detail{
            //    //                        Type=ContentType.Warning,
            //    //                        Contents= new List<HTMLContent>{ new HTMLContent{ Value= "For the time being, the scripts are executed syncronously and the results within the box are updated all at once." } }
            //    //                      },
            //    //                      new Detail{
            //    //                           Type=ContentType.Paragraph,
            //    //                           Contents= new List<HTMLContent>{ new HTMLContent{ Value= "The Standard Outputs as well as Errors for the executed commands are pushed above the component box in real-time. A finished session is demonstrated in the below image."} }
            //    //                      },
            //    //                      new Detail{
            //    //                        Type=ContentType.Picture,
            //    //                        Contents= new List<HTMLContent>{
            //    //                            new PictureSourceContent{ Srcset="./img/cli-survey-page-results-850w.png", Media="(max-width: 950px)"},
            //    //                            new PictureSourceContent{ Srcset="./img/cli-survey-page-results.png"},
            //    //                            new ImageContent{ Src="./img/cli-survey-page-results.png", Alt="CLI Survey Page Results"}
            //    //                        }
            //    //                      },
            //    //                      new Detail{
            //    //                           Type=ContentType.Paragraph,
            //    //                           Contents= new List<HTMLContent>{ new HTMLContent{ Value= "Thats all folks! See how easy it was to consume some powershell scripts? To see the full list of the existing scripts, please navigate to the scripts tab on this page."} }
            //    //                      },
            //    //                 }
            //    //               }
            //    //            }
            //},
            //            new PageTab
            //            {
            //                Name = "Scripts",
            //                Status = SectionStatus.Public,
            //                //Sections = new List<Section> {
            //                   // new Section {
            //                   //     Id="Introduction",
            //                   //     Header="Introduction",
            //                   //     HasMainContent= true,
            //                   //     Details= new List<Detail>{
            //                   //        new Detail{
            //                   //             Type=ContentType.Paragraph,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new HTMLContent{ Value= "As described in the Terminal tab, Sindagal comes with some built-in scripts and can also be extended to interface to personal scripts. The scripts are categorized as Terminal, Shell, Virtual, SDK & Boilerplate." },
            //                   //                 new HTMLContent{ Value= " The CLI tool works by executing powershell / bash scripts which exist inside the code repository itself under the src/scripts directory." } }
            //                   //        },
            //                   //        new Detail {
            //                   //             Type=ContentType.Paragraph,
            //                   //             Contents=new List<HTMLContent>{
            //                   //                 new HTMLContent{ Value=" On this page, we will be exploring the various details regarding those features and why they might come in handy for you or your organisation."}
            //                   //             }
            //                   //        },
            //                   //        new Detail{
            //                   //            Type=ContentType.Warning,
            //                   //            Contents= new List<HTMLContent>{
            //                   //                new HTMLContent{ Value= "For the time being, everything is in the Minimum Viable Product stage & things might change in the future. Please report any problems or bugs to me personally through my " },
            //                   //                new LinkContent{ Value= "Linkedin.", Href="https://www.linkedin.com/in/denizarca/" },
            //                   //                new HTMLContent{ Value= " Pull requests are welcome at the " },
            //                   //                new LinkContent{ Value= "CLI repository.", Href="https://github.com/denzii/sinda-cli" },
            //                   //            }
            //                   //        },
            //                   //     }
            //                   // },
            //                   // new Section {
            //                   //     Id="terminal",
            //                   //     HasMainContent= true,
            //                   //     Header="Terminal Extensions",
            //                   //     Details= new List<Detail>{
            //                   //        new Detail{
            //                   //            Type=ContentType.Paragraph,
            //                   //            Contents= new List<HTMLContent>{ new HTMLContent{ Value= "This category is where the scripts regarding the interactive terminal session reside. These will alter the look & feel of your interactions with your local shell." } }
            //                   //        }
            //                   //     }
            //                   // },
            //                   // new Section {
            //                   //     Id="ohmyposh",
            //                   //     Header="1) Oh My Posh & Nerd Fonts",
            //                   //     Details= new List<Detail>{
            //                   //        new Detail{
            //                   //             Type=ContentType.Paragraph,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                new HTMLContent{ Value= "By default, terminal prompts on Windows machines come with no support for user themes, lack descriptiveness and are not intuitive to use. Wouldn't it be nice if the sessions could be personalized & extended with additional information such as the time of command execution, git active branch names, battery level and more?" },
            //                   //                new HTMLContent{ Value= " Enter " },
            //                   //                new LinkContent{ Value= "Oh My Posh!", Href="https://ohmyposh.dev/" },
            //                   //                new HTMLContent{ Value= " A shell framework for doing all of that! Historically this worked only on Windows but with Powershell going cross platform, it now works on Linux & Mac as well. " },
            //                   //             }
            //                   //        },
            //                   //        new Detail{
            //                   //            Type=ContentType.Paragraph,
            //                   //            Contents= new List<HTMLContent>{
            //                   //                new HTMLContent{ Value= "The framework is easily configurable... All available themes could be reviewed by: " },
            //                   //            }
            //                   //        },
            //                   //        new Detail{
            //                   //             Type=ContentType.Code,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                new CodeContent{ Language="shell", Value= "Get-PoshThemes" },
            //                   //             }
            //                   //        },
            //                   //        new Detail{
            //                   //            Type=ContentType.Paragraph,
            //                   //            Contents= new List<HTMLContent>{
            //                   //                new HTMLContent{ Value= "changing the theme to \"Darkblood\": " },
            //                   //            }
            //                   //        },
            //                   //        new Detail{
            //                   //             Type=ContentType.Code,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                new CodeContent{ Language="shell", Value= "Set-PoshPrompt darkblood" },
            //                   //             }
            //                   //        },
            //                   //        new Detail{
            //                   //            Type=ContentType.Paragraph,
            //                   //            Contents= new List<HTMLContent>{
            //                   //                new HTMLContent{ Value= "Having said that, it is also possible to configure it via code by adjusting an init script at a location which can be found from the Get-PoshThemes command. " },
            //                   //            }
            //                   //        },
            //                   //        new Detail{
            //                   //            Type=ContentType.Paragraph,
            //                   //            Contents= new List<HTMLContent>{
            //                   //                new HTMLContent { Value= "Oh My Posh relies on a specific font family in order to display its many glyphs properly, Sinda takes care of installing the " },
            //                   //                new LinkContent { Value= "Nerd Fonts", Href="https://github.com/ryanoasis/nerd-fonts"},
            //                   //                new HTMLContent { Value= " for you!" },
            //                   //            }
            //                   //        }
            //                   //     }
            //                   // },
            //                   // new Section{
            //                   //   Id="winterm",
            //                   //   Header="2) Windows Terminal by Microsoft",
            //                   //   Details= new List<Detail>{
            //                   //     new Detail{
            //                   //         Type=ContentType.Paragraph,
            //                   //         Contents= new List<HTMLContent>{
            //                   //             new HTMLContent{ Value= "The default Powershell / Command Prompt & WSL terminal apps are some-what primitive, those emulators damage productivity. They are difficult to impossible to standardize, they require switching between windows which can get tedious & confusing from time to time and they lack certain features when it comes to keyboard shortcuts." },
            //                   //             new LinkContent{ Value= "Windows Terminal", Href="https://docs.microsoft.com/en-us/windows/terminal/" },
            //                   //             new HTMLContent{ Value= " intends to remedy the above problems by allowing multiple tabs, split screens, extensive keyboard macros and multi-shell support."},
            //                   //             new HTMLContent{ Value= " Tabs could contain any session ranging from Azure, WSL2, Remote SSH, Powershell & CMD!"},
            //                   //             new HTMLContent{ Value= " This powerful open source tool also allows launching sessions programatically through powershell commands."}
            //                   //         }
            //                   //     },
            //                   //     new Detail{
            //                   //         Type=ContentType.Paragraph,
            //                   //         Contents= new List<HTMLContent>{
            //                   //             new HTMLContent{ Value= "To start WSL Debian & Powershell sessions programatically: "}
            //                   //         }
            //                   //     },
            //                   //     new Detail{
            //                   //         Type=ContentType.Code,
            //                   //         Contents= new List<HTMLContent>{
            //                   //             new CodeContent{ Language="shell", Value= "wt -p \"Debian\" `; split-pane -p \"Windows PowerShell\" `;" },
            //                   //         }
            //                   //     },
            //                   //     new Detail{
            //                   //         Type=ContentType.Paragraph,
            //                   //         Contents= new List<HTMLContent>{
            //                   //             new HTMLContent{ Value= "Results in the following interactive sessions:"}
            //                   //         }
            //                   //     },
            //                   //     new Detail{
            //                   //         Type=ContentType.Picture,
            //                   //         Contents= new List<HTMLContent>{
            //                   //             new PictureSourceContent{ Srcset="./img/winterm-850w.png", Media="(max-width: 950px)"},
            //                   //             new PictureSourceContent{ Srcset="./img/winterm.png"},
            //                   //             new ImageContent{ Src="./img/winterm", Alt="CLI Landing Page"}
            //                   //         }
            //                   //     },
            //                   //  }
            //                   // },
            //                   // new Section {
            //                   //     Id="poshgit",
            //                   //     Header="3) Posh Git",
            //                   //     Details= new List<Detail>{
            //                   //        new Detail{
            //                   //             Type=ContentType.Paragraph,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new HTMLContent{ Value= "As always, the stock functionality with Windows is lacked and this time its with Git on Powershell & Command Prompt... " },
            //                   //             }
            //                   //        },
            //                   //        new Detail{
            //                   //             Type=ContentType.Paragraph,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new LinkContent{ Value="PoshGit", Href="https://github.com/dahlbyk/posh-git"},
            //                   //                 new HTMLContent{ Value= "a powershell module, once imported, allows auto completion for all git commands. This makes life easier as less typing is required to navigate daily tasks." },
            //                   //            }
            //                   //        },
            //                   //     }
            //                   //},
            //                   // new Section {
            //                   //     Id="shell",
            //                   //     Header="Shell Modifications",
            //                   //     HasMainContent=true,
            //                   //     Details= new List<Detail>{
            //                   //        new Detail{
            //                   //            Type=ContentType.Paragraph,
            //                   //            Contents= new List<HTMLContent>{ new HTMLContent{ Value= "The Shell category harbours everything which will alter the installed shell(s) themselves such as changing default powershell versions or installing WSL on localhost etc." } }
            //                   //        },
            //                   //     }
            //                   //},
            //                   // new Section {
            //                   //     Id="wsl",
            //                   //     Header="1) SindaDistro",
            //                   //     Details= new List<Detail>{
            //                   //        new Detail{
            //                   //             Type=ContentType.Paragraph,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new HTMLContent{ Value= "This is a pre configured WSL2 instance which had been exported and put online for easy consumption." },
            //                   //                 new HTMLContent{ Value= " The purpose of this is to encapsulate basic linux setup and provide a ready developer environment for common tasks." },
            //                   //                 new HTMLContent{ Value= " It comes with " },
            //                   //                 new LinkContent{ Value="Zsh", Href="https://www.zsh.org/"},
            //                   //                 new HTMLContent{ Value= " as well as " },
            //                   //                 new LinkContent{ Value="Oh My Zsh.", Href="https://ohmyz.sh/"},
            //                   //                 new HTMLContent{ Value= " Zsh is the default shell which OSX systems are shipped with and OhMyZsh is a framework for adding magic to it!" },
            //                   //             }
            //                   //        },
            //                   //       new Detail{
            //                   //         Type=ContentType.Warning,
            //                   //         Contents= new List<HTMLContent>{ new HTMLContent{ Value= "The features & plugins are not limited to the ones demonstrated below!" } }
            //                   //       },
            //                   //        new Detail{
            //                   //             Type=ContentType.Paragraph,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new HTMLContent{ Value= "Themes could be configured on Oh My Zsh and all the themes which exist for Oh My Posh also exist for Oh My Zsh if not more! all existing " },
            //                   //                 new LinkContent{ Value="Oh My Zsh Themes", Href="https://github.com/ohmyzsh/ohmyzsh/wiki/Themes"},
            //                   //                 new HTMLContent{ Value= "could be found in the given link! " },
            //                   //                 new HTMLContent{ Value= " The Sinda Ubuntu comes with the theme \"agnoster\" but this can easily be changed by amending the .zshrc file." },
            //                   //             }
            //                   //        },
            //                   //        new Detail{
            //                   //             Type=ContentType.Paragraph,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new HTMLContent{ Value= "First look on the .zshrc file:" },
            //                   //             }
            //                   //        },
            //                   //        new Detail{
            //                   //             Type=ContentType.Picture,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new PictureSourceContent{ Srcset="./img/zsh-rc.png" },
            //                   //                 new ImageContent{ Src="./img/zsh-rc.png", Alt="First look on .zshrc file"}
            //                   //             }
            //                   //        },
            //                   //        new Detail{
            //                   //             Type=ContentType.Paragraph,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new HTMLContent{ Value= "As shown in the image above, Oh My Zsh can be configured with many " },
            //                   //                 new LinkContent{ Value="plugins,", Href="https://github.com/ohmyzsh/ohmyzsh/wiki/Plugins"},
            //                   //                 new HTMLContent{ Value= " plugins which make life convenient! The Sinda Ubuntu comes with the git, debian, alias-finder, docker, command-not-found, thefuck & docker." },
            //                   //                 new HTMLContent{ Value= " These of course can be changed by editing the plugins array. Below are some images demonstrating the Zsh & Oh My Zsh features further!" },
            //                   //             }
            //                   //        },
            //                   //        new Detail{
            //                   //             Type=ContentType.Paragraph,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new HTMLContent{ Value= "Thefuck:" },
            //                   //             }
            //                   //        },
            //                   //        new Detail{
            //                   //             Type=ContentType.Picture,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new PictureSourceContent{ Srcset="./img/zsh-thefuck.png" },
            //                   //                 new ImageContent{ Src="./img/zsh-thefuck.png", Alt="Thefuck demo"}
            //                   //             }
            //                   //        },
            //                   //        new Detail{
            //                   //             Type=ContentType.Paragraph,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new HTMLContent{ Value= "Git branch display:" },
            //                   //             }
            //                   //        },
            //                   //        new Detail{
            //                   //             Type=ContentType.Picture,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new PictureSourceContent{ Srcset="./img/zsh-git-branch.png" },
            //                   //                 new ImageContent{ Src="./img/zsh-git-branch.png", Alt="git branch display demo"}
            //                   //             }
            //                   //        },
            //                   //        new Detail{
            //                   //             Type=ContentType.Paragraph,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new HTMLContent{ Value= "Auto complete & switch on tab key:" },
            //                   //             }
            //                   //        },
            //                   //        new Detail{
            //                   //             Type=ContentType.Picture,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new PictureSourceContent{ Srcset="./img/zsh-tab-switch.png" },
            //                   //                 new ImageContent{ Src="./img/zsh-tab-switch.png", Alt="auto complete  demo"}
            //                   //             }
            //                   //        },
            //                   //        new Detail{
            //                   //             Type=ContentType.Paragraph,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new HTMLContent{ Value= "Autocorrect:" },
            //                   //             }
            //                   //        },
            //                   //        new Detail{
            //                   //             Type=ContentType.Picture,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new PictureSourceContent{ Srcset="./img/zsh-autocorrect.png" },
            //                   //                 new ImageContent{ Src="./img/zsh-autocorrect.png", Alt="auto correction demo"}
            //                   //             }
            //                   //        },
            //                   //        new Detail{
            //                   //             Type=ContentType.Paragraph,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new HTMLContent{ Value= "Alias finder:" },
            //                   //             }
            //                   //        },
            //                   //        new Detail{
            //                   //             Type=ContentType.Picture,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new PictureSourceContent{ Srcset="./img/zsh-alias-finder.png" },
            //                   //                 new ImageContent{ Src="./img/zsh-alias-finder.png", Alt="alias finder demo"}
            //                   //             }
            //                   //        },
            //                   //        new Detail{
            //                   //             Type=ContentType.Paragraph,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new HTMLContent{ Value= "Command not found:" },
            //                   //             }
            //                   //        },
            //                   //        new Detail{
            //                   //             Type=ContentType.Picture,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new PictureSourceContent{ Srcset="./img/zsh-command-not-found.png" },
            //                   //                 new ImageContent{ Src="./img/zsh-command-not-found.png", Alt="command not found demo"}
            //                   //             }
            //                   //        },
            //                   //     }
            //                   //},
            //                   // new Section {
            //                   //     Id="virtual",
            //                   //     Header="Virtualization Software",
            //                   //     HasMainContent=true,
            //                   //     Details= new List<Detail>{
            //                   //        new Detail{
            //                   //            Type=ContentType.Paragraph,
            //                   //            Contents= new List<HTMLContent>{ new HTMLContent { Value= "The Virtualization category includes scripts for installing toolsets & software such as Docker / Podman which make it easier to consume / ship software by professionals." } }
            //                   //        },
            //                   //     }
            //                   //},
            //                   // new Section {
            //                   //     Id="docker",
            //                   //     Header="1) Docker Desktop with WSL2 Backend",
            //                   //     Details= new List<Detail>{
            //                   //        new Detail{
            //                   //             Type=ContentType.Paragraph,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new HTMLContent{ Value= "This installs " },
            //                   //                 new LinkContent{ Value="Docker Desktop", Href="https://www.docker.com/products/docker-desktop"},
            //                   //                 new HTMLContent{ Value= " with the WSL2 backend through the chocolatey package manager. Historically very difficult to achieve but today its not even a few lines of code, what a time to be alive!" },
            //                   //             }
            //                   //        },
            //                   //  }
            //                   //},
            //                   // new Section {
            //                   //     Id="podman",
            //                   //     Header="2) Podman",
            //                   //     Details= new List<Detail>{
            //                   //        new Detail{
            //                   //             Type=ContentType.Paragraph,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new HTMLContent{ Value= "Much like Docker, " },
            //                   //                 new LinkContent{ Value="Podman", Href="https://podman.io/"},
            //                   //                 new HTMLContent{ Value= " is a software for managing OCI Containers, this installation is provided as an alternative for the ones who prefer it instead of Docker." },
            //                   //             }
            //                   //        },
            //                   //  }
            //                   //},
            //                   //new Section {
            //                   //     Id="sdk",
            //                   //     Header="SDK & Internal Tooling",
            //                   //     HasMainContent=true,
            //                   //     Details= new List<Detail>{
            //                   //        new Detail{
            //                   //            Type=ContentType.Paragraph,
            //                   //            Contents= new List<HTMLContent>{ new HTMLContent { Value= "The scripts under this section are all about giving developers more power by making internal Sinda tools available. The tools function as encapsulation on certain tasks into one liners." } }
            //                   //        },
            //                   //     }
            //                   //},
            //                   // new Section {
            //                   //     Id="sindamodule",
            //                   //     Header="1) Sinda Developer Tools",
            //                   //     Details= new List<Detail>{
            //                   //        new Detail{
            //                   //             Type=ContentType.Paragraph,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new HTMLContent{ Value= "This is a Powershell module & an exact copy of the internal scripts used with the CLI tool wrapped in an easily importable format." },
            //                   //                 new HTMLContent{ Value= "the command imports the module located at src/script/Sindagal.psm1 into the powershell profile of the user using the machine" },
            //                   //                 new HTMLContent{ Value= "Once the module is imported, the developer gains direct access to all the features included in the CLI & more through direct powershell commands!" },
            //                   //             }
            //                   //        },
            //                   //        new Detail{
            //                   //             Type=ContentType.Paragraph,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new HTMLContent{ Value= "All the commands could be inspected in the file location mentioned within the CLI repository, however some of them are explained below." },
            //                   //             }
            //                   //        },
            //                   //     new Detail{
            //                   //         Type=ContentType.Paragraph,
            //                   //         Contents= new List<HTMLContent>{
            //                   //             new HTMLContent{ Value= "To check the current state of your system for things such as os version, architecture, wsl2 support etc: "}
            //                   //         }
            //                   //     },
            //                   //     new Detail{
            //                   //         Type=ContentType.Code,
            //                   //         Contents= new List<HTMLContent>{
            //                   //             new CodeContent{ Language="shell", Value= "Get-EnvState" },
            //                   //         }
            //                   //     },
            //                   //     new Detail{
            //                   //         Type=ContentType.Paragraph,
            //                   //         Contents= new List<HTMLContent>{
            //                   //             new HTMLContent{ Value= "To install WSL on legacy systems where WSL2 or wsl --install command are not supported "}
            //                   //         }
            //                   //     },
            //                   //     new Detail{
            //                   //         Type=ContentType.Code,
            //                   //         Contents= new List<HTMLContent>{
            //                   //             new CodeContent{ Language="shell", Value= "Enable-WSLLegacy" },
            //                   //         }
            //                   //     },
            //                   //     new Detail{
            //                   //         Type=ContentType.Paragraph,
            //                   //         Contents= new List<HTMLContent>{
            //                   //             new HTMLContent{ Value= "To download & import the Sinda pre configured wsl2 instance:"}
            //                   //         }
            //                   //     },
            //                   //     new Detail{
            //                   //         Type=ContentType.Code,
            //                   //         Contents= new List<HTMLContent>{
            //                   //             new CodeContent{ Language="shell", Value= "Add-SindaDistro" },
            //                   //         }
            //                   //     },
            //                   //     new Detail{
            //                   //         Type=ContentType.Paragraph,
            //                   //         Contents= new List<HTMLContent>{
            //                   //             new HTMLContent{ Value= "Check if terminal session has admin rights:"}
            //                   //         }
            //                   //     },
            //                   //     new Detail{
            //                   //         Type=ContentType.Code,
            //                   //         Contents= new List<HTMLContent>{
            //                   //             new CodeContent{ Language="shell", Value= "Test-Elevation" },
            //                   //         }
            //                   //     },
            //                   //     new Detail{
            //                   //         Type=ContentType.Paragraph,
            //                   //         Contents= new List<HTMLContent>{
            //                   //             new HTMLContent{ Value= "Install & Configure Windows Terminal with Nerd Fonts:"}
            //                   //         }
            //                   //     },
            //                   //     new Detail{
            //                   //         Type=ContentType.Code,
            //                   //         Contents= new List<HTMLContent>{
            //                   //             new CodeContent{ Language="shell", Value= "Enable-WindowsTerminal" },
            //                   //         }
            //                   //     },
            //                   //     new Detail{
            //                   //         Type=ContentType.Paragraph,
            //                   //         Contents= new List<HTMLContent>{
            //                   //             new HTMLContent{ Value= "Disable & delete Windows Terminal:"}
            //                   //         }
            //                   //     },
            //                   //     new Detail{
            //                   //         Type=ContentType.Code,
            //                   //         Contents= new List<HTMLContent>{
            //                   //             new CodeContent{ Language="shell", Value= "Disable-WindowsTerminal" },
            //                   //         }
            //                   //     },
            //                   //     new Detail{
            //                   //             Type=ContentType.Paragraph,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new HTMLContent{ Value= "And many more!" },
            //                   //             }
            //                   //        },
            //                   //  }
            //                   //},
            //                   //new Section {
            //                   //     Id="boilerplate",
            //                   //     Header="Boilerplates & Codebases",
            //                   //     HasMainContent=true,
            //                   //     Details= new List<Detail>{
            //                   //        new Detail{
            //                   //            Type=ContentType.Paragraph,
            //                   //            Contents= new List<HTMLContent>{ new HTMLContent { Value= "The Boilerplate section contains scripts which clone Ready to go Sinda Codebases from github. The repositories are intended to solve common problems & be as easily personalized as possible." } }
            //                   //        }
            //                   //     }
            //                   //},
            //                   // new Section {
            //                   //     Id="portfolio",
            //                   //     Header="1) Sinda Portfolio",
            //                   //     Details= new List<Detail>{
            //                   //        new Detail{
            //                   //             Type=ContentType.Paragraph,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new HTMLContent{ Value= "This clones a reusable & extensible web portfolio template written with React using the NextJS framework. The repository could be found " },
            //                   //                 new LinkContent{ Value="here.", Href="https://github.com/denzii/sinda-portfolio"},
            //                   //                 new HTMLContent{ Value= "This simplistic portfolio itself has basic SEO optimizations, keyboard and developer accessibility; a performant " },
            //                   //                 new LinkContent{ Value="Chrome Lighthouse", Href="https://developers.google.com/web/tools/lighthouse"},
            //                   //                 new HTMLContent{ Value= " score as well as good responsive UI/UX principles!" },
            //                   //                 new HTMLContent{ Value= " Feel free to change the data & reupload it to your favourite version-control website as you please!" },
            //                   //             }
            //                   //        },
            //                   //        new Detail{
            //                   //             Type=ContentType.Paragraph,
            //                   //             Contents= new List<HTMLContent>{
            //                   //                 new HTMLContent{ Value= "For more information regarding this template & web theme, please refer to the Boilerplate tab on this page." },
            //                   //             }
            //                   //        },
            //                   //  }
            //                   //},
            //                //}
            //            },
            //            new PageTab
            //            {
            //                Name = "Boilerplate",
            //                Status = SectionStatus.Public,
            //                //Sections = new List<Section> {
            //                    //new Section {
            //                    //    Id="Introduction",
            //                    //    Header="Introduction",
            //                    //    HasMainContent= true,
            //                    //    Details= new List<Detail>{
            //                    //       new Detail{
            //                    //            Type=ContentType.Paragraph,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new HTMLContent{ Value= "Do you have some boilerplate code which you always have to write from scratch? Are you in a hurry to get up and running with an MVP?" },
            //                    //                new HTMLContent{ Value= " Sindagal Boilerplates will come to your rescue!" },
            //                    //                new HTMLContent{ Value= " On this page, we will be exploring how to set up and work with existing code as well as how to extend them to our needs to save time from cumbersome work!" } }
            //                    //       },
            //                    //    }
            //                    //},
            //                    //new Section {
            //                    //    Id="portfolio",
            //                    //    Header="1) Sinda Portfolio",
            //                    //    Details= new List<Detail>{
            //                    //       new Detail{
            //                    //           Type=ContentType.Paragraph,
            //                    //           Contents= new List<HTMLContent>{
            //                    //               new HTMLContent{ Value= "Planning to look for that next challange in your career but do not have time to fiddle with UI/UX or write the code for a portfolio website from scratch?" },
            //                    //               new HTMLContent{ Value= " You can now rest easy with this " },
            //                    //               new LinkContent{ Value="web portfolio.", Href="https://github.com/denzii/sinda-portfolio"},
            //                    //               new HTMLContent{ Value= " This template simplistic enough to do the job and will hit the spot with its SEO optimizations, keyboard and developer accessibility; a performant " },
            //                    //               new LinkContent{ Value="Lighthouse", Href="https://developers.google.com/web/tools/lighthouse"},
            //                    //               new HTMLContent{ Value= " score as well as good responsive UI/UX principles!" },
            //                    //               new HTMLContent{ Value= " please find a live example at" },
            //                    //               new LinkContent{ Value="denizarca.com", Href="https://denizarca.com"} },
            //                    //       }
            //                    //    }
            //                    //},
            //                    //new Section {
            //                    //    Id="portfolioSetup",
            //                    //    Header="Setting up the repository",
            //                    //    Details= new List<Detail>{
            //                    //       new Detail{
            //                    //           Type=ContentType.Paragraph,
            //                    //           Contents= new List<HTMLContent>{
            //                    //               new HTMLContent{ Value= "This is a NextJS TypeScript project so NodeJS & npm are required as a prerequisite." },
            //                    //               new HTMLContent{ Value= "If those already exist on the machine or if you are using the pre configured WSL instance, its okay to proceed to cloning the repository." },
            //                    //               },

            //                    //       },
            //                    //       new Detail{
            //                    //            Type=ContentType.Code,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new CodeContent{ Language="shell", Value= "git clone https://github.com/denzii/sinda-portfolio.git" },
            //                    //            }
            //                    //        },
            //                    //        new Detail{
            //                    //            Type=ContentType.Paragraph,
            //                    //            Contents= new List<HTMLContent>{
            //                    //               new HTMLContent{ Value= "Install Nextjs globally:" },
            //                    //            },
            //                    //        },
            //                    //        new Detail{
            //                    //            Type=ContentType.Code,
            //                    //            Contents= new List<HTMLContent>{
            //                    //               new CodeContent{ Language="shell", Value= "npm i -g next" },
            //                    //            }
            //                    //        },
            //                    //        new Detail{
            //                    //               Type=ContentType.Paragraph,
            //                    //               Contents= new List<HTMLContent>{
            //                    //                   new HTMLContent{ Value= "Move into the repository, install dependencies and run the app:" },
            //                    //               },

            //                    //           },
            //                    //        new Detail{
            //                    //            Type=ContentType.Code,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new CodeContent{ Language="shell", Value= "cd sinda-portfolio" },
            //                    //            }
            //                    //        },
            //                    //        new Detail{
            //                    //            Type=ContentType.Code,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new CodeContent{ Language="shell", Value= "npm install" },
            //                    //            }
            //                    //        },
            //                    //        new Detail{
            //                    //            Type=ContentType.Code,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new CodeContent{ Language="shell", Value= "npm run dev" },
            //                    //            }
            //                    //        },

            //                    //        new Detail{
            //                    //            Type=ContentType.Paragraph,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new HTMLContent{ Value= "If everything went well, it's now okay to visit localhost:3000 in your favourite browser to see the site!" },
            //                    //            },
            //                    //        },
            //                    //        new Detail{
            //                    //            Type=ContentType.Picture,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new PictureSourceContent{ Srcset="./img/portfolio-landing-page-850w.png", Media="(max-width: 950px)"},
            //                    //                new PictureSourceContent{ Srcset="./img/portfolio-landing-page.png"},
            //                    //                new ImageContent{ Src="./img/portfolio-landing-page.png", Alt="Portfolio Landing Page"}
            //                    //            }
            //                    //        },


            //                    //    }

            //                    //},
            //                    //new Section {
            //                    //    Id="portfolioHero",
            //                    //    Header="Changing the hero section content",
            //                    //    Details= new List<Detail>{
            //                    //        new Detail{
            //                    //            Type=ContentType.Paragraph,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new HTMLContent{ Value= "Not bad! In order to personalize it, we need to make a few tweaks." },
            //                    //                new HTMLContent{ Value= " The data is pulled into a single class at " },
            //                    //                new LinkContent{ Value="data/index.ts", Href="https://github.com/denzii/sinda-portfolio/blob/main/data/index.ts"},
            //                    //                new HTMLContent{ Value= " class for the most part and this is where we will spend most of our time." },
            //                    //                new HTMLContent{ Value= " having said that, the page title and the meta tags for SEO as well as canonical must also be changed for a fully personalized portfolio. In a NextJS project, these are stored in " },
            //                    //                new LinkContent{ Value="pages/_document.tsx", Href="https://github.com/denzii/sinda-portfolio/blob/main/pages/_document.tsx"},
            //                    //                new HTMLContent{ Value= " as per convention. It is planned to pull these into the data folder in the future as well!" },
            //                    //            },
            //                    //        },
            //                    //        new Detail{
            //                    //            Type=ContentType.Paragraph,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new HTMLContent{ Value= "Let's view the code in our favourite code editor and see how to go about the modifications!" },
            //                    //            },
            //                    //        },
            //                    //        new Detail{
            //                    //            Type=ContentType.Code,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new CodeContent{ Language="shell", Value= "code ." },
            //                    //            }
            //                    //        },
            //                    //        new Detail{
            //                    //            Type=ContentType.Paragraph,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new HTMLContent{ Value= "To start things off, lets change the navigation bar contents by changing the ProjectOwner, PersonalURLs & PersonalBackground Objects as shown." },
            //                    //            },
            //                    //        },
            //                    //        new Detail{
            //                    //            Type=ContentType.Picture,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new PictureSourceContent{ Srcset="./img/portfolio-navbar-name-diff-850w.png", Media="(max-width: 950px)"},
            //                    //                new PictureSourceContent{ Srcset="./img/portfolio-navbar-name-diff.png",},
            //                    //                new ImageContent{ Src="./img/portfolio-navbar-name-diff.png", Alt="Portfolio Navbar modification"}
            //                    //            }
            //                    //        },
            //                    //        new Detail{
            //                    //            Type=ContentType.Paragraph,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new HTMLContent{ Value= " Icons for social media could be changed by supplying a name from the " },
            //                    //                new LinkContent{ Value="React Font Awesome", Href="https://react-icons.github.io/react-icons/icons?name=fa"},
            //                    //                new HTMLContent{ Value= " Icons. Additional navigation links such as \"instagram\" could also be added or removed if desired by altering the keys on the" },
            //                    //                new LinkContent{ Value="interface/personalUrls.ts", Href="https://github.com/denzii/sinda-portfolio/blob/main/interface/personalUrls.ts"},
            //                    //                new HTMLContent{ Value= " class further. For demonstration purposes, lets remove the email icon while changing the other two icons." },
            //                    //            },
            //                    //        },
            //                    //        new Detail{
            //                    //            Type=ContentType.Picture,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new PictureSourceContent{ Srcset="./img/portfolio-socialbar-diff-850w.png", Media="(max-width: 950px)"},
            //                    //                new PictureSourceContent{ Srcset="./img/portfolio-socialbar-diff.png",},
            //                    //                new ImageContent{ Src="./img/portfolio-socialbar-diff.png", Alt="Portfolio Socialbar modification"}
            //                    //            }
            //                    //        },
            //                    //        new Detail{
            //                    //            Type=ContentType.Paragraph,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new HTMLContent{ Value= " The keys on the object " },
            //                    //                new LinkContent{ Value="interface/background.ts", Href="https://github.com/denzii/sinda-portfolio/blob/main/interface/background.ts"},
            //                    //                new HTMLContent{ Value= " are used to generate the sections below the hero section. If we wanted to add or remove or alter a section, all we would need to do is to alter the keys on it!" },
            //                    //                new HTMLContent{ Value= " for the sake of this tutorial, let's remove the hobbies section and rename some of the others!" },
            //                    //            },
            //                    //        },
            //                    //        new Detail{
            //                    //            Type=ContentType.Picture,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new PictureSourceContent{ Srcset="./img/portfolio-navbar-elems-diff-850w.png", Media="(max-width: 950px)"},
            //                    //                new PictureSourceContent{ Srcset="./img/portfolio-navbar-elems-diff.png",},
            //                    //                new ImageContent{ Src="./img/portfolio-navbar-elems-diff.png", Alt="Portfolio Navbar elements modification" }
            //                    //            }
            //                    //        },
            //                    //        new Detail{
            //                    //            Type=ContentType.Paragraph,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new HTMLContent{ Value= " Now that those are out of the way, its a good time to change the background and the headshot images which are located inside the " },
            //                    //                new LinkContent{ Value="public", Href="https://github.com/denzii/sinda-portfolio/tree/main/public"},
            //                    //                new HTMLContent{ Value= " directory, all that is required is to drop in the images in that directory and reference them inside the data class. The app is written flexible enough to allow the usage of different image names as-well!" },
            //                    //            },
            //                    //        },
            //                    //        new Detail{
            //                    //            Type=ContentType.Picture,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new PictureSourceContent{ Srcset="./img/portfolio-hero-diff.png",},
            //                    //                new ImageContent{ Src="./img/portfolio-hero-diff.png", Alt="Portfolio hero images modification" }
            //                    //            }
            //                    //        },

            //                    //    }
            //                    //},
            //                    //new Section {
            //                    //    Id="portfolioBody",
            //                    //    Header="Changing the body section contents",
            //                    //    Details= new List<Detail>{
            //                    //        new Detail{
            //                    //            Type=ContentType.Paragraph,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new HTMLContent{ Value= "We've come a long way and the results are just beautiful! Refresh the browser page to see that the website now looks like this: " },
            //                    //            },
            //                    //        },
            //                    //        new Detail{
            //                    //            Type=ContentType.Picture,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new PictureSourceContent{ Srcset="./img/portfolio-altered-hero-diff-850w.png", Media="(max-width: 950px)"},
            //                    //                new PictureSourceContent{ Srcset="./img/portfolio-altered-hero-diff.png",},
            //                    //                new ImageContent{ Src="./img/portfolio-altered-hero-diff.png", Alt="Portfolio altered hero section" }
            //                    //            }
            //                    //        },
            //                    //        new Detail{
            //                    //            Type=ContentType.Paragraph,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new HTMLContent{ Value= "How about the body sections? Are they even flexible enough for personalization? They sure are! All that needs to be done is to alter the methods which are being called within the \"PersonalBackground\" method inside the data class." },
            //                    //                new HTMLContent{ Value= " The heading, date range & inner content are supplied within the same place, the inner content could be made bold, italic or emphasized on demand without touching any HTML." },

            //                    //            },
            //                    //        },
            //                    //        new Detail{
            //                    //            Type=ContentType.Paragraph,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new HTMLContent{ Value= " If it's a semantic markup for your website which you are looking for; you can add emphasis and other things to certain text but also keep it unstyled." },
            //                    //                new HTMLContent{ Value= " This is a good idea if you would like your website to read well by screen readers so elements could be emphesized without changing the visual feeling..." },
            //                    //                new HTMLContent{ Value= " The body elements could be given captions aswell by assigning the \"caption\" field a string value." },
            //                    //            },
            //                    //        },
            //                    //       new Detail{
            //                    //            Type=ContentType.Paragraph,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new HTMLContent{ Value= "Example body section element code:" },
            //                    //            },
            //                    //        },
            //                    //       new Detail{
            //                    //            Type=ContentType.Picture,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new PictureSourceContent{ Srcset="./img/portfolio-body-code.png", Media="(max-width: 950px)"},
            //                    //                new ImageContent{ Src="./img/portfolio-body-code.png", Alt="Portfolio body code example" }
            //                    //            }
            //                    //        },
            //                    //        new Detail{
            //                    //            Type=ContentType.Paragraph,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new HTMLContent{ Value= "Only one thing remains, changing the meta content of the site! And this is as easy as going into the pages/_document.tsx" },
            //                    //                new LinkContent{ Value="pages/_document.tsx", Href="https://github.com/denzii/sinda-portfolio/tree/main/public"},
            //                    //                new HTMLContent{ Value= " file and altering the given strings." },
            //                    //                new HTMLContent{ Value= " add in the full address of your domain as a canonical, change the tab title as you wish and amend the keywords to cater to your target audiences google searches." },
            //                    //            },
            //                    //        },
            //                    //        new Detail{
            //                    //            Type=ContentType.Paragraph,
            //                    //            Contents= new List<HTMLContent>{
            //                    //                new HTMLContent{ Value= "That is all! Enjoy your Sinda Portfolio and do not forget to give a star or send your pull requests!" },
            //                    //                new HTMLContent{ Value= " We will not be touching on how to deploy this website since it is using the stock CI/CD which is provided by Vercel for free on personal projects." },
            //                    //                new HTMLContent{ Value= " To find out more about deployments, visit their tutorials at " },
            //                    //                new LinkContent{ Value="nextjs.org/deployment", Href="https://nextjs.org/docs/deployment"},
            //                    //            },
            //                    //        },
            //                    //    }
            //                    //},
            //                //}

            //        }
            //        );

            //        modelBuilder.Entity<Page>().HasData(
            //            new Page
            //            {
            //                Name = "Docs",
            //                //Tabs = new List<PageTab> {
            //                //    new PageTab{
            //                //        Name="Terminal",
            //                //        Status=SectionStatus.Public,
            //                //        Sections = new List<Section> {
            //                //            new Section {
            //                //                Id="introduction",
            //                //                Header="Introduction",
            //                //                HasMainContent=true,
            //                //                Details= new List<Detail>{
            //                //                   new Detail{
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "Sindagal " },
            //                //                            new LinkContent{ Value= "Command Line Interface", Href="https://github.com/denzii/sinda-cli" },
            //                //                            new HTMLContent{ Value= " is a simple Node.js application which makes use of the popular JavaScript framework React. The goal is to make developer lives more convenient by wrapping around operating system level scripts and allowing their easy consumption." }
            //                //                        }
            //                //                   },
            //                //                   new Detail{
            //                //                       Contents= new List<HTMLContent>{ new WarningContent{ Value= "For the time being, usages from within WSL & Unix based systems had been disabled." } }
            //                //                   },
            //                //                   new Detail{
            //                //                       Contents= new List<HTMLContent>{ new HTMLContent { Value= "On this page, you'll learn what the Sinda Command Line Interface brings to the table and how it can be consumed by setting it up from scratch and consuming some of the built in automation scripts on a Windows machine." } }
            //                //                   }
            //                //                }
            //                //            },
            //                //            new Section{
            //                //              Id="setup",
            //                //              Header="Getting Started",
            //                //              HasMainContent=false,
            //                //              Details= new List<Detail>{
            //                //                new Detail{
            //                //                    Type=ContentType.Paragraph,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new HTMLContent{ Value= "The project requires Node.js LTS and npm to be installed as a pre-requisite so if you do not already have them, now is a good time to set them up." },
            //                //                        new LinkContent{ Value="This tutorial", Href="https://docs.microsoft.com/en-us/windows/dev-environment/javascript/nodejs-on-windows"},
            //                //                        new HTMLContent{ Value= "by Microsoft demonstrates how they could be set on a Windows machine using the Node Version Manager tool (NVM)."}
            //                //                    }
            //                //                },
            //                //                new Detail{
            //                //                    Type=ContentType.Paragraph,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new HTMLContent{ Value="Once NVM & Node.js are configured, we could proceed to cloning the repository and running the app from the cloned source code. Its necessary to fork and/or clone the repository since the app itself requires access to the localhost machine so it can run powershell/bash scripts."}
            //                //                    }
            //                //                },
            //                //                new Detail{
            //                //                    Type=ContentType.Code,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new CodeContent{Language="shell", Value="git clone https://github.com/denzii/sinda-cli.git"}
            //                //                    }
            //                //                },
            //                //                new Detail{
            //                //                    Type=ContentType.Code,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new CodeContent{Language="shell", Value="cd sinda-cli"}
            //                //                    }
            //                //                },
            //                //                new Detail{
            //                //                    Type=ContentType.Code,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new CodeContent{Language="shell", Value="npm start"}
            //                //                    }
            //                //                },
            //                //                new Detail{
            //                //                    Type=ContentType.Warning,
            //                //                    Contents= new List<HTMLContent>{ new HTMLContent{ Value= "The app requires administrator rights to run Powershell / Bash scripts on localhost, if its run from a non-elevated terminal session, it will result in an error and not run." } }
            //                //                },
            //                //                new Detail{
            //                //                    Type=ContentType.Paragraph,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new HTMLContent{Value="The following image demonstrates the landing page for a successfully started CLI."}
            //                //                    }
            //                //                },
            //                //                new Detail{
            //                //                    Type=ContentType.Picture,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new PictureSourceContent{ Srcset="./img/cli-landing-page-850w.png", Media="(max-width: 950px)"},
            //                //                        new PictureSourceContent{ Srcset="./img/cli-landing-page.png"},
            //                //                        new ImageContent{ Src="./img/cli-landing-page.png", Alt="CLI Landing Page"}
            //                //                    }
            //                //                },

            //                //             }
            //                //           },
            //                //           new Section {
            //                //                Id="usage",
            //                //                Header="Usage",
            //                //                HasMainContent=false,
            //                //                Details= new List<Detail>{
            //                //                   new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "Consuming scripts from the app is pretty straight forward and takes only a few key-presses to achieve. As seen on the landing page image, the terminal prompt functions similarly to a single page app and the visible part of the terminal is hijacked by a" },
            //                //                            new LinkContent{ Value="React Ink", Href="https://github.com/vadimdemedes/ink"},
            //                //                            new HTMLContent{ Value= "Component" },
            //                //                        }

            //                //                   },
            //                //                   new Detail{
            //                //                       Type=ContentType.Paragraph,
            //                //                       Contents= new List<HTMLContent>{ new HTMLContent{ Value= "The component itself detects the screen height and width and resizes accordingly. Having said that, a maximized terminal window is recommended for the best experience and the resizing  feature is only meant for the application startup. If the terminal window gets resized while the app is running, there are no guarantees for correct rendering of the component." } }
            //                //                   },
            //                //                   new Detail{
            //                //                       Type=ContentType.Paragraph,
            //                //                       Contents= new List<HTMLContent>{ new HTMLContent{ Value= "Once a key is pressed on the landing page, the survey component is rendered and the user is presented with all the available automation scripts... Navigation of the form is achieved through the <i>Up / Down / Enter & Esc </i> keys. This component is demonstrated in the following image." } }
            //                //                   },
            //                //                   new Detail{
            //                //                    Type=ContentType.Picture,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new PictureSourceContent{ Srcset="./img/cli-survey-page-850w.png", Media="(max-width: 950px)"},
            //                //                        new PictureSourceContent{ Srcset="./img/cli-survey-page.png"},
            //                //                        new ImageContent{ Src="./img/cli-survey-page.png", Alt="CLI Survey Page"}
            //                //                    }
            //                //                  },
            //                //                  new Detail{
            //                //                       Type=ContentType.Paragraph,
            //                //                       Contents= new List<HTMLContent>{ new HTMLContent{  Value= "For the sake of this tutorial, we are only going to be selecting the first three options. Once the selections are made, it is required to navigate to the last page of the survey and confirm the selections.  The \"proceed\" button will ask for a re-confirmation and esc key could be used to go back to the form."},  }
            //                //                  },
            //                //                  new Detail{
            //                //                    Type=ContentType.Picture,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new PictureSourceContent{ Srcset="./img/cli-survey-page-confirmation-850w.png", Media="(max-width: 950px)"},
            //                //                        new PictureSourceContent{ Srcset="./img/cli-survey-page-confirmation.png"},
            //                //                        new ImageContent{ Src="./img/cli-survey-page-confirmation.png", Alt="CLI Survey Page Confirmation"}
            //                //                    }
            //                //                  },
            //                //                  new Detail{
            //                //                       Type=ContentType.Paragraph,
            //                //                       Contents= new List<HTMLContent>{ new HTMLContent{ Value= "Prior to making any changes to the machine, all the selected features and their corresponding scripts are listed and a confirmation is requested once more for extra safety."} }
            //                //                  },
            //                //                  new Detail{
            //                //                    Type=ContentType.Picture,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new PictureSourceContent{ Srcset="./img/cli-survey-page-confirmation-2-850w.png", Media="(max-width: 950px)"},
            //                //                        new PictureSourceContent{ Srcset="./img/cli-survey-page-confirmation-2.png"},
            //                //                        new ImageContent{ Src="./img/cli-survey-page-confirmation-2.png", Alt="CLI Survey Page Finalization"}
            //                //                    }
            //                //                  },
            //                //                  new Detail{
            //                //                    Type=ContentType.Warning,
            //                //                    Contents= new List<HTMLContent>{ new HTMLContent{ Value= "For the time being, the scripts are executed syncronously and the results within the box are updated all at once." } }
            //                //                  },
            //                //                  new Detail{
            //                //                       Type=ContentType.Paragraph,
            //                //                       Contents= new List<HTMLContent>{ new HTMLContent{ Value= "The Standard Outputs as well as Errors for the executed commands are pushed above the component box in real-time. A finished session is demonstrated in the below image."} }
            //                //                  },
            //                //                  new Detail{
            //                //                    Type=ContentType.Picture,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new PictureSourceContent{ Srcset="./img/cli-survey-page-results-850w.png", Media="(max-width: 950px)"},
            //                //                        new PictureSourceContent{ Srcset="./img/cli-survey-page-results.png"},
            //                //                        new ImageContent{ Src="./img/cli-survey-page-results.png", Alt="CLI Survey Page Results"}
            //                //                    }
            //                //                  },
            //                //                  new Detail{
            //                //                       Type=ContentType.Paragraph,
            //                //                       Contents= new List<HTMLContent>{ new HTMLContent{ Value= "Thats all folks! See how easy it was to consume some powershell scripts? To see the full list of the existing scripts, please navigate to the scripts tab on this page."} }
            //                //                  },
            //                //             }
            //                //           }
            //                //        }
            //                //        },
            //                //    new PageTab{
            //                //        Name="Scripts",
            //                //        Status=SectionStatus.Public,
            //                //        Sections = new List<Section> {
            //                //            new Section {
            //                //                Id="Introduction",
            //                //                Header="Introduction",
            //                //                HasMainContent= true,
            //                //                Details= new List<Detail>{
            //                //                   new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "As described in the Terminal tab, Sindagal comes with some built-in scripts and can also be extended to interface to personal scripts. The scripts are categorized as Terminal, Shell, Virtual, SDK & Boilerplate." },
            //                //                            new HTMLContent{ Value= " The CLI tool works by executing powershell / bash scripts which exist inside the code repository itself under the src/scripts directory." } }
            //                //                   },
            //                //                   new Detail {
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents=new List<HTMLContent>{
            //                //                            new HTMLContent{ Value=" On this page, we will be exploring the various details regarding those features and why they might come in handy for you or your organisation."}
            //                //                        }
            //                //                   },
            //                //                   new Detail{
            //                //                       Type=ContentType.Warning,
            //                //                       Contents= new List<HTMLContent>{
            //                //                           new HTMLContent{ Value= "For the time being, everything is in the Minimum Viable Product stage & things might change in the future. Please report any problems or bugs to me personally through my " },
            //                //                           new LinkContent{ Value= "Linkedin.", Href="https://www.linkedin.com/in/denizarca/" },
            //                //                           new HTMLContent{ Value= " Pull requests are welcome at the " },
            //                //                           new LinkContent{ Value= "CLI repository.", Href="https://github.com/denzii/sinda-cli" },
            //                //                       }
            //                //                   },
            //                //                }
            //                //            },
            //                //            new Section {
            //                //                Id="terminal",
            //                //                HasMainContent= true,
            //                //                Header="Terminal Extensions",
            //                //                Details= new List<Detail>{
            //                //                   new Detail{
            //                //                       Type=ContentType.Paragraph,
            //                //                       Contents= new List<HTMLContent>{ new HTMLContent{ Value= "This category is where the scripts regarding the interactive terminal session reside. These will alter the look & feel of your interactions with your local shell." } }
            //                //                   }
            //                //                }
            //                //            },
            //                //            new Section {
            //                //                Id="ohmyposh",
            //                //                Header="1) Oh My Posh & Nerd Fonts",
            //                //                Details= new List<Detail>{
            //                //                   new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                           new HTMLContent{ Value= "By default, terminal prompts on Windows machines come with no support for user themes, lack descriptiveness and are not intuitive to use. Wouldn't it be nice if the sessions could be personalized & extended with additional information such as the time of command execution, git active branch names, battery level and more?" },
            //                //                           new HTMLContent{ Value= " Enter " },
            //                //                           new LinkContent{ Value= "Oh My Posh!", Href="https://ohmyposh.dev/" },
            //                //                           new HTMLContent{ Value= " A shell framework for doing all of that! Historically this worked only on Windows but with Powershell going cross platform, it now works on Linux & Mac as well. " },
            //                //                        }
            //                //                   },
            //                //                   new Detail{
            //                //                       Type=ContentType.Paragraph,
            //                //                       Contents= new List<HTMLContent>{
            //                //                           new HTMLContent{ Value= "The framework is easily configurable... All available themes could be reviewed by: " },
            //                //                       }
            //                //                   },
            //                //                   new Detail{
            //                //                        Type=ContentType.Code,
            //                //                        Contents= new List<HTMLContent>{
            //                //                           new CodeContent{ Language="shell", Value= "Get-PoshThemes" },
            //                //                        }
            //                //                   },
            //                //                   new Detail{
            //                //                       Type=ContentType.Paragraph,
            //                //                       Contents= new List<HTMLContent>{
            //                //                           new HTMLContent{ Value= "changing the theme to \"Darkblood\": " },
            //                //                       }
            //                //                   },
            //                //                   new Detail{
            //                //                        Type=ContentType.Code,
            //                //                        Contents= new List<HTMLContent>{
            //                //                           new CodeContent{ Language="shell", Value= "Set-PoshPrompt darkblood" },
            //                //                        }
            //                //                   },
            //                //                   new Detail{
            //                //                       Type=ContentType.Paragraph,
            //                //                       Contents= new List<HTMLContent>{
            //                //                           new HTMLContent{ Value= "Having said that, it is also possible to configure it via code by adjusting an init script at a location which can be found from the Get-PoshThemes command. " },
            //                //                       }
            //                //                   },
            //                //                   new Detail{
            //                //                       Type=ContentType.Paragraph,
            //                //                       Contents= new List<HTMLContent>{
            //                //                           new HTMLContent { Value= "Oh My Posh relies on a specific font family in order to display its many glyphs properly, Sinda takes care of installing the " },
            //                //                           new LinkContent { Value= "Nerd Fonts", Href="https://github.com/ryanoasis/nerd-fonts"},
            //                //                           new HTMLContent { Value= " for you!" },
            //                //                       }
            //                //                   }
            //                //                }
            //                //            },
            //                //            new Section{
            //                //              Id="winterm",
            //                //              Header="2) Windows Terminal by Microsoft",
            //                //              Details= new List<Detail>{
            //                //                new Detail{
            //                //                    Type=ContentType.Paragraph,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new HTMLContent{ Value= "The default Powershell / Command Prompt & WSL terminal apps are some-what primitive, those emulators damage productivity. They are difficult to impossible to standardize, they require switching between windows which can get tedious & confusing from time to time and they lack certain features when it comes to keyboard shortcuts." },
            //                //                        new LinkContent{ Value= "Windows Terminal", Href="https://docs.microsoft.com/en-us/windows/terminal/" },
            //                //                        new HTMLContent{ Value= " intends to remedy the above problems by allowing multiple tabs, split screens, extensive keyboard macros and multi-shell support."},
            //                //                        new HTMLContent{ Value= " Tabs could contain any session ranging from Azure, WSL2, Remote SSH, Powershell & CMD!"},
            //                //                        new HTMLContent{ Value= " This powerful open source tool also allows launching sessions programatically through powershell commands."}
            //                //                    }
            //                //                },
            //                //                new Detail{
            //                //                    Type=ContentType.Paragraph,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new HTMLContent{ Value= "To start WSL Debian & Powershell sessions programatically: "}
            //                //                    }
            //                //                },
            //                //                new Detail{
            //                //                    Type=ContentType.Code,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new CodeContent{ Language="shell", Value= "wt -p \"Debian\" `; split-pane -p \"Windows PowerShell\" `;" },
            //                //                    }
            //                //                },
            //                //                new Detail{
            //                //                    Type=ContentType.Paragraph,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new HTMLContent{ Value= "Results in the following interactive sessions:"}
            //                //                    }
            //                //                },
            //                //                new Detail{
            //                //                    Type=ContentType.Picture,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new PictureSourceContent{ Srcset="./img/winterm-850w.png", Media="(max-width: 950px)"},
            //                //                        new PictureSourceContent{ Srcset="./img/winterm.png"},
            //                //                        new ImageContent{ Src="./img/winterm", Alt="CLI Landing Page"}
            //                //                    }
            //                //                },
            //                //             }
            //                //            },
            //                //            new Section {
            //                //                Id="poshgit",
            //                //                Header="3) Posh Git",
            //                //                Details= new List<Detail>{
            //                //                   new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "As always, the stock functionality with Windows is lacked and this time its with Git on Powershell & Command Prompt... " },
            //                //                        }
            //                //                   },
            //                //                   new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new LinkContent{ Value="PoshGit", Href="https://github.com/dahlbyk/posh-git"},
            //                //                            new HTMLContent{ Value= "a powershell module, once imported, allows auto completion for all git commands. This makes life easier as less typing is required to navigate daily tasks." },
            //                //                       }
            //                //                   },
            //                //                }
            //                //           },
            //                //            new Section {
            //                //                Id="shell",
            //                //                Header="Shell Modifications",
            //                //                HasMainContent=true,
            //                //                Details= new List<Detail>{
            //                //                   new Detail{
            //                //                       Type=ContentType.Paragraph,
            //                //                       Contents= new List<HTMLContent>{ new HTMLContent{ Value= "The Shell category harbours everything which will alter the installed shell(s) themselves such as changing default powershell versions or installing WSL on localhost etc." } }
            //                //                   },
            //                //                }
            //                //           },
            //                //            new Section {
            //                //                Id="wsl",
            //                //                Header="1) SindaDistro",
            //                //                Details= new List<Detail>{
            //                //                   new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "This is a pre configured WSL2 instance which had been exported and put online for easy consumption." },
            //                //                            new HTMLContent{ Value= " The purpose of this is to encapsulate basic linux setup and provide a ready developer environment for common tasks." },
            //                //                            new HTMLContent{ Value= " It comes with " },
            //                //                            new LinkContent{ Value="Zsh", Href="https://www.zsh.org/"},
            //                //                            new HTMLContent{ Value= " as well as " },
            //                //                            new LinkContent{ Value="Oh My Zsh.", Href="https://ohmyz.sh/"},
            //                //                            new HTMLContent{ Value= " Zsh is the default shell which OSX systems are shipped with and OhMyZsh is a framework for adding magic to it!" },
            //                //                        }
            //                //                   },
            //                //                  new Detail{
            //                //                    Type=ContentType.Warning,
            //                //                    Contents= new List<HTMLContent>{ new HTMLContent{ Value= "The features & plugins are not limited to the ones demonstrated below!" } }
            //                //                  },
            //                //                   new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "Themes could be configured on Oh My Zsh and all the themes which exist for Oh My Posh also exist for Oh My Zsh if not more! all existing " },
            //                //                            new LinkContent{ Value="Oh My Zsh Themes", Href="https://github.com/ohmyzsh/ohmyzsh/wiki/Themes"},
            //                //                            new HTMLContent{ Value= "could be found in the given link! " },
            //                //                            new HTMLContent{ Value= " The Sinda Ubuntu comes with the theme \"agnoster\" but this can easily be changed by amending the .zshrc file." },
            //                //                        }
            //                //                   },
            //                //                   new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "First look on the .zshrc file:" },
            //                //                        }
            //                //                   },
            //                //                   new Detail{
            //                //                        Type=ContentType.Picture,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new PictureSourceContent{ Srcset="./img/zsh-rc.png" },
            //                //                            new ImageContent{ Src="./img/zsh-rc.png", Alt="First look on .zshrc file"}
            //                //                        }
            //                //                   },
            //                //                   new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "As shown in the image above, Oh My Zsh can be configured with many " },
            //                //                            new LinkContent{ Value="plugins,", Href="https://github.com/ohmyzsh/ohmyzsh/wiki/Plugins"},
            //                //                            new HTMLContent{ Value= " plugins which make life convenient! The Sinda Ubuntu comes with the git, debian, alias-finder, docker, command-not-found, thefuck & docker." },
            //                //                            new HTMLContent{ Value= " These of course can be changed by editing the plugins array. Below are some images demonstrating the Zsh & Oh My Zsh features further!" },
            //                //                        }
            //                //                   },
            //                //                   new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "Thefuck:" },
            //                //                        }
            //                //                   },
            //                //                   new Detail{
            //                //                        Type=ContentType.Picture,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new PictureSourceContent{ Srcset="./img/zsh-thefuck.png" },
            //                //                            new ImageContent{ Src="./img/zsh-thefuck.png", Alt="Thefuck demo"}
            //                //                        }
            //                //                   },
            //                //                   new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "Git branch display:" },
            //                //                        }
            //                //                   },
            //                //                   new Detail{
            //                //                        Type=ContentType.Picture,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new PictureSourceContent{ Srcset="./img/zsh-git-branch.png" },
            //                //                            new ImageContent{ Src="./img/zsh-git-branch.png", Alt="git branch display demo"}
            //                //                        }
            //                //                   },
            //                //                   new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "Auto complete & switch on tab key:" },
            //                //                        }
            //                //                   },
            //                //                   new Detail{
            //                //                        Type=ContentType.Picture,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new PictureSourceContent{ Srcset="./img/zsh-tab-switch.png" },
            //                //                            new ImageContent{ Src="./img/zsh-tab-switch.png", Alt="auto complete  demo"}
            //                //                        }
            //                //                   },
            //                //                   new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "Autocorrect:" },
            //                //                        }
            //                //                   },
            //                //                   new Detail{
            //                //                        Type=ContentType.Picture,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new PictureSourceContent{ Srcset="./img/zsh-autocorrect.png" },
            //                //                            new ImageContent{ Src="./img/zsh-autocorrect.png", Alt="auto correction demo"}
            //                //                        }
            //                //                   },
            //                //                   new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "Alias finder:" },
            //                //                        }
            //                //                   },
            //                //                   new Detail{
            //                //                        Type=ContentType.Picture,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new PictureSourceContent{ Srcset="./img/zsh-alias-finder.png" },
            //                //                            new ImageContent{ Src="./img/zsh-alias-finder.png", Alt="alias finder demo"}
            //                //                        }
            //                //                   },
            //                //                   new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "Command not found:" },
            //                //                        }
            //                //                   },
            //                //                   new Detail{
            //                //                        Type=ContentType.Picture,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new PictureSourceContent{ Srcset="./img/zsh-command-not-found.png" },
            //                //                            new ImageContent{ Src="./img/zsh-command-not-found.png", Alt="command not found demo"}
            //                //                        }
            //                //                   },
            //                //                }
            //                //           },
            //                //            new Section {
            //                //                Id="virtual",
            //                //                Header="Virtualization Software",
            //                //                HasMainContent=true,
            //                //                Details= new List<Detail>{
            //                //                   new Detail{
            //                //                       Type=ContentType.Paragraph,
            //                //                       Contents= new List<HTMLContent>{ new HTMLContent { Value= "The Virtualization category includes scripts for installing toolsets & software such as Docker / Podman which make it easier to consume / ship software by professionals." } }
            //                //                   },
            //                //                }
            //                //           },
            //                //            new Section {
            //                //                Id="docker",
            //                //                Header="1) Docker Desktop with WSL2 Backend",
            //                //                Details= new List<Detail>{
            //                //                   new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "This installs " },
            //                //                            new LinkContent{ Value="Docker Desktop", Href="https://www.docker.com/products/docker-desktop"},
            //                //                            new HTMLContent{ Value= " with the WSL2 backend through the chocolatey package manager. Historically very difficult to achieve but today its not even a few lines of code, what a time to be alive!" },
            //                //                        }
            //                //                   },
            //                //             }
            //                //           },
            //                //            new Section {
            //                //                Id="podman",
            //                //                Header="2) Podman",
            //                //                Details= new List<Detail>{
            //                //                   new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "Much like Docker, " },
            //                //                            new LinkContent{ Value="Podman", Href="https://podman.io/"},
            //                //                            new HTMLContent{ Value= " is a software for managing OCI Containers, this installation is provided as an alternative for the ones who prefer it instead of Docker." },
            //                //                        }
            //                //                   },
            //                //             }
            //                //           },
            //                //           new Section {
            //                //                Id="sdk",
            //                //                Header="SDK & Internal Tooling",
            //                //                HasMainContent=true,
            //                //                Details= new List<Detail>{
            //                //                   new Detail{
            //                //                       Type=ContentType.Paragraph,
            //                //                       Contents= new List<HTMLContent>{ new HTMLContent { Value= "The scripts under this section are all about giving developers more power by making internal Sinda tools available. The tools function as encapsulation on certain tasks into one liners." } }
            //                //                   },
            //                //                }
            //                //           },
            //                //            new Section {
            //                //                Id="sindamodule",
            //                //                Header="1) Sinda Developer Tools",
            //                //                Details= new List<Detail>{
            //                //                   new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "This is a Powershell module & an exact copy of the internal scripts used with the CLI tool wrapped in an easily importable format." },
            //                //                            new HTMLContent{ Value= "the command imports the module located at src/script/Sindagal.psm1 into the powershell profile of the user using the machine" },
            //                //                            new HTMLContent{ Value= "Once the module is imported, the developer gains direct access to all the features included in the CLI & more through direct powershell commands!" },
            //                //                        }
            //                //                   },
            //                //                   new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "All the commands could be inspected in the file location mentioned within the CLI repository, however some of them are explained below." },
            //                //                        }
            //                //                   },
            //                //                new Detail{
            //                //                    Type=ContentType.Paragraph,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new HTMLContent{ Value= "To check the current state of your system for things such as os version, architecture, wsl2 support etc: "}
            //                //                    }
            //                //                },
            //                //                new Detail{
            //                //                    Type=ContentType.Code,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new CodeContent{ Language="shell", Value= "Get-EnvState" },
            //                //                    }
            //                //                },
            //                //                new Detail{
            //                //                    Type=ContentType.Paragraph,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new HTMLContent{ Value= "To install WSL on legacy systems where WSL2 or wsl --install command are not supported "}
            //                //                    }
            //                //                },
            //                //                new Detail{
            //                //                    Type=ContentType.Code,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new CodeContent{ Language="shell", Value= "Enable-WSLLegacy" },
            //                //                    }
            //                //                },
            //                //                new Detail{
            //                //                    Type=ContentType.Paragraph,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new HTMLContent{ Value= "To download & import the Sinda pre configured wsl2 instance:"}
            //                //                    }
            //                //                },
            //                //                new Detail{
            //                //                    Type=ContentType.Code,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new CodeContent{ Language="shell", Value= "Add-SindaDistro" },
            //                //                    }
            //                //                },
            //                //                new Detail{
            //                //                    Type=ContentType.Paragraph,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new HTMLContent{ Value= "Check if terminal session has admin rights:"}
            //                //                    }
            //                //                },
            //                //                new Detail{
            //                //                    Type=ContentType.Code,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new CodeContent{ Language="shell", Value= "Test-Elevation" },
            //                //                    }
            //                //                },
            //                //                new Detail{
            //                //                    Type=ContentType.Paragraph,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new HTMLContent{ Value= "Install & Configure Windows Terminal with Nerd Fonts:"}
            //                //                    }
            //                //                },
            //                //                new Detail{
            //                //                    Type=ContentType.Code,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new CodeContent{ Language="shell", Value= "Enable-WindowsTerminal" },
            //                //                    }
            //                //                },
            //                //                new Detail{
            //                //                    Type=ContentType.Paragraph,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new HTMLContent{ Value= "Disable & delete Windows Terminal:"}
            //                //                    }
            //                //                },
            //                //                new Detail{
            //                //                    Type=ContentType.Code,
            //                //                    Contents= new List<HTMLContent>{
            //                //                        new CodeContent{ Language="shell", Value= "Disable-WindowsTerminal" },
            //                //                    }
            //                //                },
            //                //                new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "And many more!" },
            //                //                        }
            //                //                   },
            //                //             }
            //                //           },
            //                //           new Section {
            //                //                Id="boilerplate",
            //                //                Header="Boilerplates & Codebases",
            //                //                HasMainContent=true,
            //                //                Details= new List<Detail>{
            //                //                   new Detail{
            //                //                       Type=ContentType.Paragraph,
            //                //                       Contents= new List<HTMLContent>{ new HTMLContent { Value= "The Boilerplate section contains scripts which clone Ready to go Sinda Codebases from github. The repositories are intended to solve common problems & be as easily personalized as possible." } }
            //                //                   }
            //                //                }
            //                //           },
            //                //            new Section {
            //                //                Id="portfolio",
            //                //                Header="1) Sinda Portfolio",
            //                //                Details= new List<Detail>{
            //                //                   new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "This clones a reusable & extensible web portfolio template written with React using the NextJS framework. The repository could be found " },
            //                //                            new LinkContent{ Value="here.", Href="https://github.com/denzii/sinda-portfolio"},
            //                //                            new HTMLContent{ Value= "This simplistic portfolio itself has basic SEO optimizations, keyboard and developer accessibility; a performant " },
            //                //                            new LinkContent{ Value="Chrome Lighthouse", Href="https://developers.google.com/web/tools/lighthouse"},
            //                //                            new HTMLContent{ Value= " score as well as good responsive UI/UX principles!" },
            //                //                            new HTMLContent{ Value= " Feel free to change the data & reupload it to your favourite version-control website as you please!" },
            //                //                        }
            //                //                   },
            //                //                   new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "For more information regarding this template & web theme, please refer to the Boilerplate tab on this page." },
            //                //                        }
            //                //                   },
            //                //             }
            //                //           },
            //                //        }
            //                //    },
            //                //    new PageTab{
            //                //        Name="Boilerplate",
            //                //        Status=SectionStatus.Public,
            //                //        Sections = new List<Section> {
            //                //            new Section {
            //                //                Id="Introduction",
            //                //                Header="Introduction",
            //                //                HasMainContent= true,
            //                //                Details= new List<Detail>{
            //                //                   new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "Do you have some boilerplate code which you always have to write from scratch? Are you in a hurry to get up and running with an MVP?" },
            //                //                            new HTMLContent{ Value= " Sindagal Boilerplates will come to your rescue!" },
            //                //                            new HTMLContent{ Value= " On this page, we will be exploring how to set up and work with existing code as well as how to extend them to our needs to save time from cumbersome work!" } }
            //                //                   },
            //                //                }
            //                //            },
            //                //            new Section {
            //                //                Id="portfolio",
            //                //                Header="1) Sinda Portfolio",
            //                //                Details= new List<Detail>{
            //                //                   new Detail{
            //                //                       Type=ContentType.Paragraph,
            //                //                       Contents= new List<HTMLContent>{
            //                //                           new HTMLContent{ Value= "Planning to look for that next challange in your career but do not have time to fiddle with UI/UX or write the code for a portfolio website from scratch?" },
            //                //                           new HTMLContent{ Value= " You can now rest easy with this " },
            //                //                           new LinkContent{ Value="web portfolio.", Href="https://github.com/denzii/sinda-portfolio"},
            //                //                           new HTMLContent{ Value= " This template simplistic enough to do the job and will hit the spot with its SEO optimizations, keyboard and developer accessibility; a performant " },
            //                //                           new LinkContent{ Value="Lighthouse", Href="https://developers.google.com/web/tools/lighthouse"},
            //                //                           new HTMLContent{ Value= " score as well as good responsive UI/UX principles!" },
            //                //                           new HTMLContent{ Value= " please find a live example at" },
            //                //                           new LinkContent{ Value="denizarca.com", Href="https://denizarca.com"} },
            //                //                   }
            //                //                }
            //                //            },
            //                //            new Section {
            //                //                Id="portfolioSetup",
            //                //                Header="Setting up the repository",
            //                //                Details= new List<Detail>{
            //                //                   new Detail{
            //                //                       Type=ContentType.Paragraph,
            //                //                       Contents= new List<HTMLContent>{
            //                //                           new HTMLContent{ Value= "This is a NextJS TypeScript project so NodeJS & npm are required as a prerequisite." },
            //                //                           new HTMLContent{ Value= "If those already exist on the machine or if you are using the pre configured WSL instance, its okay to proceed to cloning the repository." },
            //                //                           },

            //                //                   },
            //                //                   new Detail{
            //                //                        Type=ContentType.Code,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new CodeContent{ Language="shell", Value= "git clone https://github.com/denzii/sinda-portfolio.git" },
            //                //                        }
            //                //                    },
            //                //                    new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                           new HTMLContent{ Value= "Install Nextjs globally:" },
            //                //                        },
            //                //                    },
            //                //                    new Detail{
            //                //                        Type=ContentType.Code,
            //                //                        Contents= new List<HTMLContent>{
            //                //                           new CodeContent{ Language="shell", Value= "npm i -g next" },
            //                //                        }
            //                //                    },
            //                //                    new Detail{
            //                //                           Type=ContentType.Paragraph,
            //                //                           Contents= new List<HTMLContent>{
            //                //                               new HTMLContent{ Value= "Move into the repository, install dependencies and run the app:" },
            //                //                           },

            //                //                       },
            //                //                    new Detail{
            //                //                        Type=ContentType.Code,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new CodeContent{ Language="shell", Value= "cd sinda-portfolio" },
            //                //                        }
            //                //                    },
            //                //                    new Detail{
            //                //                        Type=ContentType.Code,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new CodeContent{ Language="shell", Value= "npm install" },
            //                //                        }
            //                //                    },
            //                //                    new Detail{
            //                //                        Type=ContentType.Code,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new CodeContent{ Language="shell", Value= "npm run dev" },
            //                //                        }
            //                //                    },

            //                //                    new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "If everything went well, it's now okay to visit localhost:3000 in your favourite browser to see the site!" },
            //                //                        },
            //                //                    },
            //                //                    new Detail{
            //                //                        Type=ContentType.Picture,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new PictureSourceContent{ Srcset="./img/portfolio-landing-page-850w.png", Media="(max-width: 950px)"},
            //                //                            new PictureSourceContent{ Srcset="./img/portfolio-landing-page.png"},
            //                //                            new ImageContent{ Src="./img/portfolio-landing-page.png", Alt="Portfolio Landing Page"}
            //                //                        }
            //                //                    },


            //                //                }

            //                //            },
            //                //            new Section {
            //                //                Id="portfolioHero",
            //                //                Header="Changing the hero section content",
            //                //                Details= new List<Detail>{
            //                //                    new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "Not bad! In order to personalize it, we need to make a few tweaks." },
            //                //                            new HTMLContent{ Value= " The data is pulled into a single class at " },
            //                //                            new LinkContent{ Value="data/index.ts", Href="https://github.com/denzii/sinda-portfolio/blob/main/data/index.ts"},
            //                //                            new HTMLContent{ Value= " class for the most part and this is where we will spend most of our time." },
            //                //                            new HTMLContent{ Value= " having said that, the page title and the meta tags for SEO as well as canonical must also be changed for a fully personalized portfolio. In a NextJS project, these are stored in " },
            //                //                            new LinkContent{ Value="pages/_document.tsx", Href="https://github.com/denzii/sinda-portfolio/blob/main/pages/_document.tsx"},
            //                //                            new HTMLContent{ Value= " as per convention. It is planned to pull these into the data folder in the future as well!" },
            //                //                        },
            //                //                    },
            //                //                    new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "Let's view the code in our favourite code editor and see how to go about the modifications!" },
            //                //                        },
            //                //                    },
            //                //                    new Detail{
            //                //                        Type=ContentType.Code,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new CodeContent{ Language="shell", Value= "code ." },
            //                //                        }
            //                //                    },
            //                //                    new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "To start things off, lets change the navigation bar contents by changing the ProjectOwner, PersonalURLs & PersonalBackground Objects as shown." },
            //                //                        },
            //                //                    },
            //                //                    new Detail{
            //                //                        Type=ContentType.Picture,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new PictureSourceContent{ Srcset="./img/portfolio-navbar-name-diff-850w.png", Media="(max-width: 950px)"},
            //                //                            new PictureSourceContent{ Srcset="./img/portfolio-navbar-name-diff.png",},
            //                //                            new ImageContent{ Src="./img/portfolio-navbar-name-diff.png", Alt="Portfolio Navbar modification"}
            //                //                        }
            //                //                    },
            //                //                    new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= " Icons for social media could be changed by supplying a name from the " },
            //                //                            new LinkContent{ Value="React Font Awesome", Href="https://react-icons.github.io/react-icons/icons?name=fa"},
            //                //                            new HTMLContent{ Value= " Icons. Additional navigation links such as \"instagram\" could also be added or removed if desired by altering the keys on the" },
            //                //                            new LinkContent{ Value="interface/personalUrls.ts", Href="https://github.com/denzii/sinda-portfolio/blob/main/interface/personalUrls.ts"},
            //                //                            new HTMLContent{ Value= " class further. For demonstration purposes, lets remove the email icon while changing the other two icons." },
            //                //                        },
            //                //                    },
            //                //                    new Detail{
            //                //                        Type=ContentType.Picture,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new PictureSourceContent{ Srcset="./img/portfolio-socialbar-diff-850w.png", Media="(max-width: 950px)"},
            //                //                            new PictureSourceContent{ Srcset="./img/portfolio-socialbar-diff.png",},
            //                //                            new ImageContent{ Src="./img/portfolio-socialbar-diff.png", Alt="Portfolio Socialbar modification"}
            //                //                        }
            //                //                    },
            //                //                    new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= " The keys on the object " },
            //                //                            new LinkContent{ Value="interface/background.ts", Href="https://github.com/denzii/sinda-portfolio/blob/main/interface/background.ts"},
            //                //                            new HTMLContent{ Value= " are used to generate the sections below the hero section. If we wanted to add or remove or alter a section, all we would need to do is to alter the keys on it!" },
            //                //                            new HTMLContent{ Value= " for the sake of this tutorial, let's remove the hobbies section and rename some of the others!" },
            //                //                        },
            //                //                    },
            //                //                    new Detail{
            //                //                        Type=ContentType.Picture,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new PictureSourceContent{ Srcset="./img/portfolio-navbar-elems-diff-850w.png", Media="(max-width: 950px)"},
            //                //                            new PictureSourceContent{ Srcset="./img/portfolio-navbar-elems-diff.png",},
            //                //                            new ImageContent{ Src="./img/portfolio-navbar-elems-diff.png", Alt="Portfolio Navbar elements modification" }
            //                //                        }
            //                //                    },
            //                //                    new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= " Now that those are out of the way, its a good time to change the background and the headshot images which are located inside the " },
            //                //                            new LinkContent{ Value="public", Href="https://github.com/denzii/sinda-portfolio/tree/main/public"},
            //                //                            new HTMLContent{ Value= " directory, all that is required is to drop in the images in that directory and reference them inside the data class. The app is written flexible enough to allow the usage of different image names as-well!" },
            //                //                        },
            //                //                    },
            //                //                    new Detail{
            //                //                        Type=ContentType.Picture,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new PictureSourceContent{ Srcset="./img/portfolio-hero-diff.png",},
            //                //                            new ImageContent{ Src="./img/portfolio-hero-diff.png", Alt="Portfolio hero images modification" }
            //                //                        }
            //                //                    },

            //                //                }
            //                //            },
            //                //            new Section {
            //                //                Id="portfolioBody",
            //                //                Header="Changing the body section contents",
            //                //                Details= new List<Detail>{
            //                //                    new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "We've come a long way and the results are just beautiful! Refresh the browser page to see that the website now looks like this: " },
            //                //                        },
            //                //                    },
            //                //                    new Detail{
            //                //                        Type=ContentType.Picture,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new PictureSourceContent{ Srcset="./img/portfolio-altered-hero-diff-850w.png", Media="(max-width: 950px)"},
            //                //                            new PictureSourceContent{ Srcset="./img/portfolio-altered-hero-diff.png",},
            //                //                            new ImageContent{ Src="./img/portfolio-altered-hero-diff.png", Alt="Portfolio altered hero section" }
            //                //                        }
            //                //                    },
            //                //                    new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "How about the body sections? Are they even flexible enough for personalization? They sure are! All that needs to be done is to alter the methods which are being called within the \"PersonalBackground\" method inside the data class." },
            //                //                            new HTMLContent{ Value= " The heading, date range & inner content are supplied within the same place, the inner content could be made bold, italic or emphasized on demand without touching any HTML." },

            //                //                        },
            //                //                    },
            //                //                    new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= " If it's a semantic markup for your website which you are looking for; you can add emphasis and other things to certain text but also keep it unstyled." },
            //                //                            new HTMLContent{ Value= " This is a good idea if you would like your website to read well by screen readers so elements could be emphesized without changing the visual feeling..." },
            //                //                            new HTMLContent{ Value= " The body elements could be given captions aswell by assigning the \"caption\" field a string value." },
            //                //                        },
            //                //                    },
            //                //                   new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "Example body section element code:" },
            //                //                        },
            //                //                    },
            //                //                   new Detail{
            //                //                        Type=ContentType.Picture,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new PictureSourceContent{ Srcset="./img/portfolio-body-code.png", Media="(max-width: 950px)"},
            //                //                            new ImageContent{ Src="./img/portfolio-body-code.png", Alt="Portfolio body code example" }
            //                //                        }
            //                //                    },
            //                //                    new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "Only one thing remains, changing the meta content of the site! And this is as easy as going into the pages/_document.tsx" },
            //                //                            new LinkContent{ Value="pages/_document.tsx", Href="https://github.com/denzii/sinda-portfolio/tree/main/public"},
            //                //                            new HTMLContent{ Value= " file and altering the given strings." },
            //                //                            new HTMLContent{ Value= " add in the full address of your domain as a canonical, change the tab title as you wish and amend the keywords to cater to your target audiences google searches." },
            //                //                        },
            //                //                    },
            //                //                    new Detail{
            //                //                        Type=ContentType.Paragraph,
            //                //                        Contents= new List<HTMLContent>{
            //                //                            new HTMLContent{ Value= "That is all! Enjoy your Sinda Portfolio and do not forget to give a star or send your pull requests!" },
            //                //                            new HTMLContent{ Value= " We will not be touching on how to deploy this website since it is using the stock CI/CD which is provided by Vercel for free on personal projects." },
            //                //                            new HTMLContent{ Value= " To find out more about deployments, visit their tutorials at " },
            //                //                            new LinkContent{ Value="nextjs.org/deployment", Href="https://nextjs.org/docs/deployment"},
            //                //                        },
            //                //                    },
            //                //                }
            //                //            },
            //                //        }
            //                //    },
            //                //}
            //            },
            //            new Page
            //            {
            //                Name = "Blog",
            //                //Tabs = new List<PageTab> {
            //                //    new PageTab{ Name="Articles", Status=SectionStatus.Hidden },
            //                //    new PageTab{ Name="News", Status=SectionStatus.Hidden },
            //                //}
            //            },
            //            new Page
            //            {
            //                Name = "Roadmap",
            //                //Tabs = new List<PageTab> {
            //                //    new PageTab{ Name = "Philosophy", Status = SectionStatus.Hidden },
            //                //    new PageTab{ Name = "Vision", Status = SectionStatus.Hidden }
            //                //}
            //            }
            //       );
            //        #endregion

        }
    }
}
