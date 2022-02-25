using System.Diagnostics;
using Jering.Javascript.NodeJS;
using Microsoft.AspNetCore.Mvc;
using SBv2.Models;

namespace SBv2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly BaseProps _props;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _props = new BaseProps();
    }

    public IActionResult Index()
    {
        return View(new PageProps(_props));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
