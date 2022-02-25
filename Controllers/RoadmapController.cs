using System.Diagnostics;
using Jering.Javascript.NodeJS;
using Microsoft.AspNetCore.Mvc;
using SBv2.Models;

namespace SBv2.Controllers;

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
        return View("Roadmap", new PageProps(_props) { Base = _props, Name = "Roadmap", SectionNames = new List<string> { "Philosophy", "Vision" } });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
