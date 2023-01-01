using System.Collections.Generic;
using floristWebApi.Entities;
using System.Threading.Tasks;

namespace floristWebApp.Client.FloristApi
{
    public interface IFloristClient
    {
        Task<Product?> GetProductById(int id);
        Task<List<Product>> GetAllProduct();
        Task<List<Category>> GetAllCategories();
        Task<List<Category>> GetProductCategories(int id);
    }
}