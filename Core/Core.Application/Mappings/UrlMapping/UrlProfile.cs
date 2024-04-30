

using AutoMapper;
using Core.Application.Dtos.UrlDtos;
using Core.Domain.Entities.Url;

namespace Core.Application.Mappings.UrlMapping
{
    public class UrlProfile : Profile
    {
        public UrlProfile()
        {
            CreateMap<Url,ReadUrlDto>().ReverseMap();
            CreateMap<Url, WriteUrlDto>().ReverseMap();


        }
    }
}
