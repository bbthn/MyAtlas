

using Core.Application.Interfaces.Repositories.LanguageRepository;
using Core.Domain.Entities.Languages;
using Infrastructure.Persistance.Contexts;

namespace Infrastructure.Persistance.Repositories.LanguageRepository
{
    public class WriteLanguageRepository : WriteRepository<Language>, IWriteLanguageRepository
    {
        public WriteLanguageRepository(DataContext context) : base(context)
        {
        }
    }
}
