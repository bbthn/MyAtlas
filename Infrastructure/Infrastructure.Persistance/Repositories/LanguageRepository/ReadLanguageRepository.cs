

using Core.Application.Attributes;
using Core.Application.Interfaces.Repositories.LanguageRepository;
using Core.Domain.Entities.Languages;
using Infrastructure.Persistance.Contexts;

namespace Infrastructure.Persistance.Repositories.LanguageRepository
{
    [RepositoryInterface(Interface = "IReadLanguageRepository")]

    public class ReadLanguageRepository : ReadRepository<Language>, IReadLanguageRepository
    {
        public ReadLanguageRepository(DataContext context) : base(context)
        {
        }
    }
}
