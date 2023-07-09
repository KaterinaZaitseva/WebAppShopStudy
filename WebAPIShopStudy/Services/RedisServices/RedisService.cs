using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using WebAPIShopStudy.Models.Entities;
using WebAPIShopStudy.Services.CrudServices.Interfaces;

namespace WebAPIShopStudy.Services.RedisServices;

public class RedisService<T> : IRedisService<T> where T: BaseModel {
    public RedisService(IDistributedCache distributedCache, ICrudAsyncService<T> crudAsyncService) {
        _distributedCache = distributedCache;
        _crudAsyncService = crudAsyncService;
    }


    private readonly IDistributedCache _distributedCache;
    private readonly ICrudAsyncService<T> _crudAsyncService;


    public async Task<T?> GetCacheModelAsync(int id) {
        T? model = null;
        var modelString = await _distributedCache.GetStringAsync(id.ToString());

        if (modelString is not null)
            return JsonSerializer.Deserialize<T>(modelString);
 
        model = await _crudAsyncService.GetByIdAsync(id);
        if (model is null) 
            return null;

        await SetCacheModelAsync(model);

        return model;
    }

    public async Task SetCacheModelAsync(T model) {
        var modelString = JsonSerializer.Serialize(model);

        await _distributedCache.SetStringAsync(model.Id.ToString(), modelString, new DistributedCacheEntryOptions { 
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
        });
   
    }

    public async Task DeleteCacheModelAsync(int id) {
        if (await _distributedCache.GetStringAsync(id.ToString()) is null)
            return;

        await _distributedCache.RemoveAsync(id.ToString());
    }

    public async Task RefreshCacheModelAsync(int id, T model) {
        var modelString = JsonSerializer.Serialize(model);
        await _distributedCache.RefreshAsync(model.Id.ToString());
    }
}
