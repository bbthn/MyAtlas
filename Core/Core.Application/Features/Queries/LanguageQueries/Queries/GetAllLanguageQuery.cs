

using Core.Application.Dtos.DataFilterDto;
using Core.Application.Dtos.LanguageDtos;
using Core.Application.Dtos.ResultDataDto;
using MediatR;

namespace Core.Application.Features.Queries.LanguageQueries.Queries
{
    public class GetAllLanguageQuery : DataFilterDto, IRequest<IResultDataDto<List<ReadLanguageDto>>>
    {
    }
}
