
using Core.Application.Dtos.DataFilterDto;
using Core.Application.Dtos.ResultDataDto;
using Core.Application.Dtos.UrlDtos;
using MediatR;

namespace Core.Application.Features.Queries.UrlQueries.Queries
{
    public class GetUrlByPathQuery : DataFilterDto,IRequest<IResultDataDto<ReadUrlDto>>
    {
        public string Path { get; set; }
    }
}
