

using Core.Application.Interfaces.Repositories;
using Core.Domain.Entities;
using Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class WriteRepository<T> : BaseRepository , IWriteRepository<T> where T:BaseEntity
    {
        public WriteRepository(DataContext context) : base(context) { }
        private DbSet<T> table => base._context.Set<T>();
    }
}
