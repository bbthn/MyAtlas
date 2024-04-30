
using Core.Application.Dtos.ResultDataDto;
using Core.Application.Dtos.UrlDtos;
using MediatR;

namespace Core.Application.Features.Queries.UrlQueries.Queries
{
    public class GetAllUrlQuery : IRequest<IResultDataDto<List<ReadUrlDto>>>
    {
    }
}
