using Microsoft.Extensions.Caching.Distributed;
using WebAPIShopStudy.Models.Entities;
using WebAPIShopStudy.Services.CrudServices.Interfaces;

namespace WebAPIShopStudy.Services.CachedServices;

public interface ICachedService {
    public Task<IEnumerable<T>?> GetAllCacheModelsAsync<T>() where T : BaseModel;
    public Task SetAllCacheModelsAsync<T>(IEnumerable<T> models) where T : BaseModel;
    public Task DeleteAllCacheModelsAsync<T>() where T : BaseModel;

    public Task<T?> GetCacheModelAsync<T>(int id) where T : BaseModel;
    public Task SetCacheModelAsync<T>(T model) where T : BaseModel;
    public Task DeleteCacheModelAsync<T>(int id) where T : BaseModel;
    public Task UpdateCacheModelAsync<T>(int id, T model) where T : BaseModel;
}
