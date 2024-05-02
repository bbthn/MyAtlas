
using AutoMapper;
using Core.Application.Dtos.MyControllerDtos;
using Core.Application.Dtos.ResultDataDto;
using Core.Application.Features.Queries.MyControllerQueries.Queries;
using Core.Application.Interfaces.Repositories.MyControllerRepository;
using Core.Application.Interfaces.Repositories.PageRepository;
using Core.Domain.Entities.MyControllers;
using MediatR;

namespace Core.Application.Features.Queries.MyControllerQueries.Handlers
{
    public class GetMyControllerByIdHandler : IRequestHandler<GetMyControllerByIdQuery, IResultDataDto<ReadMyControllerDto>>
    {
        private readonly IReadMyControllerRepository _readMyControllerRepository;
        private readonly IMapper _mapper;

        public GetMyControllerByIdHandler(IReadMyControllerRepository readMyControllerRepository, IMapper mapper)
        {
            _readMyControllerRepository = readMyControllerRepository;
            _mapper = mapper;
        }
        public async Task<IResultDataDto<ReadMyControllerDto>> Handle(GetMyControllerByIdQuery request, CancellationToken cancellationToken)
        {
            IResultDataDto<ReadMyControllerDto> result = new ResultDataDto<ReadMyControllerDto>();
            try
            {
                MyController myController = await _readMyControllerRepository.GetSingleAsync(w => w.Id == request.MyControllerId);
                if (myController != null)
                    return result.SetData(_mapper.Map<ReadMyControllerDto>(myController)).SetSuccess(true).SetMessage("Success!");
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
