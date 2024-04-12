
using Core.Application.Interfaces.Dtos;

namespace Core.Application.Dtos.MyControllerDtos
{
    public class WriteMyControllerDto : BaseDto, IWriteDto
    {
        public string Title { get; set; }
        public string ViewLayout { get; set; }
        public string ControllerName { get; set; }
    }       
}
