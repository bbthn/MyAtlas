

using Core.Application.Services.RedisService;

namespace Core.Application.Attributes
{
    public class AddRedisAttribute : Attribute
    {
        public string CacheName { get; set; }
        public Type DataType { get; set; }

    }
}
