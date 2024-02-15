using System.Diagnostics;
using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI.Models;

namespace UI.Controllers;

public class HomeController : Controller
{
    private readonly PhoneBookContext _context;

    private readonly BLL.PhoneRepository _p;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, PhoneBookContext context)
    {
        _context = context;
        _p = new BLL.PhoneRepository(_context);
        _logger = logger;
    }

    public IActionResult Index()
    {
        var q = _p.InsertPhone();
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

