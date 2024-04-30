

using AutoMapper;
using Core.Application.Dtos.MyControllerDtos;
using Core.Domain.Entities.MyControllers;

namespace Core.Application.Mappings.UrlMapping
{
    public class MyControllerProfile : Profile
    {
        public MyControllerProfile()
        {
               CreateMap<MyController, ReadMyControllerDto>().ReverseMap();
            CreateMap<MyController, WriteMyControllerDto>().ReverseMap();

        }
    }
}
