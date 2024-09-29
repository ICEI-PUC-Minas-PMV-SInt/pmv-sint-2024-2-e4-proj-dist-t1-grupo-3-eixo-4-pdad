using Litera.Main.Infrastructure.Database;
using Litera.Main.Models;

namespace Litera.Main.Repositories;

public class AutorRepository(ApplicationDbContext context) : ILiteraRepository<AutorModel>
{
    private readonly ApplicationDbContext _context = context;

    public ICollection<AutorModel> GetAll()
    {
        return _context.Autores.ToList();
    }

    public AutorModel? Get(int id) => _context.Autores.FirstOrDefault(autor => autor.Id == id);

    public void Add(AutorModel autor)
    {
        _context.Autores.Add(autor);
    }

    public void Delete(int id)
    {
        var autor = Get(id);

        if (autor is null)
        {
            return;
        }

        _context.Autores.Remove(autor);
    }

    public void Update(AutorModel autor)
    {
        _context.Entry(autor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public static implicit operator AutorRepository(InMemoryAutor v)
    {
        throw new NotImplementedException();
    }
}
