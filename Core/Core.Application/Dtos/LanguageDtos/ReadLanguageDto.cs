using Core.Application.Interfaces.Dtos;


namespace Core.Application.Dtos.LanguageDtos
{
    public class ReadLanguageDto : BaseDto, IReadDto
    {
        public string Code { get; set; }

    }
}
