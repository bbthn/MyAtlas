

using Core.Application.Interfaces.Dtos;

namespace Core.Application.Dtos
{
    public class BaseDto : IBaseDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
