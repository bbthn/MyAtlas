

using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Application.Interfaces.Repositories
{
    public interface IReadRepository<T> : IBaseRepository where T : BaseEntity
    {
        public Task<List<T>> GetAllAsync(Expression<Func<T,bool>> where=null,
            Expression<Func<IQueryable<T>,IOrderedQueryable<T>>> orderBy=null,
            bool asNoTracking=true,
            Expression<Func<IQueryable<T>, IIncludableQueryable<T,object>>>[] include=null);

        public Task<T> GetSingleAsync(Expression<Func<T, bool>> where=null,
            Expression<Func<IQueryable<T>, IOrderedQueryable<T>>> orderBy=null,
            bool asNoTracking = true,
            Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] include=null);

       

    }
}
