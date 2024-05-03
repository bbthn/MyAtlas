
using Core.Application.Attributes;
using Core.Application.Interfaces.Repositories.MyControllerRepository;
using Core.Domain.Entities.MyControllers;
using Infrastructure.Persistance.Contexts;

namespace Infrastructure.Persistance.Repositories.MyControllerRepository
{
    [RepositoryInterface(Interface = "IReadMyControllerRepository")]
    public class ReadMyControllerRepository : ReadRepository<MyController>, IReadMyControllerRepository
    {
        public ReadMyControllerRepository(DataContext context) : base(context)
        {
        }
    }
}
