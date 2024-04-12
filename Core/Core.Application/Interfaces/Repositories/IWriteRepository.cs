
using Core.Domain.Entities;

namespace Core.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T> : IBaseRepository where T: BaseEntity
    {
    }
}
