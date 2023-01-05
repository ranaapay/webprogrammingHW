using floristWebApi.Dtos;
using floristWebApi.Entities;
using floristWebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace floristWebApi.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var category = _repository.GetDocumentById(id);
            if (category == null)
            {
                //throw new OrderNotFoundException(id);
            }
            return Ok(category);
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _repository.GetAllDocuments();
            if (categories == null)
            {
                //throw new OrderNotFoundException(id);
            }
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CreateCategoryModel model)
        {
            var category = new Category
            {
                Name = model.Name
            };
            _repository.Add(category);
            return Ok();
        }

        [HttpPost("{id}")]
        public IActionResult UpdateCategory([FromBody] UpdateCategoryModel model)
        {
            var category = new Category
            {
                Id= model.Id,
                Name = model.Name
            };

            _repository.Update(category);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _repository.Delete(new Category { Id = id });
            return Ok();
        }
    }
}
