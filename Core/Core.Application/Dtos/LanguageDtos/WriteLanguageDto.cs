
using Core.Application.Interfaces.Dtos;

namespace Core.Application.Dtos.LanguageDtos
{
    public class WriteLanguageDto : BaseDto, IWriteDto
    {
        public string Code { get; set; }

    }
}
