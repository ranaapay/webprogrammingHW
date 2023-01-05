using System.Collections.Generic;
using System.Linq;
using floristWebApi.Context;
using floristWebApi.Entities;
using floristWebApi.Interfaces;

namespace floristWebApi.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        protected RepositoryContext RepositoryContext;
        public ProductRepository(RepositoryContext repositoryContext, IProductCategoryRepository productCategoryRepository) : base(repositoryContext)
        {
            RepositoryContext = repositoryContext;
            _productCategoryRepository = productCategoryRepository;
        }

        public void AddCategory(ProductCategory productCategory)
        {
            var record = _productCategoryRepository.GetByFilter(I => I.CategoryId ==
            productCategory.CategoryId && I.ProductId == productCategory.ProductId);
            if (record == null)
            {
                _productCategoryRepository.Add(productCategory);
            }
        }

        public void DeleteCategory(ProductCategory productCategory)
        {
            var record = _productCategoryRepository.GetByFilter(I => I.CategoryId ==
            productCategory.CategoryId && I.ProductId == productCategory.ProductId);
            if (record != null)
            {
                _productCategoryRepository.Delete(record);
            }
        }

        public List<Product> GetByCategoryId(int categoryId)
        {
            return RepositoryContext.Products.Join(RepositoryContext.ProductCategories, p => p.Id, pc => pc.ProductId,
                (product, prodCat) => new
                {
                    product = product,
                    prodCat = prodCat
                }).Where(I => I.prodCat.CategoryId== categoryId).Select( I => new Product
                {
                    Id = I.product.Id,
                    Name= I.product.Name,
                    Price= I.product.Price,
                    Photo = I.product.Photo,
                }).ToList();
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
