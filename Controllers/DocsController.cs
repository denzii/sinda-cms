using System.Diagnostics;
using Jering.Javascript.NodeJS;
using Microsoft.AspNetCore.Mvc;
using SBv2.Models;

namespace SBv2.Controllers;

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
        return View("Docs", new PageProps(_props) { Name = "Docs", SectionNames = new List<string> { "Terminal", "Boilerplate" } });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
