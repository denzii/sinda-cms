using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SindaCMS.Data;
using SindaCMS.Models;

namespace SindaCMS.Controllers;

public class RoadmapController : Controller
{
    private readonly ILogger<RoadmapController> _logger;
    private readonly IRepository _repo;
    public RoadmapController(ILogger<RoadmapController> logger, IRepository repo)
    {
        _logger = logger;
        _repo = repo;
    }

    public async Task<IActionResult> Index()
    {
        string pageName = "Roadmap";

        return View("../PageTabs", new ViewProps {
            Site = await _repo.GetSiteAsync(),
            PageName = "Roadmap",
            Tabs = await _repo.GetPageTabsAsync(pageName)
        });

        //return View("../PageTabs", new ViewProps {
        //    Site = new Site {
        //        BrandName = "Sinda",
        //        PageNames = new List<PageDetail> {
        //            new PageDetail{ Name="Docs" },
        //            new PageDetail{ Name="Blog" },
        //            new PageDetail{Name= "Roadmap"}
        //        },
        //        BrandDescription = "Sindagal MIT",
        //    },
        //    PageName = "Roadmap",
        //    Tabs = new List<Tab> {
        //        new Tab{Name = "Philosophy", Status = SectionStatus.Hidden},
        //        new Tab{Name = "Vision", Status = SectionStatus.Hidden}
        //    }
        //});
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
