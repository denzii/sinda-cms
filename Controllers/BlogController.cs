using System.Diagnostics;
using Jering.Javascript.NodeJS;
using Microsoft.AspNetCore.Mvc;
using SBv2.Models;

namespace SBv2.Controllers;

public class BlogController : Controller
{
    private readonly ILogger<BlogController> _logger;
    private readonly BaseProps _props;
    public BlogController(ILogger<BlogController> logger)
    {
        _logger = logger;
        _props = new BaseProps();
    }

    public IActionResult Index()
    {
        return View("Blog", new PageProps(_props) { Base = _props, Name = "Blog", SectionNames = new List<string> { "Articles", "News" } });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
