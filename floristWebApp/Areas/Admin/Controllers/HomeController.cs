using System.Collections.Generic;
using floristWebApp.Client.FloristApi;
using floristWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace floristWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IFloristClient _floristClient;

        public HomeController(IFloristClient floristClient)
        {
            _floristClient = floristClient;
        }

        public IActionResult Index()
        {
            return View(_floristClient.GetAllProduct().Result);
        }

        public IActionResult CreateProduct()
        {
            return View(new AddProductModel());
        }

        [HttpPost]
        public IActionResult CreateProduct(AddProductModel model)
        {
            if (ModelState.IsValid)
            {
                _floristClient.CreateProduct(model);
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            return View(model);
        }

        public IActionResult UpdateProduct(int id)
        {
            var product = _floristClient.GetProductById(id).Result;
            UpdateProductModel model = new UpdateProductModel
            {
                Name = product.Name,
                Price = product.Price,
                Id = id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductModel model)
        {
            if (ModelState.IsValid)
            {
                _floristClient.UpdateProduct(model);
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View(model);
        }

        public IActionResult DeleteProduct(int id)
        {
            _floristClient.DeleteProduct(id);
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }

        public IActionResult AddCategoryToProduct(int id)
        {
            var productCategories = _floristClient.GetProductCategories(id).Result.Select(I => I.Name);
            var categories = _floristClient.GetAllCategories().Result;

            TempData["ProductId"] = id;

            List<AddCategoryToProduct> list = new List<AddCategoryToProduct>();
            foreach (var category in categories)
            {
                AddCategoryToProduct model = new AddCategoryToProduct();
                model.CategoryId = category.Id;
                model.CategoryName = category.Name;
                model.IsExist = productCategories.Contains(category.Name);

                list.Add(model);
            }

            return View(list);
        }

        [HttpPost]
        public IActionResult AddCategoryToProduct(List<AddCategoryToProduct> list)
        {
            int productId = (int)TempData["ProductId"];

            foreach (var item in list)
            {
                if (item.IsExist)
                {
                    _floristClient.AddCategoryToProduct(productId, item);
                }
                else
                {
                    _floristClient.DeleteCategoryToProduct(productId, item.CategoryId);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
