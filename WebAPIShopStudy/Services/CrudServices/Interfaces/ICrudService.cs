using WebAPIShopStudy.Models.Entities;

namespace WebAPIShopStudy.Services.CrudService.Interfaces;

public interface ICrudService<T> where T : BaseModel {
    public IEnumerable<T>? GetAll();
    public T? GetById(int id);
    public T? FirstOrDefault(Func<T, bool> predicate);

    public void Add(T entity);
    public void Update(int id, T entity);
    public void Remove(int id);
}