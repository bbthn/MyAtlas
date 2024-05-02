
using Core.Application.Dtos.DataFilterDto;
using Core.Application.Dtos.MyControllerDtos;
using Core.Application.Dtos.ResultDataDto;
using MediatR;

namespace Core.Application.Features.Queries.MyControllerQueries.Queries
{
    public class GetMyControllerByIdQuery : DataFilterDto,IRequest<IResultDataDto<ReadMyControllerDto>>
    {
        public Guid MyControllerId { get; set; }
    }
}
