using floristWebApi.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using floristWebApp.Models;
using floristWebApi.Dtos;

namespace floristWebApp.Client.FloristApi
{
    public class FloristClient : IFloristClient
    {
        private readonly HttpClient _client;

        public FloristClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> Login(Models.UserLoginModel model)
        {
            var serializeModel = System.Text.Json.JsonSerializer.Serialize(model);
            StringContent stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("api/authentication/login", stringContent);
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        #region PRODUCT

        public async Task<Product?> GetProductById(int id)
        {
            var response = await _client.GetAsync($"/api/product/{id}");
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                //throw new CustomerIdInvalidException();
            }
            var product = JsonConvert.DeserializeObject<Product>(response.Content.ReadAsStringAsync().Result);
            return product;
        }

        public async Task<List<Product>> GetProductByCategoryId(int categoryId)
        {
            var response = await _client.GetAsync($"/api/product/category/{categoryId}");
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                //throw new CustomerIdInvalidException();
            }
            var product = JsonConvert.DeserializeObject<List<Product>>(response.Content.ReadAsStringAsync().Result);
            return product;
        }

        public async Task<List<Product>> GetAllProduct()
        {
            var response = await _client.GetFromJsonAsync<List<Product>>("/api/product");
            if (response == null)
            {
                //throw new CustomerIdInvalidException();
            }
            return response;
        }

        public async Task<List<Category>> GetProductCategories(int id)
        {
            var response = await _client.GetFromJsonAsync<List<Category>>($"/api/product/{id}/categories");
            if (response == null)
            {
                //throw new CustomerIdInvalidException();
            }
            return response;
        }

        public async Task CreateProduct(AddProductModel model)
        {
            var dtoProduct = new CreateProductModel
            {
                Name = model.Name,
                Price = model.Price,
            };

            if (model.Photo != null)
            {
                var extnsn = Path.GetExtension(model.Photo.FileName);
                var newPhotoName = Guid.NewGuid() + extnsn;
                var uploadRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + newPhotoName);

                var stream = new FileStream(uploadRoot, FileMode.Create);
                model.Photo.CopyTo(stream);

                dtoProduct.Photo = newPhotoName;
            }

            var serializeModel = System.Text.Json.JsonSerializer.Serialize(dtoProduct);
            StringContent stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");

            await _client.PostAsync("api/product", stringContent);
        }

        public async Task UpdateProduct(Models.UpdateProductModel model)
        {
            var dtoProduct = new floristWebApi.Dtos.UpdateProductModel
            {
                Id= model.Id,
                Name = model.Name,
                Price = model.Price,
            };

            if (model.Photo != null)
            {
                var extnsn = Path.GetExtension(model.Photo.FileName);
                var newPhotoName = Guid.NewGuid() + extnsn;
                var uploadRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + newPhotoName);

                var stream = new FileStream(uploadRoot, FileMode.Create);
                model.Photo.CopyTo(stream);

                dtoProduct.Photo = newPhotoName;
            }

            var serializeModel = System.Text.Json.JsonSerializer.Serialize(dtoProduct);
            StringContent stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");

            await _client.PostAsync($"api/product/{model.Id}", stringContent);
        }

        public async Task DeleteProduct(int id)
        {
            await _client.DeleteAsync($"/api/product/{id}");
        }

        #endregion

        #region CATEGORY

        public async Task<Category?> GetCategoryById(int id)
        {
            var response = await _client.GetAsync($"/api/category/{id}");
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                //throw new CustomerIdInvalidException();
            }
            var category = JsonConvert.DeserializeObject<Category>(response.Content.ReadAsStringAsync().Result);
            return category;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            var response = await _client.GetFromJsonAsync<List<Category>>("/api/category");
            if (response == null)
            {
                //throw new CustomerIdInvalidException();
            }
            return response;
        }

        public async Task CreateCategory(AddCategoryModel model)
        {
            var dtoCategory = new CreateCategoryModel
            {
                Name = model.Name,
            };

            var serializeModel = System.Text.Json.JsonSerializer.Serialize(dtoCategory);
            StringContent stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");

            await _client.PostAsync("api/category", stringContent);
        }

        public async Task UpdateCategory(Models.UpdateCategoryModel model)
        {
            var dtoCategory = new floristWebApi.Dtos.UpdateCategoryModel
            {
                Id = model.Id,
                Name = model.Name,
            };

            var serializeModel = System.Text.Json.JsonSerializer.Serialize(dtoCategory);
            StringContent stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");

            await _client.PostAsync($"api/category/{model.Id}", stringContent);
        }
        
        public async Task DeleteCategory(int id)
        {
            await _client.DeleteAsync($"/api/category/{id}");
        }

        public async Task AddCategoryToProduct(int id, Models.AddCategoryToProduct model)
        {
            var dtoCategoryProduct = new floristWebApi.Dtos.ProductCategoriesModel
            {
                CategoryId = model.CategoryId,
                ProductId = id
            };

            var serializeModel = System.Text.Json.JsonSerializer.Serialize(dtoCategoryProduct);
            StringContent stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");

            await _client.PostAsync("api/product/category", stringContent);
        }

        public async Task DeleteCategoryToProduct(int id, int categoryId)
        {
            await _client.DeleteAsync($"api/product/{id}/category/{categoryId}");
        }

        #endregion


    }
}