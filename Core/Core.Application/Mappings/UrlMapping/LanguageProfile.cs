

using AutoMapper;
using Core.Application.Dtos.LanguageDtos;
using Core.Domain.Entities.Languages;

namespace Core.Application.Mappings.UrlMapping
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<Language,ReadLanguageDto>().ReverseMap();
            CreateMap<Language, WriteLanguageDto>().ReverseMap();

        }
    }
}

