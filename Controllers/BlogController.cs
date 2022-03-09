using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SindaCMS.Models;

namespace SindaCMS.Controllers;

public class BlogController : Controller
{
    private readonly ILogger<BlogController> _logger;
    public BlogController(ILogger<BlogController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    { 
        return View("../PageTabs", new ViewProps {
            Site = new Site {
                BrandName = "Sinda",
                PageNames = new List<PageDetail> {
                    new PageDetail{ Name="Docs" },
                    new PageDetail{ Name="Blog" },
                    new PageDetail{Name= "Roadmap"} 
                },
                BrandDescription = "Sindagal MIT",
            },
            PageName = "Blog",
            Tabs = new List<Tab> {
                new Tab{Name="Articles", Status=SectionStatus.Hidden },
                new Tab{Name="News", Status=SectionStatus.Hidden },
            }
        });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
