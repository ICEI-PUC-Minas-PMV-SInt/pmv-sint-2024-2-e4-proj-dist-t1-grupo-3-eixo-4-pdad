namespace Litera.Main.Repositories;

public interface ILiteraRepository<T>
{
    void Add(T item);
    void Delete(int id);
    T? Get(int id);
    void Update(T item);
    void Dispose();
    void Save();
}
