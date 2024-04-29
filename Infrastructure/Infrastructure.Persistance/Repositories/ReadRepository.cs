

using Core.Application.Interfaces.Repositories;
using Core.Domain.Entities;
using Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Infrastructure.Persistance.Repositories
{
    public class ReadRepository<T> : BaseRepository , IReadRepository<T> where T : BaseEntity
    {
        public ReadRepository(DataContext context) : base(context) {}

        private DbSet<T> table => base._context.Set<T>();

        public Task<List<T>> GetAll(
            Expression<Func<T, bool>>? where, 
            Expression<Func<IQueryable<T>, IOrderedQueryable<T>>>? orderBy,
            bool asNoTracking = true, 
            params Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[]? include)
        {
            IQueryable<T> query = table.AsQueryable<T>();
            if(!asNoTracking)
                query = query.AsTracking();           
            if(include != null)
                foreach(var inc in include)
                {
                    query = inc.Compile()(query);

                }       
            if(where != null) 
                query = query.Where(where.Compile()).AsQueryable();         
            if (orderBy != null)
                query = orderBy.Compile()(query);
            return query.ToListAsync();
        }
        public async Task<T> GetSingle(Expression<Func<T, bool>> where,
           Expression<Func<IQueryable<T>, IOrderedQueryable<T>>> orderBy,
           bool asNoTracking = true,
           params Expression<Func<IQueryable<T>, IIncludableQueryable<T, object>>>[] include)
        {
            IQueryable<T> query = table.AsQueryable<T>();
            if(!asNoTracking)
                query= query.AsTracking<T>();
            if (where != null)
                query = query.Where(where.Compile()).AsQueryable();
            if(include!=null)
                foreach (var inc in include)
                {
                    query = inc.Compile()(query);
                    
                }
            if(orderBy!=null)
                query = orderBy.Compile()(query);
            return await query.FirstOrDefaultAsync();
        }

    }
}
