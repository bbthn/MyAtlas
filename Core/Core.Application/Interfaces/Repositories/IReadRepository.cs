

using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Application.Interfaces.Repositories
{
    public interface IReadRepository<T> : IBaseRepository where T : BaseEntity
    {
        public Task<List<T>> GetAll(Expression<Func<T,bool>> where,
            Expression<Func<IQueryable<T>,IOrderedQueryable<T>>> orderBy,
            bool asNoTracking=true,
            params Expression<Func<IQueryable<T>, IIncludableQueryable<T,object>>>[] include);

        public Task<T> GetSingle(Expression<Func<T, bool>> where,
            Expression<Func<IQueryable<T>, IOrderedQueryable<T>>> orderBy,
            bool asNoTracking = true,
            params Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] include );

       

    }
}
