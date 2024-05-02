

using AutoMapper;
using Core.Application.Dtos.ResultDataDto;
using Core.Application.Dtos.UrlDtos;
using Core.Application.Features.Queries.UrlQueries.Queries;
using Core.Application.Interfaces.Repositories.UrlRepository;
using Core.Domain.Entities.Url;
using MediatR;

namespace Core.Application.Features.Queries.UrlQueries.Handlers
{
    public class GetUrlByPathHandler : IRequestHandler<GetUrlByPathQuery, IResultDataDto<ReadUrlDto>>
    {
        private readonly IReadUrlRepository _readUrlRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetUrlByPathHandler(IReadUrlRepository readUrlRepository, IMediator mediator, IMapper mapper)
        {
            _readUrlRepository = readUrlRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IResultDataDto<ReadUrlDto>> Handle(GetUrlByPathQuery request, CancellationToken cancellationToken)
        {
            IResultDataDto<ReadUrlDto> result = new ResultDataDto<ReadUrlDto>();
            try
            {
                Url url = await _readUrlRepository.GetSingleAsync(where:w=>w.Path == request.Path && w.Status ==(byte)request.Status);
                if (url !=null)
                {
                    ReadUrlDto readUrlDto = _mapper.Map<ReadUrlDto>(url);
                    return result.SetData(readUrlDto).SetSuccess(true).SetMessage("Success!");
                }
                else
                    return result.SetSuccess(false).SetMessage("Failed!");
            }
            catch (Exception ex){return result.SetSuccess(false).SetMessage($"{ex.Message}");}
        }
    }
}
