

using AutoMapper;
using Core.Application.Dtos.ResultDataDto;
using Core.Application.Dtos.UrlDtos;
using Core.Application.Features.Queries.UrlQueries.Queries;
using Core.Application.Interfaces.Repositories.UrlRepository;
using Core.Domain.Entities.Url;
using MediatR;

namespace Core.Application.Features.Queries.UrlQueries.Handlers
{
    public class GetBaseUrlsHandler : IRequestHandler<GetBaseUrlsQuery, IResultDataDto<List<ReadUrlDto>>>
    {
        private readonly IReadUrlRepository _readUrlRepository;
        private readonly IMapper _mapper;

        public GetBaseUrlsHandler(IReadUrlRepository readUrlRepository, IMapper mapper)
        {
            _readUrlRepository = readUrlRepository;
            _mapper = mapper;
        }

        public async Task<IResultDataDto<List<ReadUrlDto>>> Handle(GetBaseUrlsQuery request, CancellationToken cancellationToken)
        {
            IResultDataDto<List<ReadUrlDto>> result = new ResultDataDto<List<ReadUrlDto>>();
            try
            {
                List<Url> urls = await _readUrlRepository.GetAllUrl(request.ParsedUrl);
                if(urls != null)
                    return result.SetData(_mapper.Map<List<ReadUrlDto>>(urls)).SetSuccess(true).SetMessage("Success!");
                else
                    return result.SetSuccess(false).SetMessage("Failed!");

            }
            catch (Exception ex)
            {

                    return result.SetSuccess(false).SetMessage(ex.Message);
            }
        }
    }
}
