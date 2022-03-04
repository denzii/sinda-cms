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
        return View("../Shared/_Content", new PageProps(_props) {
            Name = "Docs",
            Sections = new List<Page> {
                new Page{Name="Terminal", Status=SectionStatus.Complete},
                new Page{Name="Scripts", Status=SectionStatus.Complete},
                new Page{Name="Boilerplate", Status=SectionStatus.Incomplete},
            }
        });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
