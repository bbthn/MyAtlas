
using Core.Application.Interfaces.Repositories.MyControllerRepository;
using Core.Domain.Entities.MyControllers;
using Infrastructure.Persistance.Contexts;

namespace Infrastructure.Persistance.Repositories.MyControllerRepository
{
    public class ReadMyControllerRepository : ReadRepository<MyController>, IReadMyControllerRepository
    {
        public ReadMyControllerRepository(DataContext context) : base(context)
        {
        }
    }
}
