

using Core.Application.Enum;

namespace Core.Application.Dtos.DataFilterDto
{
    public class DataFilterDto
    {
        public StatusEnum Status { get; set; } = StatusEnum.Online;
        public int Skip { get; set; } = 0;
        public int Length { get; set; } = 0;

    }
}
