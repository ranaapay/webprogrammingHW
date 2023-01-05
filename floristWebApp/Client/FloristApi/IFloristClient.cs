using System.Collections.Generic;
using floristWebApi.Entities;
using System.Threading.Tasks;
using floristWebApp.Models;

namespace floristWebApp.Client.FloristApi
{
    public interface IFloristClient
    {
        Task<Product?> GetProductById(int id);
        Task<List<Product>> GetAllProduct();
        Task<List<Category>> GetAllCategories();
        Task<List<Category>> GetProductCategories(int id);
        Task<bool> Login(UserLoginModel model);
        Task CreateProduct(AddProductModel model);
        Task UpdateProduct(UpdateProductModel model);
        Task DeleteProduct(int id);
        Task CreateCategory(AddCategoryModel model);
        Task<Category?> GetCategoryById(int id);
        Task UpdateCategory(UpdateCategoryModel model);
        Task DeleteCategory(int id);
        Task DeleteCategoryToProduct(int id, int categoryId);
        Task AddCategoryToProduct(int id, AddCategoryToProduct model);
        Task<List<Product>> GetProductByCategoryId(int categoryId);
    }
}