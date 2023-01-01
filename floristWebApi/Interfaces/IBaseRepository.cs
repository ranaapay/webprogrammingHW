using System.Collections.Generic;
using floristWebApi.Context;

namespace floristWebApi.Interfaces
{
    public interface IBaseRepository <T> where T : class, new()
    {
        public void Add(T document);
        public void Update(T document);
        public void Delete(T document);
        public T GetDocumentById(int id);
        public List<T> GetAllDocuments();
    }
}
