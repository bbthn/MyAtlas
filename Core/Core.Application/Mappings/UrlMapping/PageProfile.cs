

using AutoMapper;
using Core.Application.Dtos.PageDtos;
using Core.Domain.Entities.Pages;

namespace Core.Application.Mappings.UrlMapping
{
    public class PageProfile : Profile
    {
        public PageProfile()
        {
                CreateMap<Page,ReadPageDto>().ReverseMap();
            CreateMap<Page, WritePageDto>().ReverseMap();

        }
    }
}
