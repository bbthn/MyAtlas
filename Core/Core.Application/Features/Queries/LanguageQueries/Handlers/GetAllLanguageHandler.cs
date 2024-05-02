

using AutoMapper;
using Core.Application.Dtos.LanguageDtos;
using Core.Application.Dtos.ResultDataDto;
using Core.Application.Features.Queries.LanguageQueries.Queries;
using Core.Application.Interfaces.Repositories.LanguageRepository;
using Core.Domain.Entities.Languages;
using MediatR;
using System.Collections.Generic;

namespace Core.Application.Features.Queries.LanguageQueries.Handlers
{
    public class GetAllLanguageHandler : IRequestHandler<GetAllLanguageQuery, IResultDataDto<List<ReadLanguageDto>>>
    {
        private readonly IReadLanguageRepository _readLanguageRepository;
        private readonly IMapper _mapper;

        public GetAllLanguageHandler(IReadLanguageRepository readLanguageRepository, IMapper mapper)
        {
            _readLanguageRepository = readLanguageRepository;
            _mapper = mapper;
        }

        public async Task<IResultDataDto<List<ReadLanguageDto>>> Handle(GetAllLanguageQuery request, CancellationToken cancellationToken)
        {
            IResultDataDto<List<ReadLanguageDto>> result = new ResultDataDto<List<ReadLanguageDto>>();
            try
            {
                List<Language> languages = await _readLanguageRepository.GetAllAsync();
                if (languages.Count > 0)
                    return result.SetData(_mapper.Map<List<ReadLanguageDto>>(languages)).SetSuccess(true).SetMessage("Success!");
                else
                    return result.SetSuccess(false).SetMessage("Failed!");

            }
            catch (Exception ex) {return result.SetSuccess(false).SetMessage(ex.Message);}
        }
    }
}
