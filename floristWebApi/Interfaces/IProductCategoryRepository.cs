using System;
using floristWebApi.Entities;
using System.Linq.Expressions;

namespace floristWebApi.Interfaces
{
    public interface IProductCategoryRepository : IBaseRepository<ProductCategory>
    {
        ProductCategory GetByFilter(Expression<Func<ProductCategory, bool>> filter);
    }
}
