using floristWebApi.Entities;
using floristWebApi.Interfaces;
using floristWebApp.Client.FloristApi;
using Microsoft.AspNetCore.Mvc;

namespace floristWebApp.ViewComponents
{
    public class ProductList : ViewComponent
    {
        private readonly IFloristClient _floristClient;
        public ProductList(IFloristClient floristClient) {
            _floristClient= floristClient; 
        }

        public IViewComponentResult Invoke() {

            var products = _floristClient.GetAllProduct().Result;
            return View(products); 
        }
    }
}
