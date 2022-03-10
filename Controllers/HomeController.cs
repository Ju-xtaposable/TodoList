using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TodoList.DataLayers;

namespace TodoList.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DefaultContext _context = null;

    public HomeController(ILogger<HomeController> logger, DefaultContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
