using floristWebApp.Client.FloristApi;
using floristWebApp.Models;
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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductDetail(int id)
        {
            var product = _floristClient.GetProductById(id).Result;
            return View(product);
        }

        public IActionResult LogIn()
        {
            return View(new UserLoginModel());
        }

        [HttpPost]
        public IActionResult LogIn(UserLoginModel model)
        {
            if(ModelState.IsValid)
            {

            }
            return View(new UserLoginModel());
        }
    }
    
}

