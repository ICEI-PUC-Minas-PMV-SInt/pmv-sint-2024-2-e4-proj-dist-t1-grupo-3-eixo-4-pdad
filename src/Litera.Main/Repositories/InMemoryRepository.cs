using Litera.Main.Models;
using Litera.Main.Models.Dtos;
using Litera.Main.Repositories;

namespace Litera.Main.Repositories;

public class InMemoryAutor : ILiteraRepository<AutorDto>
{
    private List<AutorDto>? Autores { get; }
    private int nextId = 3;

    public InMemoryAutor()
    {
        Autores =
        [
            new AutorDto
            {
                Id = 1,
                NomeCompleto = "José Luiz",
                Biografia = "Uma biografia bem legal",
                DataNascimento = new DateTime(1987, 9, 18),
                Nacionalidade = "Brasileiro",
            },
            new AutorDto
            {
                Id = 2,
                NomeCompleto = "Maria da Graça",
                Biografia = "Uma biografia suuuuper interessante",
                DataNascimento = new DateTime(1964, 5, 31),
            },
        ];
    }

    public List<AutorDto>? GetAll() => Autores;

    public AutorDto? Get(int id) => Autores?.FirstOrDefault(autor => autor.Id == id);

    public void Add(AutorDto autor)
    {
        autor.Id = nextId++;

        Autores?.Add(autor);
    }

    public void Delete(int id)
    {
        var autor = Get(id);
        if (autor is null)
        {
            return;
        }

        Autores?.Remove(autor);
    }

    public void Update(AutorDto autor)
    {
        var index = Autores?.FindIndex(x => x.Id == autor.Id);

        if (Autores != null && index != null && index != -1)
        {
            Autores[(int)index] = autor;
        }
        else
        {
            return;
        }
    }

    public void Dispose() { }

    public void Save() { }
}

public class InMemoryCategoria : ILiteraRepository<CategoriaDto>
{
    private List<CategoriaDto>? Categorias { get; }
    private int nextId = 3;

    public InMemoryCategoria()
    {
        Categorias =
        [
            new CategoriaDto { Id = 1, Nome = "Aventura" },
            new CategoriaDto { Id = 2, Nome = "Infantil" },
        ];
    }

    public List<CategoriaDto>? GetAll() => Categorias;

    public CategoriaDto? Get(int id) => Categorias?.FirstOrDefault(categoria => categoria.Id == id);

    public void Add(CategoriaDto categoria)
    {
        categoria.Id = nextId++;

        Categorias?.Add(categoria);
    }

    public void Delete(int id)
    {
        var categoria = Get(id);
        if (categoria is null)
        {
            return;
        }

        Categorias?.Remove(categoria);
    }

    public void Update(CategoriaDto categoria)
    {
        var index = Categorias?.FindIndex(x => x.Id == categoria.Id);

        if (Categorias != null && index != null && index != -1)
        {
            Categorias[(int)index] = categoria;
        }
        else
        {
            return;
        }
    }

    public void Dispose() { }

    public void Save() { }
}

public class InMemoryObra : ILiteraRepository<ObraDto>
{
    private List<ObraDto>? Obras { get; }
    private int nextId = 3;

    public InMemoryObra()
    {
        Obras =
        [
            new ObraDto
            {
                Id = 1,
                Nome = "Os Aviõezinhos",
                Idioma = "Português",
                DataLancamento = new DateTime(2023, 11, 11),
                TotalPaginas = 27,
                Autor = new AutorDto { Id = 1, NomeCompleto = "José Luis" },
                Categoria = new CategoriaDto { Id = 2, Nome = "Infantil" },
            },
            new ObraDto
            {
                Id = 2,
                Nome = "Las Mazanas del Paraguay",
                Idioma = "Espanhol",
                DataLancamento = new DateTime(1979, 2, 6),
                TotalPaginas = 342,
                Autor = new AutorDto { Id = 2, NomeCompleto = "Maria da Graça" },
                Categoria = new CategoriaDto { Id = 1, Nome = "Aventura" },
            },
        ];
    }

    public List<ObraDto>? GetAll() => Obras;

    public ObraDto? Get(int id) => Obras?.FirstOrDefault(obra => obra.Id == id);

    public void Add(ObraDto obra)
    {
        obra.Id = nextId++;

        Obras?.Add(obra);
    }

    public void Delete(int id)
    {
        var obra = Get(id);
        if (obra is null)
        {
            return;
        }

        Obras?.Remove(obra);
    }

    public void Update(ObraDto obra)
    {
        var index = Obras?.FindIndex(x => x.Id == obra.Id);

        if (Obras != null && index != null && index != -1)
        {
            Obras[(int)index] = obra;
        }
        else
        {
            return;
        }
    }

    public void Dispose() { }

    public void Save() { }
}
