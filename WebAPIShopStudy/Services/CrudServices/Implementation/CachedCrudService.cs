using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPIShopStudy.Models.Entities;
using WebAPIShopStudy.Services.CrudService.Implementation;
using WebAPIShopStudy.Services.CrudServices.Interfaces;
using WebAPIShopStudy.Services.CachedServices;
using WebAPIShopStudy.Services.CrudService.Interfaces;

namespace WebAPIShopStudy.Services.CrudServices.Implementation;

public class CachedCrudService<T> : CrudAsyncService<T>, ICachedCrudService<T> where T : BaseModel {
    
    public CachedCrudService(DbContext dbContext, 
        ICachedService cachedService) : base(dbContext) {
        _cachedService = cachedService;
    }


    private readonly ICachedService _cachedService;


    public async Task<IEnumerable<T>?> GetAllCacheAsync() {
        var models = await _cachedService.GetAllCacheModelsAsync<T>();

        if (models is null) {
            models = await GetAllAsync();

            if (models is null) 
                return null;
                
            await _cachedService.SetAllCacheModelsAsync<T>(models);
        }

        return models;
    }

    public async Task<T?> GetByIdCacheAsync(int id) {
        T? model = await _cachedService.GetCacheModelAsync<T>(id);

        if (model is null) {
            model = await GetByIdAsync(id);

            if (model is null)
                return null;

            await _cachedService.SetCacheModelAsync<T>(model);
        }

        return model;
    }

    public async Task AddCacheAsync(T model) {
        await AddAsync(model);

        await _cachedService.SetCacheModelAsync<T>(model);

        await _cachedService.DeleteAllCacheModelsAsync<T>();
        await _cachedService.SetAllCacheModelsAsync<T>(await GetAllAsync());
    }

    public async Task RemoveCacheAsync(int id) {
        await RemoveAsync(id);

        await _cachedService.DeleteCacheModelAsync<T>(id);

        await _cachedService.DeleteAllCacheModelsAsync<T>();
        await _cachedService.SetAllCacheModelsAsync<T>(await GetAllAsync());
    }

    public async Task UpdateCacheAsync(int id, T model) {
        if (model is null || model.Id != id)
            return;

        await UpdateAsync(id, model);
        
        T? modelByUpdate = await _cachedService.GetCacheModelAsync<T>(id);

        if (modelByUpdate is not null)
            await _cachedService.UpdateCacheModelAsync<T>(id, modelByUpdate);
        else
            await _cachedService.SetCacheModelAsync<T>(model);

        await _cachedService.DeleteAllCacheModelsAsync<T>();
        await _cachedService.SetAllCacheModelsAsync<T>(await GetAllAsync());
    }

}
