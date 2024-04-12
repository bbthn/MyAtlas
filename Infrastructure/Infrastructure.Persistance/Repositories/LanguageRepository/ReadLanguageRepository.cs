

using Core.Application.Interfaces.Repositories.LanguageRepository;
using Core.Domain.Entities.Languages;
using Infrastructure.Persistance.Contexts;

namespace Infrastructure.Persistance.Repositories.LanguageRepository
{
    public class ReadLanguageRepository : ReadRepository<Language>, IReadLanguageRepository
    {
        public ReadLanguageRepository(DataContext context) : base(context)
        {
        }
    }
}
