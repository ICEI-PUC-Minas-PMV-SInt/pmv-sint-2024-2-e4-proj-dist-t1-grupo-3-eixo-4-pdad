namespace Litera.Main.Models.Dtos;

public class ObraDto
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public DateTime DataLancamento { get; set; }
    public required string Idioma { get; set; }
    public int TotalPaginas { get; set; }

    //

    public AutorDto Autor { get; set; }
    public CategoriaDto Categoria { get; set; }
}
