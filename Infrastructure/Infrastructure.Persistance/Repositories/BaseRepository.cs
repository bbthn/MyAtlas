﻿

using Core.Application.Interfaces.Repositories;
using Infrastructure.Persistance.Contexts;

namespace Infrastructure.Persistance.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private protected readonly DataContext _context;
        public BaseRepository(DataContext context)
        {
            _context = context;
        }
    }
}
