using Microsoft.Extensions.Caching.Distributed;
using WebAPIShopStudy.Services.CrudServices.Interfaces;

namespace WebAPIShopStudy.Services.RedisServices;

public interface IRedisService<T> {
    public Task<T?> GetCacheModelAsync(int id);
    public Task SetCacheModelAsync(T model);
    public Task DeleteCacheModelAsync(int id);
    public Task RefreshCacheModelAsync(int id, T model);
}
