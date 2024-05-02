

using Core.Application.Dtos.DataFilterDto;
using Core.Application.Dtos.PageDtos;
using Core.Application.Dtos.ResultDataDto;
using MediatR;

namespace Core.Application.Features.Queries.PageQueries.Queries
{
    public class GetPageByUrlIdQuery : DataFilterDto, IRequest<IResultDataDto<ReadPageDto>>
    {
        public Guid UrlId { get; set; }
    }
}
