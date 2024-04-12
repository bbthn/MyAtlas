
using Core.Application.Interfaces.Repositories.UrlRepository;
using Core.Domain.Entities.Url;
using Infrastructure.Persistance.Contexts;

namespace Infrastructure.Persistance.Repositories.UrlRepository
{
    public class WriteUrlRepository : WriteRepository<Url> , IWriteUrlRepository
    {
        public WriteUrlRepository(DataContext dataContext):base(dataContext) { }

    }
}
