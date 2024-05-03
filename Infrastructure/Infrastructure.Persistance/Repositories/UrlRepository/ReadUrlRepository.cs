

using Core.Application.Attributes;
using Core.Application.Dtos.UrlDtos;
using Core.Application.Features.Queries.UrlQueries.Handlers;
using Core.Application.Interfaces.Repositories.UrlRepository;
using Core.Domain.Entities.Url;
using Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories.UrlRepository
{
    [RepositoryInterface(Interface = "IReadUrlRepository")]
    public class ReadUrlRepository : ReadRepository<Url>, IReadUrlRepository
    {
        public ReadUrlRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<Url>> GetAllUrl(string[] baseUrls)
        {
            DbSet<Url> table = base._context.Set<Url>();

            List<string> urlsPath = new List<string>();
            string path = string.Empty;
            for(int i = 1; i < baseUrls.Length-1; i++)
            {
                path += baseUrls[i] + "/";
                urlsPath.Add(path);               
            }

            List<Url> urls = new List<Url>();
            foreach (var urlPath in urlsPath)
            {
                Url result = await table.FirstOrDefaultAsync(f => f.Path == urlPath);
                if (result != null)
                    urls.Add(result);                        
            }
            return urls;

        }
    }
}
