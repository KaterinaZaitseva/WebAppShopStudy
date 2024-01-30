using WebAPIShopStudy.Models.Entities;

namespace WebAPIShopStudy.Services.CrudService.Interfaces;

public interface ICrudService<T> where T : BaseModel {
    public IEnumerable<T>? GetAll();
    public T? GetById(int id);
    public T? FirstOrDefault(Func<T, bool> predicate);

    public void Add(T model);
    public void Update(int id, T model);
    public void Remove(int id);
}