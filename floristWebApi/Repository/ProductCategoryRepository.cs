using System;
using System.Linq;
using floristWebApi.Context;
using floristWebApi.Entities;
using floristWebApi.Interfaces;
using System.Linq.Expressions;

namespace floristWebApi.Repository
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {
        protected RepositoryContext RepositoryContext;

        public ProductCategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public ProductCategory GetByFilter(Expression<Func<ProductCategory, bool>> filter)
        {
            return RepositoryContext.ProductCategories.FirstOrDefault(filter);
        }
    }
}
