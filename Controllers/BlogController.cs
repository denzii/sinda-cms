using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SindaCMS.Models;

namespace SindaCMS.Controllers;

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
        return View("../Shared/_Content", new PageProps(_props) {
            Name = "Blog",
            Sections = new List<Page> {
                new Page{Name="Articles", Status=SectionStatus.Incomplete},
                new Page{Name="News", Status=SectionStatus.Incomplete},
            }
        });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
