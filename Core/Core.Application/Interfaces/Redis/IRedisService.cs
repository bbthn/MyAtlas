

using Core.Application.Services.RedisService;
using StackExchange.Redis;

namespace Core.Application.Interfaces.RedisService
{
    public interface IRedisService
    {
        public IDatabase GetDatabase();
        public IServer GetServer();
        public Task<bool> SetStringAsync(string key, string value);
        public Task<bool> SetStringAsync(string key, string value,Action<RedisCacheSetting> setting);
        public Task<string> GetStringAsync(string key);
        public bool IsRedisOpenAndConnect();

    }
}
