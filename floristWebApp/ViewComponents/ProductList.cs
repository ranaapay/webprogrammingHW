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

        public IViewComponentResult Invoke(int? categoryId) {

            if(categoryId.HasValue)
            {
                return View(_floristClient.GetProductByCategoryId((int)categoryId).Result);
            }

            var products = _floristClient.GetAllProduct().Result;
            return View(products); 
        }
    }
}
