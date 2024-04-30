

using AutoMapper;
using Core.Application.Dtos.ResultDataDto;
using Core.Application.Dtos.UrlDtos;
using Core.Application.Features.Queries.UrlQueries.Queries;
using Core.Application.Interfaces.Repositories.UrlRepository;
using Core.Domain.Entities.Url;
using MediatR;

namespace Core.Application.Features.Queries.UrlQueries.Handlers
{
    public class GetAllUrlHandler : IRequestHandler<GetAllUrlQuery, IResultDataDto<List<ReadUrlDto>>>
    {
        private readonly IReadUrlRepository _readUrlRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetAllUrlHandler(IReadUrlRepository readUrlRepository, IMediator mediator, IMapper mapper)
        {
            _readUrlRepository = readUrlRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IResultDataDto<List<ReadUrlDto>>> Handle(GetAllUrlQuery request, CancellationToken cancellationToken)
        {
            IResultDataDto<List<ReadUrlDto>> result = new ResultDataDto<List<ReadUrlDto>>();
            try
            {
                List<Url> urls = await _readUrlRepository.GetAllAsync();
                if (urls.Count > 0)
                {
                    List<ReadUrlDto> readUrlDtos = _mapper.Map<List<ReadUrlDto>>(urls);
                    return result.SetData(readUrlDtos).SetSuccess(true).SetMessage("Success!");
                }
                else
                    return result.SetSuccess(false).SetMessage("Failed!");
            }
            catch (Exception ex){return result.SetSuccess(false).SetMessage($"{ex.Message}");}
        }
    }
}
