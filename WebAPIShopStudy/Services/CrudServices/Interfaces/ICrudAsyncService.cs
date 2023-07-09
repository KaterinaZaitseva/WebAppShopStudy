using System.Linq.Expressions;
using WebAPIShopStudy.Models.Entities;

namespace WebAPIShopStudy.Services.CrudServices.Interfaces;

public interface ICrudAsyncService<T> where T : BaseModel {
    public Task<IEnumerable<T>?> GetAllAsync();
    public Task<T?> GetByIdAsync(int id);
    public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

    public Task AddAsync(T entity);
    public Task UpdateAsync(int id, T entity);
    public Task RemoveAsync(int id);
}
