using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiMVC.Services
{
    public class CacheServices : ICache
    {

        string host = "gru";

        public void Set<T>(string key, T value)
        {
            using (var client = new RedisClient(host))
            {
                if (client.Get<string>(key) == null)
                {
                    // save value in cache
                    client.Set(key, value);
                }
            }
        }

        public T Get<T>(string key)
        {
            using (var client = new RedisClient(host))
            {

                try
                {
                    // get value from the cache by key
                    return client.Get<T>(key);
                }
                catch
    {
                    return default(T);
                }
            }
        }

    }
}
