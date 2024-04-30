using Core.Application.Dtos.MyControllerDtos;
using Core.Application.Dtos.PageDtos;
using Core.Application.Interfaces.ControllerManager.Request;
using System.Text.Json.Serialization;

namespace Core.Application.Interfaces.ControllerManager.Response
{
    public interface ICurrentResponse
    {
        public ReadPageDto Page { get; set; }
        public ReadMyControllerDto MyController { get; set; }
        [JsonIgnore]
        public ICurrentRequest CurrentRequest { get; set; }
    }
}
