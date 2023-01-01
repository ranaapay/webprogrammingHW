using floristWebApi.Entities;
using floristWebApi.Interfaces;
using floristWebApp.Client.FloristApi;
using Microsoft.AspNetCore.Mvc;

namespace floristWebApp.ViewComponents
{
    public class CategoryList : ViewComponent
    {
        private readonly IFloristClient _floristClient;
        public CategoryList(IFloristClient floristClient) { 
            _floristClient= floristClient;
        }

        public IViewComponentResult Invoke() {
            var categories = _floristClient.GetAllCategories().Result;
            return View(categories); 
        }
    }
}
