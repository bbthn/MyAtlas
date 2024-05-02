

using AutoMapper;
using Core.Application.Dtos.PageDtos;
using Core.Application.Dtos.ResultDataDto;
using Core.Application.Features.Queries.PageQueries.Queries;
using Core.Application.Interfaces.Repositories.PageRepository;
using Core.Domain.Entities.Pages;
using MediatR;

namespace Core.Application.Features.Queries.PageQueries.Handlers
{
    public class GetPageByUrlIdHandler : IRequestHandler<GetPageByUrlIdQuery, IResultDataDto<ReadPageDto>>
    {
        private readonly IReadPageRepository _readPageRepository;
        private readonly IMapper _mapper;

        public GetPageByUrlIdHandler(IReadPageRepository readPageRepository, IMapper mapper)
        {
            _readPageRepository = readPageRepository;
            _mapper = mapper;
        }

        public async Task<IResultDataDto<ReadPageDto>> Handle(GetPageByUrlIdQuery request, CancellationToken cancellationToken)
        {
            IResultDataDto<ReadPageDto> result = new ResultDataDto<ReadPageDto>();  
            try
            {
                Page page = await _readPageRepository.GetSingleAsync(w => w.UrlId == request.UrlId);
                if (page != null)
                    return result.SetData(_mapper.Map<ReadPageDto>(page)).SetSuccess(true).SetMessage("Success!");
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
