
using Core.Application.Extensions;
using Core.Application.Interfaces.RedisService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace Core.Application.Services.RedisService
{
   
    public class RedisService : IRedisService
    {
        private static RedisSettings Settings;

        private readonly Lazy<ConnectionMultiplexer> _lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            RedisService.Settings.ConfigurationOptions = ConfigurationOptions.Parse(RedisService.Settings.ConnectionString);
            return ConnectionMultiplexer.Connect(RedisService.Settings.ConfigurationOptions);

        });
        public RedisService(IOptions<RedisSettings> settings)
        {
            Settings = settings.Value;         
        }

    }

    public class RedisSettings
    {
        public string ConnectionString { get; set; }
        public bool IsRedisOpen { get; set; }
        public ConfigurationOptions ConfigurationOptions { get; set; }
    }
}
