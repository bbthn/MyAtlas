
using Core.Application.Dtos.DataFilterDto;
using Core.Application.Dtos.ResultDataDto;
using Core.Application.Dtos.UrlDtos;
using MediatR;

namespace Core.Application.Features.Queries.UrlQueries.Queries
{
    public class GetBaseUrlsQuery : DataFilterDto,IRequest<IResultDataDto<List<ReadUrlDto>>>
    {
        public string[] ParsedUrl { get; set; }

    }
}
