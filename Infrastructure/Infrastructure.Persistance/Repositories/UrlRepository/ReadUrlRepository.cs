

using Core.Application.Interfaces.Repositories.UrlRepository;
using Core.Domain.Entities.Url;
using Infrastructure.Persistance.Contexts;

namespace Infrastructure.Persistance.Repositories.UrlRepository
{
    public class ReadUrlRepository : ReadRepository<Url> ,IReadUrlRepository
    {
        public ReadUrlRepository(DataContext context) : base(context)
        {
        }
    }
}
