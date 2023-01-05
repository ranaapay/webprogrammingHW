using floristWebApi.Entities;
using floristWebApp.Client.FloristApi;
using floristWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace floristWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFloristClient _floristClient;

        public HomeController(IFloristClient floristClient)
        {
            _floristClient= floristClient;
        }

        // GET
        public IActionResult Index(int? categoryId)
        {
            ViewBag.CategoryId = categoryId;
            return View();
        }

        public IActionResult ProductDetail(int id)
        {
            var product = _floristClient.GetProductById(id).Result;
            return View(product);
        }

        public IActionResult Login()
        {
            return View(new UserLoginModel());
        }

        [HttpPost]
        public IActionResult Login(UserLoginModel model)
        {
            return RedirectToAction("Index", "Home", new { area = "Admin" });

            if (ModelState.IsValid)
            {
                var result = _floristClient.Login(model).Result;
                if (result)
                {
                    return RedirectToAction("Index", "Home", new {area= "Admin"});
                }
                ModelState.AddModelError("", "UserName or Password is wrong.");
            }
            return View(new UserLoginModel());
        }
    }
    
}

