using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SindaCMS.Models;

namespace SindaCMS.Controllers;

public class DocsController : Controller
{
    private readonly ILogger<DocsController> _logger;
    private readonly BaseProps _props;
    public DocsController(ILogger<DocsController> logger)
    {
        _logger = logger;
        _props = new BaseProps();
    }

    public IActionResult Index()
    {
        // move data to DB, run query and get it before rendering view
        return View("../PageTabs", new PageProps(_props) {
            Name = "Docs",
            Tabs = new List<PageTab> {
                new PageTab{
                    Name="Terminal",
                    Status=SectionStatus.Complete,
                    Sections = new List<Section> {
                        new Section {
                            Id="introduction",
                            Header="Introduction",
                            HasMainContent=true,
                            Details= new List<Detail>{
                               new Detail{
                                    Contents= new List<HTMLContent>{
                                        new HTMLContent{ Value= "Sindagal " },
                                        new LinkContent{ Value= "Command Line Interface", Href="https://github.com/denzii/sinda-cli" },
                                        new HTMLContent{ Value= " is a simple Node.js application which makes use of the popular JavaScript framework React. The goal is to make developer lives more convenient by wrapping around operating system level scripts and allowing their easy consumption." }
                                    }
                               },
                               new Detail{
                                   Contents= new List<HTMLContent>{ new WarningContent{ Value= "For the time being, usages from within WSL & Unix based systems had been disabled." } }
                               },
                               new Detail{
                                   Contents= new List<HTMLContent>{ new HTMLContent { Value= "On this page, you'll learn what the Sinda Command Line Interface brings to the table and how it can be consumed by setting it up from scratch and consuming some of the built in automation scripts on a Windows machine." } }
                               }
                            }
                        },
                        new Section{
                          Id="setup",
                          Header="Getting Started",
                          HasMainContent=false,
                          Details= new List<Detail>{
                            new Detail{
                                Type=ContentType.Paragraph,
                                Contents= new List<HTMLContent>{
                                    new HTMLContent{ Value= "The project requires Node.js LTS and npm to be installed as a pre-requisite so if you do not already have them, now is a good time to set them up." },
                                    new LinkContent{ Value="This tutorial", Href="https://docs.microsoft.com/en-us/windows/dev-environment/javascript/nodejs-on-windows"},
                                    new HTMLContent{ Value= "by Microsoft demonstrates how they could be set on a Windows machine using the Node Version Manager tool (NVM)."}
                                }
                            },
                            new Detail{
                                Type=ContentType.Paragraph,
                                Contents= new List<HTMLContent>{
                                    new HTMLContent{ Value="Once NVM & Node.js are configured, we could proceed to cloning the repository and running the app from the cloned source code. Its necessary to fork and/or clone the repository since the app itself requires access to the localhost machine so it can run powershell/bash scripts."}
                                }
                            },
                            new Detail{
                                Type=ContentType.Code,
                                Contents= new List<HTMLContent>{
                                    new CodeContent{Language="shell", Value="git clone https://github.com/denzii/sinda-cli.git"}
                                }
                            },
                            new Detail{
                                Type=ContentType.Code,
                                Contents= new List<HTMLContent>{
                                    new CodeContent{Language="shell", Value="cd sinda-cli"}
                                }
                            },
                            new Detail{
                                Type=ContentType.Code,
                                Contents= new List<HTMLContent>{
                                    new CodeContent{Language="shell", Value="npm start"}
                                }
                            },
                            new Detail{
                                Type=ContentType.Warning,
                                Contents= new List<HTMLContent>{ new HTMLContent{ Value= "The app requires administrator rights to run Powershell / Bash scripts on localhost, if its run from a non-elevated terminal session, it will result in an error and not run." } }
                            },
                            new Detail{
                                Type=ContentType.Paragraph,
                                Contents= new List<HTMLContent>{
                                    new HTMLContent{Value="The following image demonstrates the landing page for a successfully started CLI."}
                                }
                            },
                            new Detail{
                                Type=ContentType.Picture,
                                Contents= new List<HTMLContent>{
                                    new PictureSourceContent{ Srcset="./img/cli-landing-page-850w.png", Media="(max-width: 950px)"},
                                    new PictureSourceContent{ Srcset="./img/cli-landing-page.png"},
                                    new ImageContent{ Src="./img/cli-landing-page.png", Alt="CLI Landing Page"}
                                }
                            },

                         }
                       },
                       new Section {
                            Id="usage",
                            Header="Usage",
                            HasMainContent=false,
                            Details= new List<Detail>{
                               new Detail{
                                    Type=ContentType.Paragraph,
                                    Contents= new List<HTMLContent>{
                                        new HTMLContent{ Value= "Consuming scripts from the app is pretty straight forward and takes only a few key-presses to achieve. As seen on the landing page image, the terminal prompt functions similarly to a single page app and the visible part of the terminal is hijacked by a" },
                                        new LinkContent{ Value="React Ink", Href="https://github.com/vadimdemedes/ink"},
                                        new HTMLContent{ Value= "Component" },
                                    }

                               },
                               new Detail{
                                   Type=ContentType.Paragraph,
                                   Contents= new List<HTMLContent>{ new HTMLContent{ Value= "The component itself detects the screen height and width and resizes accordingly. Having said that, a maximized terminal window is recommended for the best experience and the resizing  feature is only meant for the application startup. If the terminal window gets resized while the app is running, there are no guarantees for correct rendering of the component." } }
                               },
                               new Detail{
                                   Type=ContentType.Paragraph,
                                   Contents= new List<HTMLContent>{ new HTMLContent{ Value= "Once a key is pressed on the landing page, the survey component is rendered and the user is presented with all the available automation scripts... Navigation of the form is achieved through the <i>Up / Down / Enter & Esc </i> keys. This component is demonstrated in the following image." } }
                               },
                               new Detail{
                                Type=ContentType.Picture,
                                Contents= new List<HTMLContent>{
                                    new PictureSourceContent{ Srcset="./img/cli-survey-page-850w.png", Media="(max-width: 950px)"},
                                    new PictureSourceContent{ Srcset="./img/cli-survey-page.png"},
                                    new ImageContent{ Src="./img/cli-survey-page.png", Alt="CLI Survey Page"}
                                }
                              },
                              new Detail{
                                   Type=ContentType.Paragraph,
                                   Contents= new List<HTMLContent>{ new HTMLContent{  Value= "For the sake of this tutorial, we are only going to be selecting the first three options. Once the selections are made, it is required to navigate to the last page of the survey and confirm the selections.  The \"proceed\" button will ask for a re-confirmation and esc key could be used to go back to the form."},  }
                              },
                              new Detail{
                                Type=ContentType.Picture,
                                Contents= new List<HTMLContent>{
                                    new PictureSourceContent{ Srcset="./img/cli-survey-page-confirmation-850w.png", Media="(max-width: 950px)"},
                                    new PictureSourceContent{ Srcset="./img/cli-survey-page-confirmation.png"},
                                    new ImageContent{ Src="./img/cli-survey-page-confirmation.png", Alt="CLI Survey Page Confirmation"}
                                }
                              },
                              new Detail{
                                   Type=ContentType.Paragraph,
                                   Contents= new List<HTMLContent>{ new HTMLContent{ Value= "Prior to making any changes to the machine, all the selected features and their corresponding scripts are listed and a confirmation is requested once more for extra safety."} }
                              },
                              new Detail{
                                Type=ContentType.Picture,
                                Contents= new List<HTMLContent>{
                                    new PictureSourceContent{ Srcset="./img/cli-survey-page-confirmation-2-850w.png", Media="(max-width: 950px)"},
                                    new PictureSourceContent{ Srcset="./img/cli-survey-page-confirmation-2.png"},
                                    new ImageContent{ Src="./img/cli-survey-page-confirmation-2.png", Alt="CLI Survey Page Finalization"}
                                }
                              },
                              new Detail{
                                Type=ContentType.Warning,
                                Contents= new List<HTMLContent>{ new HTMLContent{ Value= "For the time being, the scripts are executed syncronously and the results within the box are updated all at once." } }
                              },
                              new Detail{
                                   Type=ContentType.Paragraph,
                                   Contents= new List<HTMLContent>{ new HTMLContent{ Value= "The Standard Outputs as well as Errors for the executed commands are pushed above the component box in real-time. A finished session is demonstrated in the below image."} }
                              },
                              new Detail{
                                Type=ContentType.Picture,
                                Contents= new List<HTMLContent>{
                                    new PictureSourceContent{ Srcset="./img/cli-survey-page-results-850w.png", Media="(max-width: 950px)"},
                                    new PictureSourceContent{ Srcset="./img/cli-survey-page-results.png"},
                                    new ImageContent{ Src="./img/cli-survey-page-results.png", Alt="CLI Survey Page Results"}
                                }
                              },
                              new Detail{
                                   Type=ContentType.Paragraph,
                                   Contents= new List<HTMLContent>{ new HTMLContent{ Value= "Thats all folks! See how easy it was to consume some powershell scripts? To see the full list of the existing scripts, please navigate to the scripts tab on this page."} }
                              },
                         }
                       }
                    }
                    },
                new PageTab{
                    Name="Scripts",
                    Status=SectionStatus.Complete,
                    Sections = new List<Section> {
                        new Section {
                            Id="Introduction",
                            Header="Introduction",
                            HasMainContent= true,
                            Details= new List<Detail>{
                               new Detail{
                                    Type=ContentType.Paragraph,
                                    Contents= new List<HTMLContent>{
                                        new HTMLContent{ Value= "As described in the Terminal tab, Sindagal comes with some built-in scripts and can also be extended to interface to personal scripts. The scripts are categorized as Terminal, Shell, Virtual, SDK & Boilerplate." },
                                        new HTMLContent{ Value= " The CLI tool works by executing powershell / bash scripts which exist inside the code repository itself under the src/scripts directory." } }
                               },
                               new Detail { 
                                    Type=ContentType.Paragraph,
                                    Contents=new List<HTMLContent>{
                                        new HTMLContent{ Value=" On this page, we will be exploring the various details regarding those features and why they might come in handy for you or your organisation."}
                                    }
                               },
                               new Detail{
                                   Type=ContentType.Warning,
                                   Contents= new List<HTMLContent>{
                                       new HTMLContent{ Value= "For the time being, everything is in the Minimum Viable Product stage & things might change in the future. Please report any problems or bugs to me personally through my " },
                                       new LinkContent{ Value= "Linkedin.", Href="https://www.linkedin.com/in/denizarca/" },
                                       new HTMLContent{ Value= " Pull requests are welcome at the " },
                                       new LinkContent{ Value= "CLI repository.", Href="https://github.com/denzii/sinda-cli" },
                                   }
                               },
                            }
                        },
                        new Section {
                            Id="terminal",
                            HasMainContent= true,
                            Header="Terminal Extensions",
                            Details= new List<Detail>{
                               new Detail{
                                   Type=ContentType.Paragraph,
                                   Contents= new List<HTMLContent>{ new HTMLContent{ Value= "This category is where the scripts regarding the interactive terminal session reside. These will alter the look & feel of your interactions with your local shell." } }
                               }
                            }
                        },
                        new Section {
                            Id="ohmyposh",
                            Header="1) Oh My Posh & Nerd Fonts",
                            Details= new List<Detail>{
                               new Detail{
                                    Type=ContentType.Paragraph,
                                    Contents= new List<HTMLContent>{ 
                                       new HTMLContent{ Value= "By default, terminal prompts on Windows machines come with no support for user themes, lack descriptiveness and are not intuitive to use. Wouldn't it be nice if the sessions could be personalized & extended with additional information such as the time of command execution, git active branch names, battery level and more?" },
                                       new HTMLContent{ Value= " Enter " },
                                       new LinkContent{ Value= "Oh My Posh!", Href="https://ohmyposh.dev/" },
                                       new HTMLContent{ Value= " A shell framework for doing all of that! Historically this worked only on Windows but with Powershell going cross platform, it now works on Linux & Mac as well. " },
                                    }
                               },
                               new Detail{
                                   Type=ContentType.Paragraph,
                                   Contents= new List<HTMLContent>{ 
                                       new HTMLContent{ Value= "The framework is easily configurable... All available themes could be reviewed by: " },
                                   }
                               },
                               new Detail{
                                    Type=ContentType.Code,
                                    Contents= new List<HTMLContent>{
                                       new CodeContent{ Language="shell", Value= "$ Get-PoshThemes" },
                                    }
                               },
                               new Detail{
                                   Type=ContentType.Paragraph,
                                   Contents= new List<HTMLContent>{
                                       new HTMLContent{ Value= "changing the theme to \"Darkblood\": " },
                                   }
                               },
                               new Detail{
                                    Type=ContentType.Code,
                                    Contents= new List<HTMLContent>{
                                       new CodeContent{ Language="shell", Value= "$ Set-PoshPrompt darkblood" },
                                    }
                               },
                               new Detail{
                                   Type=ContentType.Paragraph,
                                   Contents= new List<HTMLContent>{
                                       new HTMLContent{ Value= "Having said that, it is also possible to configure it via code by adjusting an init script at a location which can be found from the Get-PoshThemes command. " },
                                   }
                               },
                               new Detail{
                                   Type=ContentType.Paragraph,
                                   Contents= new List<HTMLContent>{
                                       new HTMLContent { Value= "Oh My Posh relies on a specific font family in order to display its many glyphs properly, Sinda takes care of installing the " },
                                       new LinkContent { Value= "Nerd Fonts", Href="https://github.com/ryanoasis/nerd-fonts"},
                                       new HTMLContent { Value= " for you!" },
                                   }
                               }
                            }
                        },
                        new Section{
                          Id="winterm",
                          Header="2) Windows Terminal by Microsoft",
                          Details= new List<Detail>{
                            new Detail{
                                Type=ContentType.Paragraph,
                                Contents= new List<HTMLContent>{
                                    new HTMLContent{ Value= "The default Powershell / Command Prompt & WSL terminal apps are some-what primitive, those emulators damage productivity. They are difficult to impossible to standardize, they require switching between windows which can get tedious & confusing from time to time and they lack certain features when it comes to keyboard shortcuts." },
                                    new LinkContent{ Value= "Windows Terminal", Href="https://docs.microsoft.com/en-us/windows/terminal/" },
                                    new HTMLContent{ Value= " intends to remedy the above problems by allowing multiple tabs, split screens, extensive keyboard macros and multi-shell support."},
                                    new HTMLContent{ Value= " Tabs could contain any session ranging from Azure, WSL2, Remote SSH, Powershell & CMD!"},
                                    new HTMLContent{ Value= " This powerful open source tool also allows launching sessions programatically through powershell commands."}
                                }
                            },
                            new Detail{
                                Type=ContentType.Paragraph,
                                Contents= new List<HTMLContent>{
                                    new HTMLContent{ Value= "To start WSL Debian & Powershell sessions programatically: "}
                                }
                            },
                            new Detail{
                                Type=ContentType.Code,
                                Contents= new List<HTMLContent>{
                                    new CodeContent{ Language="shell", Value= "$ wt -p \"Debian\" `; split-pane -p \"Windows PowerShell\" `;" },
                                }
                            },
                            new Detail{
                                Type=ContentType.Paragraph,
                                Contents= new List<HTMLContent>{
                                    new HTMLContent{ Value= "Results in the following interactive sessions:"}
                                }
                            },
                            new Detail{
                                Type=ContentType.Picture,
                                Contents= new List<HTMLContent>{
                                    new PictureSourceContent{ Srcset="./img/winterm-850w.png", Media="(max-width: 950px)"},
                                    new PictureSourceContent{ Srcset="./img/winterm.png"},
                                    new ImageContent{ Src="./img/winterm", Alt="CLI Landing Page"}
                                }
                            },
                         }
                        },
                        new Section {
                            Id="poshgit",
                            Header="3) Posh Git",
                            Details= new List<Detail>{
                               new Detail{
                                    Type=ContentType.Paragraph,
                                    Contents= new List<HTMLContent>{
                                        new HTMLContent{ Value= "As always, the stock functionality with Windows is lacked and this time its with Git on Powershell & Command Prompt... " },
                                    }
                               },
                               new Detail{
                                    Type=ContentType.Paragraph,
                                    Contents= new List<HTMLContent>{
                                        new LinkContent{ Value="PoshGit", Href="https://github.com/dahlbyk/posh-git"},
                                        new HTMLContent{ Value= "a powershell module, once imported, allows auto completion for all git commands. This makes life easier as less typing is required to navigate daily tasks." },
                                   }
                               },
                            }
                       },
                        new Section {
                            Id="shell",
                            Header="Shell Modifications",
                            HasMainContent=true,
                            Details= new List<Detail>{
                               new Detail{
                                   Type=ContentType.Paragraph,
                                   Contents= new List<HTMLContent>{ new HTMLContent{ Value= "The Shell category harbours everything which will alter the installed shell(s) themselves such as changing default powershell versions or installing WSL on localhost etc." } }
                               },
                            }
                       },
                        new Section {
                            Id="wsl",
                            Header="1) SindaDistro",
                            Details= new List<Detail>{
                               new Detail{
                                    Type=ContentType.Paragraph,
                                    Contents= new List<HTMLContent>{
                                        new HTMLContent{ Value= "This is a pre configured WSL2 instance which had been exported and put online for easy consumption." },
                                        new HTMLContent{ Value= " The purpose of this is to encapsulate basic linux setup and provide a ready developer environment for common tasks." },
                                        new HTMLContent{ Value= " It comes with " },
                                        new LinkContent{ Value="Zsh", Href="https://www.zsh.org/"},
                                        new HTMLContent{ Value= " as well as " },
                                        new LinkContent{ Value="Oh My Zsh.", Href="https://ohmyz.sh/"},
                                        new HTMLContent{ Value= " Zsh is the default shell which OSX systems are shipped with and OhMyZsh is a framework for adding magic to it!" },
                                    }
                               },
                              new Detail{
                                Type=ContentType.Warning,
                                Contents= new List<HTMLContent>{ new HTMLContent{ Value= "The features & plugins are not limited to the ones demonstrated below!" } }
                              },
                               new Detail{
                                    Type=ContentType.Paragraph,
                                    Contents= new List<HTMLContent>{
                                        new HTMLContent{ Value= "Themes could be configured on Oh My Zsh and all the themes which exist for Oh My Posh also exist for Oh My Zsh if not more! all existing " },
                                        new LinkContent{ Value="Oh My Zsh Themes", Href="https://github.com/ohmyzsh/ohmyzsh/wiki/Themes"},
                                        new HTMLContent{ Value= "could be found in the given link! " },
                                        new HTMLContent{ Value= " The Sinda Ubuntu comes with the theme \"agnoster\" but this can easily be changed by amending the .zshrc file." },
                                    }
                               },
                               new Detail{
                                    Type=ContentType.Paragraph,
                                    Contents= new List<HTMLContent>{
                                        new HTMLContent{ Value= "First look on the .zshrc file:" },
                                    }
                               },
                               new Detail{
                                    Type=ContentType.Picture,
                                    Contents= new List<HTMLContent>{
                                        new PictureSourceContent{ Srcset="./img/zsh-rc.png" },
                                        new ImageContent{ Src="./img/zsh-rc.png", Alt="First look on .zshrc file"}
                                    }
                               },
                               new Detail{
                                    Type=ContentType.Paragraph,
                                    Contents= new List<HTMLContent>{
                                        new HTMLContent{ Value= "As shown in the image above, Oh My Zsh can be configured with many " },
                                        new LinkContent{ Value="plugins,", Href="https://github.com/ohmyzsh/ohmyzsh/wiki/Plugins"},
                                        new HTMLContent{ Value= " plugins which make life convenient! The Sinda Ubuntu comes with the git, debian, alias-finder, docker, command-not-found, thefuck & docker." },
                                        new HTMLContent{ Value= " These of course can be changed by editing the plugins array. Below are some images demonstrating the Zsh & Oh My Zsh features further!" },
                                    }
                               },
                               new Detail{
                                    Type=ContentType.Paragraph,
                                    Contents= new List<HTMLContent>{
                                        new HTMLContent{ Value= "Thefuck:" },
                                    }
                               },
                               new Detail{
                                    Type=ContentType.Picture,
                                    Contents= new List<HTMLContent>{
                                        new PictureSourceContent{ Srcset="./img/zsh-thefuck.png" },
                                        new ImageContent{ Src="./img/zsh-thefuck.png", Alt="Thefuck demo"}
                                    }
                               },
                               new Detail{
                                    Type=ContentType.Paragraph,
                                    Contents= new List<HTMLContent>{
                                        new HTMLContent{ Value= "Git branch display:" },
                                    }
                               },
                               new Detail{
                                    Type=ContentType.Picture,
                                    Contents= new List<HTMLContent>{
                                        new PictureSourceContent{ Srcset="./img/zsh-git-branch.png" },
                                        new ImageContent{ Src="./img/zsh-git-branch.png", Alt="git branch display demo"}
                                    }
                               },
                               new Detail{
                                    Type=ContentType.Paragraph,
                                    Contents= new List<HTMLContent>{
                                        new HTMLContent{ Value= "Auto complete & switch on tab key:" },
                                    }
                               },
                               new Detail{
                                    Type=ContentType.Picture,
                                    Contents= new List<HTMLContent>{
                                        new PictureSourceContent{ Srcset="./img/zsh-tab-switch.png" },
                                        new ImageContent{ Src="./img/zsh-tab-switch.png", Alt="auto complete  demo"}
                                    }
                               },
                               new Detail{
                                    Type=ContentType.Paragraph,
                                    Contents= new List<HTMLContent>{
                                        new HTMLContent{ Value= "Autocorrect:" },
                                    }
                               },
                               new Detail{
                                    Type=ContentType.Picture,
                                    Contents= new List<HTMLContent>{
                                        new PictureSourceContent{ Srcset="./img/zsh-autocorrect.png" },
                                        new ImageContent{ Src="./img/zsh-autocorrect.png", Alt="auto correction demo"}
                                    }
                               },
                               new Detail{
                                    Type=ContentType.Paragraph,
                                    Contents= new List<HTMLContent>{
                                        new HTMLContent{ Value= "Alias finder:" },
                                    }
                               },
                               new Detail{
                                    Type=ContentType.Picture,
                                    Contents= new List<HTMLContent>{
                                        new PictureSourceContent{ Srcset="./img/zsh-alias-finder.png" },
                                        new ImageContent{ Src="./img/zsh-alias-finder.png", Alt="alias finder demo"}
                                    }
                               },
                               new Detail{
                                    Type=ContentType.Paragraph,
                                    Contents= new List<HTMLContent>{
                                        new HTMLContent{ Value= "Command not found:" },
                                    }
                               },
                               new Detail{
                                    Type=ContentType.Picture,
                                    Contents= new List<HTMLContent>{
                                        new PictureSourceContent{ Srcset="./img/zsh-command-not-found.png" },
                                        new ImageContent{ Src="./img/zsh-command-not-found.png", Alt="command not found demo"}
                                    }
                               },
                            }
                       },
                        new Section {
                            Id="virtual",
                            Header="Virtualization Software",
                            HasMainContent=true,
                            Details= new List<Detail>{
                               new Detail{
                                   Type=ContentType.Paragraph,
                                   Contents= new List<HTMLContent>{ new HTMLContent { Value= "The Virtualization category includes scripts for installing toolsets & software such as Docker / Podman which make it easier to consume / ship software by professionals." } }
                               },
                            }
                       },
                        new Section {
                            Id="docker",
                            Header="1) Docker Desktop with WSL2 Backend",
                            Details= new List<Detail>{
                               new Detail{
                                    Type=ContentType.Paragraph,
                                    Contents= new List<HTMLContent>{
                                        new HTMLContent{ Value= "This installs " },
                                        new LinkContent{ Value="Docker Desktop", Href="https://www.docker.com/products/docker-desktop"},
                                        new HTMLContent{ Value= " with the WSL2 backend through the chocolatey package manager. Historically very difficult to achieve but today its not even a few lines of code, what a time to be alive!" },
                                    }
                               },
                         }
                       },
                        new Section {
                            Id="podman",
                            Header="2) Podman",
                            Details= new List<Detail>{
                               new Detail{
                                    Type=ContentType.Paragraph,
                                    Contents= new List<HTMLContent>{
                                        new HTMLContent{ Value= "Much like Docker, " },
                                        new LinkContent{ Value="Podman", Href="https://podman.io/"},
                                        new HTMLContent{ Value= " is a software for managing OCI Containers, provided as an alternative for the ones who prefer it instead of Docker." },
                                    }
                               },
                         }
                       },
                       new Section {
                            Id="sdk",
                            Header="SDK & Internal Tooling",
                            HasMainContent=true,
                            Details= new List<Detail>{
                               new Detail{
                                   Type=ContentType.Paragraph,
                                   Contents= new List<HTMLContent>{ new HTMLContent { Value= "The scripts under this section are all about giving developers more power by making internal Sinda tools available. The tools function as encapsulation on certain tasks into one liners." } }
                               },
                            }
                       },
                        new Section {
                            Id="sindamodule",
                            Header="1) Sinda Developer Tools",
                            Details= new List<Detail>{
                               new Detail{
                                    Type=ContentType.Paragraph,
                                    Contents= new List<HTMLContent>{
                                        new HTMLContent{ Value= "This is a Powershell module & an exact copy of the internal scripts used with the CLI tool wrapped in an easily importable format." },
                                        new HTMLContent{ Value= "the command imports the module located at src/script/Sindagal.psm1 into the powershell profile of the user using the machine" },
                                        new HTMLContent{ Value= "Once the module is imported, the developer gains direct access to all the features included in the CLI & more through direct powershell commands!" },
                                    }
                               },
                               new Detail{
                                    Type=ContentType.Paragraph,
                                    Contents= new List<HTMLContent>{
                                        new HTMLContent{ Value= "All the commands could be inspected in the file location mentioned within the CLI repository, however some of them are explained below." },
                                    }
                               },
                            new Detail{
                                Type=ContentType.Paragraph,
                                Contents= new List<HTMLContent>{
                                    new HTMLContent{ Value= "To check the current state of your system for things such as os version, architecture, wsl2 support etc: "}
                                }
                            },
                            new Detail{
                                Type=ContentType.Code,
                                Contents= new List<HTMLContent>{
                                    new CodeContent{ Language="shell", Value= "$ Get-EnvState" },
                                }
                            },
                            new Detail{
                                Type=ContentType.Paragraph,
                                Contents= new List<HTMLContent>{
                                    new HTMLContent{ Value= "To install WSL on legacy systems where WSL2 or wsl --install command are not supported "}
                                }
                            },
                            new Detail{
                                Type=ContentType.Code,
                                Contents= new List<HTMLContent>{
                                    new CodeContent{ Language="shell", Value= "$ Enable-WSLLegacy" },
                                }
                            },
                            new Detail{
                                Type=ContentType.Paragraph,
                                Contents= new List<HTMLContent>{
                                    new HTMLContent{ Value= "To download & import the Sinda Distro:"}
                                }
                            },
                            new Detail{
                                Type=ContentType.Code,
                                Contents= new List<HTMLContent>{
                                    new CodeContent{ Language="shell", Value= "$ Add-SindaDistro" },
                                }
                            },
                            new Detail{
                                Type=ContentType.Paragraph,
                                Contents= new List<HTMLContent>{
                                    new HTMLContent{ Value= "Check if terminal session has admin rights:"}
                                }
                            },
                            new Detail{
                                Type=ContentType.Code,
                                Contents= new List<HTMLContent>{
                                    new CodeContent{ Language="shell", Value= "$ Test-Elevation" },
                                }
                            },
                            new Detail{
                                Type=ContentType.Paragraph,
                                Contents= new List<HTMLContent>{
                                    new HTMLContent{ Value= "Install & Configure Windows Terminal with Nerd Fonts:"}
                                }
                            },
                            new Detail{
                                Type=ContentType.Code,
                                Contents= new List<HTMLContent>{
                                    new CodeContent{ Language="shell", Value= "$ Enable-WindowsTerminal" },
                                }
                            },
                            new Detail{
                                Type=ContentType.Paragraph,
                                Contents= new List<HTMLContent>{
                                    new HTMLContent{ Value= "Disable & delete Windows Terminal:"}
                                }
                            },
                            new Detail{
                                Type=ContentType.Code,
                                Contents= new List<HTMLContent>{
                                    new CodeContent{ Language="shell", Value= "$ Disable-WindowsTerminal" },
                                }
                            },
                            new Detail{
                                    Type=ContentType.Paragraph,
                                    Contents= new List<HTMLContent>{
                                        new HTMLContent{ Value= "And many more to come!" },
                                    }
                               },
                         }
                       },
                       new Section {
                            Id="boilerplate",
                            Header="Boilerplates & Codebases",
                            HasMainContent=true,
                            Details= new List<Detail>{
                               new Detail{
                                   Type=ContentType.Paragraph,
                                   Contents= new List<HTMLContent>{ new HTMLContent { Value= "The Boilerplate section contains scripts which clone Ready to go Sinda Codebases from github. The repositories are intended to solve common problems & be as easily personalized as possible." } }
                               }
                            }
                       },
                        new Section {
                            Id="portfolio",
                            Header="1) Sinda Portfolio",
                            Details= new List<Detail>{
                               new Detail{
                                    Type=ContentType.Paragraph,
                                    Contents= new List<HTMLContent>{
                                        new HTMLContent{ Value= "This clones a reusable & extensible web portfolio template written with React using the NextJS framework. The repository could be found " },
                                        new LinkContent{ Value="here.", Href="https://github.com/denzii/sinda-portfolio"},
                                        new HTMLContent{ Value= "This simplistic portfolio itself has basic SEO optimizations, keyboard and developer accessibility; a performant " },
                                        new LinkContent{ Value="Chrome Lighthouse", Href="https://developers.google.com/web/tools/lighthouse"},
                                        new HTMLContent{ Value= " score as well as good UI/UX principles!" },
                                        new HTMLContent{ Value= " Feel free to change the data & reupload it to your favourite version-control website as you please!" },
                                    }
                               },
                               new Detail{
                                    Type=ContentType.Paragraph,
                                    Contents= new List<HTMLContent>{
                                        new HTMLContent{ Value= "For more information regarding this template & web theme, please refer to the Boilerplate tab on this page." },
                                    }
                               },
                         }
                       },
                    }
                },
                new PageTab{
                    Name="Boilerplate",
                    Status=SectionStatus.Complete,
                    Sections = new List<Section> {
                        new Section {
                            Id="Introduction",
                            Header="Introduction",
                            HasMainContent= true,
                            Details= new List<Detail>{
                               new Detail{
                                    Type=ContentType.Paragraph,
                                    Contents= new List<HTMLContent>{
                                        new HTMLContent{ Value= "As described in the Terminal tab, Sindagal comes with some built-in scripts and can also be extended to interface to personal scripts. The scripts are categorized as Terminal, Shell, Virtual, SDK & Boilerplate." },
                                        new HTMLContent{ Value= " The CLI tool works by executing powershell / bash scripts which exist inside the code repository itself under the src/scripts directory." } }
                               },
                               new Detail {
                                    Type=ContentType.Paragraph,
                                    Contents=new List<HTMLContent>{
                                        new HTMLContent{ Value=" On this page, we will be exploring the various details regarding those features and why they might come in handy for you or your organisation."}
                                    }
                               },
                               new Detail{
                                   Type=ContentType.Warning,
                                   Contents= new List<HTMLContent>{
                                       new HTMLContent{ Value= "For the time being, everything is in the Minimum Viable Product stage & things might change in the future. Please report any problems or bugs to me personally through my " },
                                       new LinkContent{ Value= "Linkedin.", Href="https://www.linkedin.com/in/denizarca/" },
                                       new HTMLContent{ Value= " Pull requests are welcome at the " },
                                       new LinkContent{ Value= "CLI repository.", Href="https://github.com/denzii/sinda-cli" },
                                   }
                               },
                            }
                        },
                        new Section {
                            Id="terminal",
                            HasMainContent= true,
                            Header="Terminal Extensions",
                            Details= new List<Detail>{
                               new Detail{
                                   Type=ContentType.Paragraph,
                                   Contents= new List<HTMLContent>{ new HTMLContent{ Value= "This category is where the scripts regarding the interactive terminal session reside. These will alter the look & feel of your interactions with your local shell." } }
                               }
                            }
                        },
                    }
                },
            }
        });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
