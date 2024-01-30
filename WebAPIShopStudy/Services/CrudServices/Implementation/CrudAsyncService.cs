using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPIShopStudy.Models.Entities;
using WebAPIShopStudy.Services.CrudService.Implementation;
using WebAPIShopStudy.Services.CrudService.Interfaces;
using WebAPIShopStudy.Services.CrudServices.Interfaces;

namespace WebAPIShopStudy.Services.CrudServices.Implementation;

public class CrudAsyncService<T> : CrudService<T>, ICrudAsyncService<T> where T : BaseModel{
    
    public CrudAsyncService(DbContext dbContext) : base(dbContext) {
    }


    public async Task<IEnumerable<T>?> GetAllAsync() {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id) {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate) {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public async Task AddAsync(T model) {
        if (model is null)
            return;

        await _dbSet.AddAsync(model);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, T model) {
        if (model is null || model.Id != id)
            return;

        model.Id = id;
        _dbSet.Entry(model).State = EntityState.Modified;

        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id) {
        var modelToRemove = _dbSet.FirstOrDefault(x => x.Id == id);

        if (modelToRemove is null)
            return;

        _dbSet.Remove(modelToRemove);
        await _dbContext.SaveChangesAsync();
    }

}
