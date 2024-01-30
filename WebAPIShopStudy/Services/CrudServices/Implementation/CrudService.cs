using Microsoft.EntityFrameworkCore;
using WebAPIShopStudy.Models.Entities;
using WebAPIShopStudy.Services.CrudService.Interfaces;

namespace WebAPIShopStudy.Services.CrudService.Implementation;

public abstract class CrudService<T> : ICrudService<T> where T : BaseModel {

    public CrudService(DbContext dbContext) {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }


    protected DbContext _dbContext;
    protected DbSet<T> _dbSet;


    public IEnumerable<T>? GetAll() {
        return _dbSet.ToList();
    }

    public T? GetById(int id) {
        return _dbSet.Find(id);
    }

    public T? FirstOrDefault(Func<T, bool> predicate) {
        return FirstOrDefault(predicate);
    }

    public void Add(T model) {
        if (model is null)
            return;

        _dbSet.Add(model);
        _dbContext.SaveChanges();
    }
   
    public void Update(int id, T model) {
        if (model is null || model.Id != id)
            return;

        model.Id = id;
       _dbSet.Entry(model).State = EntityState.Modified;

        _dbContext.SaveChanges();
    }

    public void Remove(int id) {
        var modelToRemove = _dbSet.FirstOrDefault(x => x.Id == id);

        if (modelToRemove is null)
            return;

        _dbSet.Remove(modelToRemove);
        _dbContext.SaveChanges();
    }

}
