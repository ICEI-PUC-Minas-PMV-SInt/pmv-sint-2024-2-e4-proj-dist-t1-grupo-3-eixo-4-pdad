using System.Collections.Generic;
using System.Linq;
using Litera.Main.Models.Dtos;
using Litera.Main.Repositories;
using NuGet.ContentModel;
using NUnit.Framework;

namespace Litera.Test;

[TestFixture]
public class AutorTests
{
    private InMemoryAutor _repository;

    [SetUp]
    public void Setup()
    {
        _repository = new InMemoryAutor();
    }

    [Test]
    public void GetAll_ReturnsAllAutores()
    {
        // Act
        var result = _repository.GetAll();

        // Assert
        Assert.That(result, Has.Count.EqualTo(2));
        Assert.That(result.First().NomeCompleto, Is.EqualTo("José Luiz"));
    }

    [Test]
    public void Get_ReturnsAutorById()
    {
        // Act
        var result = _repository.Get(1);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.NomeCompleto, Is.EqualTo("José Luiz"));
    }

    [Test]
    public void Add_AddsAutor()
    {
        // Arrange
        var autor = new AutorDto
        {
            Id = 3,
            NomeCompleto = "Autor3",
            Biografia = "Biografia do Autor3",
            DataNascimento = new DateTime(1990, 1, 1),
            Nacionalidade = "Nacionalidade3",
        };

        // Act
        _repository.Add(autor);

        // Assert
        var result = _repository.Get(3);
        Assert.That(result, Is.Not.Null);
        Assert.That(result.NomeCompleto, Is.EqualTo("Autor3"));
    }

    [Test]
    public void Delete_RemovesAutor()
    {
        // Act
        _repository.Delete(1);

        // Assert
        var result = _repository.Get(1);
        Assert.That(result, Is.Null);
    }
}

[TestFixture]
public class CategoriaTests
{
    private InMemoryCategoria _repository;

    [SetUp]
    public void Setup()
    {
        _repository = new InMemoryCategoria();
    }

    [Test]
    public void GetAll_ReturnsAllCategorias()
    {
        // Act
        var result = _repository.GetAll();

        // Assert
        Assert.That(result, Has.Count.EqualTo(2));
        Assert.Multiple(() =>
        {
            Assert.That(result.First().Id, Is.EqualTo(1));
            Assert.That(result.First().Nome, Is.EqualTo("Aventura"));
        });
    }

    [Test]
    public void Get_ReturnsCategoriaById()
    {
        // Act
        var result = _repository.Get(2);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Nome, Is.EqualTo("Infantil"));
    }

    [Test]
    public void Add_AddsCategoria()
    {
        // Arrange
        var categoria = new CategoriaDto { Nome = "Terror" };

        // Act
        _repository.Add(categoria);

        // Assert
        var result = _repository.Get(3);
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Nome, Is.EqualTo("Terror"));
    }

    [Test]
    public void Delete_RemovesCategoria()
    {
        // Act
        _repository.Delete(1);

        // Assert
        var result = _repository.Get(1);
        Assert.That(result, Is.Null);
    }
}

[TestFixture]
public class ObraTests
{
    private InMemoryObra _repository;

    [SetUp]
    public void Setup()
    {
        _repository = new InMemoryObra();
    }

    [Test]
    public void GetAll_ReturnsAllObras()
    {
        // Act
        var result = _repository.GetAll();

        // Assert
        Assert.That(result, Has.Count.EqualTo(2));
        Assert.Multiple(() =>
        {
            Assert.That(result.First().Id, Is.EqualTo(1));
            Assert.That(result.First().Nome, Is.Not.EqualTo("Las Mazanas del Paraguay"));
            Assert.That(result.First().TotalPaginas, Is.LessThan(30));
            Assert.That(result.First().Autor.NomeCompleto, Is.EqualTo("José Luis"));
            Assert.That(result.First().Categoria.Nome, Is.EqualTo("Infantil"));
        });
    }

    [Test]
    public void Get_ReturnsObraById()
    {
        // Act
        var result = _repository.Get(1);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Nome, Is.EqualTo("Os Aviõezinhos"));
    }

    [Test]
    public void Add_AddsObra()
    {
        // Arrange
        var obra = new ObraDto
        {
            Id = 3,
            Nome = "Gatos listrados",
            TotalPaginas = 50,
            DataLancamento = new DateTime(2013, 1, 2),
            Idioma = "Japonês",
            Autor = new AutorDto { Id = 1, NomeCompleto = "José Luis" },
            Categoria = new CategoriaDto { Id = 1, Nome = "Aventura" },
        };

        // Act
        _repository.Add(obra);

        // Assert
        var result = _repository.Get(3);
        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Nome, Is.EqualTo("Gatos listrados"));
            Assert.That(result.TotalPaginas, Is.GreaterThan(40));
            Assert.That(result.Idioma, Is.Not.EqualTo("Chinês"));
            Assert.That(result.Autor, Is.Not.Null);
            Assert.That(result.Autor.NomeCompleto, Is.EqualTo("José Luis"));
            Assert.That(result.Categoria, Is.Not.Null);
            Assert.That(result.Categoria.Nome, Is.Not.EqualTo("Infantil"));
        });
    }

    [Test]
    public void Delete_RemovesObra()
    {
        // Act
        _repository.Delete(1);

        // Assert
        var result = _repository.Get(1);
        Assert.That(result, Is.Null);
    }
}
