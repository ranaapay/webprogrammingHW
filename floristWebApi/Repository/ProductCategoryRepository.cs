using floristWebApi.Context;
using floristWebApi.Entities;

namespace floristWebApi.Repository
{
    public class CategoryRepository
    {
        public void Add(Category table)
        {
            using var context = new RepositoryContext();
            context.Categories.Add(table);
            context.SaveChanges();
        }

        public void Update(Category table)
        {
            using var context = new RepositoryContext();
            context.Categories.Update(table);
            context.SaveChanges();
        }
        public void Delete(Category table)
        {
            using var context = new RepositoryContext();
            context.Categories.Remove(table);
            context.SaveChanges();
        }
        public Category GetCategory(int id) { 
            using var context = new RepositoryContext();
            return context.Categories.Find(id);
        }

        public List<Category> GetAllCategories()
        {
            using var context = new RepositoryContext();
            return context.Categories.ToList();
        }
    }
}
