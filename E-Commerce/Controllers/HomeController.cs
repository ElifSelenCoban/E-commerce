using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.Models;
using E_Commerce.Business;

namespace E_Commerce.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly BooksServices _bookServices;

    public HomeController(ILogger<HomeController> logger, BooksServices booksService)
    {
        _logger = logger;
        _bookServices = booksService;
    }

    public async Task<ActionResult<List<Books>>> Index()
    {
        return View(await _bookServices.GetAsync());
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

