

using Core.Domain.Entities.Url;

namespace Core.Application.Interfaces.Repositories.UrlRepository
{
    public interface IReadUrlRepository : IReadRepository<Url>
    {
        public Task<List<Url>> GetAllUrl(string[] baseUrls);
    }
}
