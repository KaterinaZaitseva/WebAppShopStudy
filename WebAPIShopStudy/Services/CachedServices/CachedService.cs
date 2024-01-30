using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using WebAPIShopStudy.Models.Entities;

namespace WebAPIShopStudy.Services.CachedServices;

public class CachedService : ICachedService {

    public CachedService(IDistributedCache distributedCache) {
        _distributedCache = distributedCache;
    }


    private readonly IDistributedCache _distributedCache;


    public async Task<IEnumerable<T>?> GetAllCacheModelsAsync<T>() where T : BaseModel {
        var modelsString = await _distributedCache.GetStringAsync(typeof(T).Name);

        if (modelsString is null)
            return null;
        
        return JsonSerializer.Deserialize<IEnumerable<T>>(modelsString);
    }

    public async Task SetAllCacheModelsAsync<T>(IEnumerable<T> models) where T : BaseModel {
        if (models is null)
            return;

        await _distributedCache.SetStringAsync(typeof(T).Name,
            JsonSerializer.Serialize(models),
            new DistributedCacheEntryOptions {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)
            }
        );
    }

    public async Task DeleteAllCacheModelsAsync<T>() where T : BaseModel {
        if (await _distributedCache.GetStringAsync(typeof(T).Name) is null)
            return;

        await _distributedCache.RemoveAsync(typeof(T).Name);
    }

    public async Task<T?> GetCacheModelAsync<T>(int id) where T : BaseModel {
        var modelString = await _distributedCache.GetStringAsync(typeof(T).Name + '_' + id.ToString());

        if (modelString is null)
            return null;

        return JsonSerializer.Deserialize<T>(modelString);
    }

    public async Task SetCacheModelAsync<T>(T model) where T : BaseModel {
        if (model is null)
            return;

        await _distributedCache.SetStringAsync(typeof(T).Name + '_' + model.Id.ToString(), 
            JsonSerializer.Serialize(model), 
            new DistributedCacheEntryOptions { 
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)
            }
        );
    }

    public async Task DeleteCacheModelAsync<T>(int id) where T : BaseModel {
        if (await _distributedCache.GetStringAsync(typeof(T).Name + '_' + id.ToString()) is null)
            return;

        await _distributedCache.RemoveAsync(typeof(T).Name + '_' + id.ToString());
    }

    public async Task UpdateCacheModelAsync<T>(int id, T model) where T : BaseModel {
        if(await GetCacheModelAsync<T>(id) is not null) 
            await DeleteCacheModelAsync<T>(id);

        await SetCacheModelAsync(model);
    }
}
