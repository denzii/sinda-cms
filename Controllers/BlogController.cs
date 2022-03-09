using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SindaCMS.Data;
using SindaCMS.Models;

namespace SindaCMS.Controllers;

public class BlogController : Controller
{
    private readonly ILogger<BlogController> _logger;
    private readonly IRepository _repo;
    public BlogController(ILogger<BlogController> logger, IRepository repo)
    {
        _logger = logger;
        _repo = repo;
    }

    public async Task<IActionResult> Index()
    {
        string pageName = "Blog";

        return View("../PageTabs", new ViewProps {
            Site =  await _repo.GetSiteAsync(),
            PageName = pageName,
            Tabs = await _repo.GetPageTabsAsync(pageName)
        });

        //return View("../PageTabs", new ViewProps {
        //    Site =  await _repo.GetSite(),
        //    PageName = "Blog",
        //    Tabs = new List<Tab> {
        //        new Tab{ Name="Articles", Status=SectionStatus.Hidden },
        //        new Tab{ Name="News", Status=SectionStatus.Hidden },
        //    }
        //});
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
