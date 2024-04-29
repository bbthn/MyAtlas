using Core.Application.Dtos.MyControllerDtos;
using Core.Application.Dtos.PageDtos;
using Core.Application.Interfaces.ControllerManager.Request;

namespace Core.Application.Interfaces.ControllerManager.Response
{
    public interface ICurrentResponse
    {
        public ReadPageDto Page { get; set; }
        public ReadMyControllerDto MyController { get; set; }
        public ICurrentRequest CurrentRequest { get; set; }
    }
}
