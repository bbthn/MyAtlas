

namespace Core.Application.Interfaces.Dtos
{
    public interface IBaseDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
