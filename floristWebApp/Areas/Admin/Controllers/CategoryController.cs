using floristWebApp.Client.FloristApi;
using floristWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace floristWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IFloristClient _floristClient;

        public CategoryController(IFloristClient floristClient) {
            _floristClient= floristClient;
        }

        public IActionResult Index()
        {
            var categories = _floristClient.GetAllCategories().Result;
            return View(categories);
        }

        public IActionResult CreateCategory() 
        {
            return View(new AddCategoryModel());
        }

        [HttpPost]
        public IActionResult CreateCategory(AddCategoryModel model)
        {
            if(ModelState.IsValid)
            {
                _floristClient.CreateCategory(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UpdateCategory(int id)
        {
            var category = _floristClient.GetCategoryById(id).Result;
            UpdateCategoryModel model = new UpdateCategoryModel
            {
                Id = id,
                Name = category.Name
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateCategory(UpdateCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                _floristClient.UpdateCategory(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult DeleteCategory(int id)
        {
            _floristClient.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
