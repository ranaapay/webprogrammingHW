using System.Collections.Generic;
using System.Linq;
using floristWebApi.Context;
using floristWebApi.Entities;
using floristWebApi.Interfaces;

namespace floristWebApi.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        protected RepositoryContext RepositoryContext;
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public List<Category> GetCategories(int productId)
        {
            var categories = RepositoryContext.Products.Join(RepositoryContext.ProductCategories, product => product.Id, pCategory => pCategory.ProductId,
                (p, pC) => new
                {
                    product = p,
                    pCategory = pC
                }).Join(RepositoryContext.Categories, tables => tables.pCategory.CategoryId, category => category.Id,
                (pc, c) => new
                {
                    product = pc.product,
                    category = c,
                    pCategory = pc.pCategory
                }).Where(I => I.product.Id == productId).Select(I => new Category
                {
                    Id = I.category.Id,
                    Name= I.category.Name,

                }).ToList();

            return categories;
        }
    }
}
