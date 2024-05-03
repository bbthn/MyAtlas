

using Core.Application.Attributes;
using Core.Application.Interfaces.Repositories.LanguageRepository;
using Core.Domain.Entities.Languages;
using Infrastructure.Persistance.Contexts;

namespace Infrastructure.Persistance.Repositories.LanguageRepository
{
    [RepositoryInterface(Interface = "IWriteLanguageRepository")]
    public class WriteLanguageRepository : WriteRepository<Language>, IWriteLanguageRepository
    {
        public WriteLanguageRepository(DataContext context) : base(context)
        {
        }
    }
}
