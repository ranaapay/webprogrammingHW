using System.Collections.Generic;
using System.Linq;
using floristWebApi.Context;
using floristWebApi.Entities;
using floristWebApi.Interfaces;

namespace floristWebApi.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        protected RepositoryContext RepositoryContext;
        public BaseRepository(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public void Add(T document)
        {
            RepositoryContext.Set<T>().Add(document);
            RepositoryContext.SaveChanges();
        }

        public void Update(T document)
        {
            RepositoryContext.Set<T>().Update(document);
            RepositoryContext.SaveChanges();
        }
        public void Delete(T document)
        {
            RepositoryContext.Set<T>().Remove(document);
            RepositoryContext.SaveChanges();
        }
        public T GetDocumentById(int id) { 
            return  RepositoryContext.Set<T>().Find(id);
        }

        public List<T> GetAllDocuments()
        {
            return RepositoryContext.Set<T>().ToList();
        }
    }
}
