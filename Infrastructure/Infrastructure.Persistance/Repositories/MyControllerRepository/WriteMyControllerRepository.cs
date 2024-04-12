

using Core.Application.Interfaces.Repositories.MyControllerRepository;
using Core.Domain.Entities.MyControllers;
using Infrastructure.Persistance.Contexts;

namespace Infrastructure.Persistance.Repositories.MyControllerRepository
{
    public class WriteMyControllerRepository : WriteRepository<MyController>, IWriteMyControllerRepository
    {
        public WriteMyControllerRepository(DataContext context) : base(context)
        {
        }
    }
}
