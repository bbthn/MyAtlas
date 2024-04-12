

using Core.Domain.Entities;

namespace Core.Application.Interfaces.Repositories
{
    public interface IReadRepository<T> : IBaseRepository where T : BaseEntity
    {
    }
}
