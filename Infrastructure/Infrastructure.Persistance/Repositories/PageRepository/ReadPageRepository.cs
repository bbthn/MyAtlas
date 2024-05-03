
using Core.Application.Attributes;
using Core.Application.Interfaces.Repositories.PageRepository;
using Core.Domain.Entities.Pages;
using Infrastructure.Persistance.Contexts;

namespace Infrastructure.Persistance.Repositories.PageRepository
{
    [RepositoryInterface(Interface = "IReadPageRepository")]
    public class ReadPageRepository : ReadRepository<Page> , IReadPageRepository
    {
        public ReadPageRepository(DataContext context) : base(context)
        {
        }
    }
}
