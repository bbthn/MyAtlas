using Core.Application.Interfaces.Dtos;

namespace Core.Application.Dtos.MyControllerDtos
{
    public class ReadMyControllerDto : BaseDto, IReadDto
    {
        public string Title { get; set; }
        public string ViewLayout { get; set; }
        public string ControllerName { get; set; }
    }
}
