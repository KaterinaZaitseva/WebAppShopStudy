using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPIShopStudy.Models.Entities;
using WebAPIShopStudy.Services.CrudService.Interfaces;
using WebAPIShopStudy.Services.CrudServices.Interfaces;

namespace WebAPIShopStudy.Services.CrudService.Implementation;

public abstract class CrudService<T> : ICrudService<T>, ICrudAsyncService<T> where T : BaseModel {

    public CrudService(DbContext dbContext) {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }


    protected DbContext _dbContext;
    protected DbSet<T> _dbSet;


    public IEnumerable<T>? GetAll() {
        return _dbSet.ToList();
    }

    public async Task<IEnumerable<T>?> GetAllAsync() {
        return await _dbSet.ToListAsync();
    }


    public T? GetById(int id) {
        return _dbSet.Find(id);
    }

    public async Task<T?> GetByIdAsync(int id) {
        return await _dbSet.FindAsync(id);
    }


    public T? FirstOrDefault(Func<T, bool> predicate) {
        return FirstOrDefault(predicate);
    }

    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate) {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }


    public void Add(T entity) {
        if (entity is null)
            return;

        _dbSet.Add(entity);
        _dbContext.SaveChanges();
    }

    public async Task AddAsync(T entity) {
        if (entity is null)
            return;

        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }


    public void Update(int id, T entity) {
        if (entity is null || entity.Id != id)
            return;

        entity.Id = id;
       _dbSet.Entry(entity).State = EntityState.Modified;

        _dbContext.SaveChanges();
    }

    public async Task UpdateAsync(int id, T entity) {
        if (entity is null || entity.Id != id)
            return;

        entity.Id = id;
        _dbSet.Entry(entity).State = EntityState.Modified;

       await _dbContext.SaveChangesAsync();
    }


    public void Remove(int id) {
        var entityToRemove = _dbSet.FirstOrDefault(x => x.Id == id);

        if (entityToRemove is null)
            return;

        _dbSet.Remove(entityToRemove);
        _dbContext.SaveChanges();
    }

    public async Task RemoveAsync(int id) {
        var entityToRemove = _dbSet.FirstOrDefault(x => x.Id == id);

        if (entityToRemove is null)
            return;

        _dbSet.Remove(entityToRemove);
        await _dbContext.SaveChangesAsync();
    }

}
