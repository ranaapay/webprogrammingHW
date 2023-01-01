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
    }
}
