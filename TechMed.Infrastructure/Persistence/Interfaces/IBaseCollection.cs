namespace TechMed.Infrastructure.Persistence.Interfaces;

public interface IBaseCollection<T>
{
    int Create(T obj);
    void Update(int id, T obj);
    void Delete(int id);
    T? GetById(int id);
    ICollection<T> GetAll();
    
}
