using floristWebApi.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace floristWebApp.Client.FloristApi
{
    public class FloristClient : IFloristClient
    {
        private readonly HttpClient _client;

        public FloristClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<Product?> GetProductById(int id)
        {
            var response =  await _client.GetAsync($"/api/product/{id}");
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                //throw new CustomerIdInvalidException();
            }
            var product = JsonConvert.DeserializeObject<Product>(response.Content.ReadAsStringAsync().Result);
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

        public async Task<List<Category>> GetAllCategories()
        {
            var response = await _client.GetFromJsonAsync<List<Category>>("/api/category");
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
    }
}