

using Core.Application.Attributes;
using Core.Application.Interfaces.Repositories.PageRepository;
using Core.Domain.Entities.Pages;
using Infrastructure.Persistance.Contexts;

namespace Infrastructure.Persistance.Repositories.PageRepository
{
    [RepositoryInterface(Interface = "IWritePageRepository")]

    public class WritePageRepository : WriteRepository<Page>, IWritePageRepository
    {
        public WritePageRepository(DataContext context) : base(context)
        {
        }
    }
}
