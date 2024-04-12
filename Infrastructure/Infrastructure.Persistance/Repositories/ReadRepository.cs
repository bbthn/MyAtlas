

using Core.Application.Interfaces.Repositories;
using Core.Domain.Entities;
using Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistance.Repositories
{
    public class ReadRepository<T> : BaseRepository , IReadRepository<T> where T : BaseEntity
    {
        public ReadRepository(DataContext context) : base(context)
        {
        }

        private DbSet<T> table => base._context.Set<T>();

    }
}
