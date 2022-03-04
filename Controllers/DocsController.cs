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
        return View("../Shared/_Content", new PageProps(_props) {
            Name = "Docs",
            Tabs = new List<PageTab> {
                new PageTab{
                    Name="Terminal",
                    Status=SectionStatus.Complete,
                    Sections = new List<Section> {
                        new Section {
                            Id="introduction",
                            Header="Introduction",
                            Details= new List<Detail>{
                               new Detail{
                                    Type=ContentType.Paragraph,
                                    Contents= new List<HTMLContent>{ new HTMLContent{ Value= "Sindagal Command Line Interface is a simple Node.js application which makes use of the popular JavaScript framework React. The goal is to make developer lives more convenient by wrapping around operating system level scripts and allowing their easy consumption." } }
                               },
                               new Detail{
                                   Type=ContentType.Warning,
                                   Contents= new List<HTMLContent>{ new HTMLContent{ Value= "For the time being, usages from within WSL & Unix based systems had been disabled." } }
                               },
                               new Detail{
                                   Type=ContentType.Paragraph,
                                   Contents= new List<HTMLContent>{ new HTMLContent { Value= "On this page, you'll learn what the Sinda Command Line Interface brings to the table and how it can be consumed by setting it up from scratch and consuming some of the built in automation scripts on a Windows machine." } }
                               }
                            }
                        },
                        new Section{
                          Id="setup",
                          Header="Getting Started",
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
                    Status=SectionStatus.Complete
                },
                new PageTab{
                    Name="Boilerplate",
                    Status=SectionStatus.Incomplete
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
