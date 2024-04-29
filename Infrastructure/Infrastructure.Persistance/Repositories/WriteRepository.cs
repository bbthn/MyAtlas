

using Core.Application.Interfaces.Repositories;
using Core.Domain.Entities;
using Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Persistance.Repositories
{
    public class WriteRepository<T> : BaseRepository , IWriteRepository<T> where T:BaseEntity
    {
        public WriteRepository(DataContext context) : base(context) { }
        private DbSet<T> table => base._context.Set<T>();
        public async Task<T> AddAsync(T entity)
        {
            try
            {
                if (entity == null) throw new Exception("Entity must not be null!");
                EntityEntry<T> result = await table.AddAsync(entity);
                await base._context.SaveChangesAsync();
                return result.Entity;

            }
            catch (Exception ex){throw new Exception(ex.Message);}
        }

        public async Task<List<T>> AddRangeAsync(List<T> entities)
        {
            try
            {
                if (entities == null && entities.Count == 0) throw new Exception("Entities must not be null!");
                await table.AddRangeAsync(entities);
                await base._context.SaveChangesAsync();
                return entities;

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
