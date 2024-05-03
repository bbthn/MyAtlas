
using Core.Application.Attributes;
using Core.Application.Interfaces.Repositories.UrlRepository;
using Core.Domain.Entities.Url;
using Infrastructure.Persistance.Contexts;

namespace Infrastructure.Persistance.Repositories.UrlRepository
{
    [RepositoryInterface(Interface = "IWriteUrlRepository")]

    public class WriteUrlRepository : WriteRepository<Url> , IWriteUrlRepository
    {
        public WriteUrlRepository(DataContext dataContext):base(dataContext) { }

    }
}
