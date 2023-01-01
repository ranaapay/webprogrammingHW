using floristWebApi.Context;
using floristWebApi.Entities;
using floristWebApi.Interfaces;

namespace floristWebApi.Repository
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
