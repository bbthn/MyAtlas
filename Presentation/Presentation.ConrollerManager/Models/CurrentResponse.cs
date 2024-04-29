
using Core.Application.Dtos.MyControllerDtos;
using Core.Application.Dtos.PageDtos;
using Core.Application.Interfaces.ControllerManager.Request;
using Core.Application.Interfaces.ControllerManager.Response;

namespace Presentation.ConrollerManager.Models
{
    public class CurrentResponse : ICurrentResponse
    {
        public ReadPageDto Page { get; set; }
        public ReadMyControllerDto MyController { get; set; }
        public ICurrentRequest CurrentRequest { get; set; }

    }
}
