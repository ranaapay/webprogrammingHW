using floristWebApi.Context;
using floristWebApi.Entities;
using floristWebApi.Interfaces;

namespace floristWebApi.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext)
         : base(repositoryContext)
        {
        }
    }
}
