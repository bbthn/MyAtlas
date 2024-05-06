
using Core.Application.Extensions;
using Core.Application.Interfaces.RedisService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace Core.Application.Services.RedisService
{
    public class RedisCacheSetting
    {
        public TimeSpan Expiry { get; set; }
        public When When { get; set; }
    }

    public class RedisService : IRedisService
    {
        private static RedisSettings _redisSettings;
        private readonly IDatabase _database;
        private readonly byte Database = 1;
        public RedisService(IOptions<RedisSettings> options)
        {
            _redisSettings = options.Value;           
        }

        private readonly Lazy<ConnectionMultiplexer> Connection = new Lazy<ConnectionMultiplexer>(() =>
        {
            RedisService._redisSettings.ConfigurationOptions = ConfigurationOptions.Parse(_redisSettings.ConnectionString);
            return ConnectionMultiplexer.Connect(RedisService._redisSettings.ConfigurationOptions);
        });

        public IDatabase GetDatabase()
        {
            return this.Connection.Value.GetDatabase(Database);
        }

        public IServer GetServer()
        {
            return this.Connection.Value.GetServer(RedisService._redisSettings.ConfigurationOptions.EndPoints.FirstOrDefault());
        }

        public async Task<bool> SetStringAsync(string key, string value)
        {
            return await Task.FromResult(this.GetDatabase().StringSet(key, value));
        }
        public async Task<bool> SetStringAsync(string key, string value, Action<RedisCacheSetting> setting)
        {
            RedisCacheSetting redisCacheSetting = new RedisCacheSetting();
            setting.Invoke(redisCacheSetting);
            return await this.GetDatabase().StringSetAsync(key, value, redisCacheSetting.Expiry, redisCacheSetting.When);
        }

        public async Task<string> GetStringAsync(string key)
        {
            return await Task.FromResult(this.GetDatabase().StringGet(key));
        }

        public bool IsRedisOpenAndConnect()
        {
            return RedisService._redisSettings.IsRedisOpen && this.Connection.Value.IsConnected;
        }
    }

    public class RedisSettings
    {
        public string ConnectionString { get; set; }
        public bool IsRedisOpen { get; set; }
        public ConfigurationOptions ConfigurationOptions { get; set; }
    }


}
