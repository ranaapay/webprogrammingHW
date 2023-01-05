using System.Collections.Generic;
using floristWebApi.Entities;

namespace floristWebApi.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        List<Category> GetCategories(int productId);
        void AddCategory(ProductCategory productCategory);
        void DeleteCategory(ProductCategory productCategory);
        List<Product> GetByCategoryId(int categoryId);
    }
}
