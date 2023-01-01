using floristWebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace floristWebApi.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var product = _repository.GetDocumentById(id);
            if (product == null)
            {
                //throw new OrderNotFoundException(id);
            }
            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _repository.GetAllDocuments();
            if (products == null)
            {
                //throw new OrderNotFoundException(id);
            }
            return Ok(products);
        }

        [HttpGet("{id}/categories", Name = "GetProductCategories")]
        public IActionResult GetProductCategories(int id)
        {
            var categories = _repository.GetCategories(id);
            return Ok(categories);
        }
    }
}
