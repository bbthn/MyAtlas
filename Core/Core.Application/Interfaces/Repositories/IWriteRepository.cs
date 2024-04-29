
using Core.Domain.Entities;

namespace Core.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T> : IBaseRepository where T: BaseEntity
    {

        public Task<T> AddAsync(T entity);
        public Task<List<T>> AddRangeAsync(List<T> entities);

    }
}
