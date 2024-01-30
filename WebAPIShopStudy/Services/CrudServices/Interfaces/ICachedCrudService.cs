using System.Linq.Expressions;
using WebAPIShopStudy.Models.Entities;
using WebAPIShopStudy.Services.CrudService.Interfaces;

namespace WebAPIShopStudy.Services.CrudServices.Interfaces;

public interface ICachedCrudService<T> : ICrudAsyncService<T> , ICrudService<T> where T : BaseModel{
    public Task<IEnumerable<T>?> GetAllCacheAsync();
    public Task<T?> GetByIdCacheAsync(int id);

    public Task AddCacheAsync(T model);
    public Task UpdateCacheAsync(int id, T model);
    public Task RemoveCacheAsync(int id);
}
