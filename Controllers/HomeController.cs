using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GlobalWeb.Models;
using Microsoft.Extensions.Localization;

namespace GlobalWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IStringLocalizer<HomeController> _localizer;
    private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

    public HomeController(ILogger<HomeController> logger,
    IStringLocalizer<HomeController> localizer,
    IStringLocalizer<SharedResource> sharedLocalizer)
    {
        _logger = logger;
        _localizer = localizer;
        _sharedLocalizer = sharedLocalizer;
    }

    public IActionResult Index()
    {
        ViewData["pressRelease"] = _localizer["Press Release"];
        ViewData["welcome"] = _localizer.GetString("Welcome").Value ?? "";
        return View();
    }

    public IActionResult Privacy()
    {
        ViewData["pressRelease"] = _sharedLocalizer["Press Release"];
        ViewData["welcome"] = _sharedLocalizer.GetString("Welcome").Value ?? "";
        return View();
    }

    [HttpPost]
    public IActionResult Contact(Contact model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        ViewData["Result"] = _localizer["Success!"];
        return View(model);
    }

    public IActionResult Contact()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
