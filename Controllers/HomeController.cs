using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SindaCMS.Data;
using SindaCMS.Models;

namespace SindaCMS.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepository _repo;
    public HomeController(ILogger<HomeController> logger, IRepository repo, IConfiguration conf)
    {
        _logger = logger;
        _repo = repo;
    }

    public async Task<IActionResult> Index() {
        // hello, is it me ur lookin for??
        return View("../Index", new ViewProps  {
            Site = await _repo.GetSiteAsync()
        });

        //return View("../Index", new ViewProps {
        //    Site = new Site
        //    {
        //        BrandName = "Sinda",
        //        PageNames = new List<PageDetail> {
        //            new PageDetail{ Name="Docs" },
        //            new PageDetail{ Name="Blog" },
        //            new PageDetail{Name= "Roadmap"}
        //        },
        //        BrandDescription = "Sindagal MIT",
        //    }
        //});
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
