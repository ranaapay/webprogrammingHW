using Microsoft.AspNetCore.Mvc;

namespace floristWebApp.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}