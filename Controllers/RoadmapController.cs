using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SindaCMS.Models;

namespace SindaCMS.Controllers;

public class RoadmapController : Controller
{
    private readonly ILogger<RoadmapController> _logger;
    private readonly BaseProps _props;
    public RoadmapController(ILogger<RoadmapController> logger)
    {
        _logger = logger;
        _props = new BaseProps();
    }

    public IActionResult Index()
    {
        return View("../Shared/_Content", new PageProps(_props) {
            Name = "Roadmap",
            Tabs = new List<PageTab> {
                new PageTab{Name = "Philosophy", Status = SectionStatus.Incomplete},
                new PageTab{Name = "Vision", Status = SectionStatus.Incomplete}
            }
        });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
