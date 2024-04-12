

namespace Core.Domain.Interfaces
{
    public interface IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public byte Status { get; set; }
    }
}
