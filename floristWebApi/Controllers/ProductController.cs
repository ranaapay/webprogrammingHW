using floristWebApi.Dtos;
using floristWebApi.Entities;
using floristWebApi.Interfaces;
using Microsoft.AspNetCore.Identity;
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

        [HttpGet("category/{categoryId}")]
        public IActionResult GetProductByCategoryId(int categoryId)
        {
            var products = _repository.GetByCategoryId(categoryId);
            return Ok(products);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody]CreateProductModel model)
        {
            var product = new Product { 
                Name= model.Name,
                Price= model.Price,
                Photo= model.Photo,
            };
            _repository.Add(product);
            return Ok();
        }

        [HttpPost("{id}")]
        public IActionResult UpdateProduct([FromBody]UpdateProductModel model)
        {
            var product = new Product { 
                Id =model.Id,
                Name= model.Name,
                Price= model.Price,
                Photo= model.Photo,
            };
            _repository.Update(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _repository.Delete(new Product { Id = id });
            return Ok();
        }

        [HttpPost("category")]
        public IActionResult AddCategoryToProduct([FromBody] ProductCategoriesModel model)
        {
            var productCategories = new ProductCategory
            {
                CategoryId= model.CategoryId,
                ProductId= model.ProductId,
            };

            _repository.AddCategory(productCategories);
            return Ok();
        }

        [HttpDelete("{id}/category/{categoryId}")]
        public IActionResult DeleteCategoryToProduct(int id, int categoryId)
        {
            var productCategories = new ProductCategory
            {
                CategoryId = categoryId,
                ProductId = id,
            };

            _repository.DeleteCategory(productCategories);
            return Ok();
        }
    }
}
