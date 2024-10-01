using System.ComponentModel.DataAnnotations;

namespace Litera.Main.Models;

public class ObraModel
{
    [Key]
    public int Id { get; set; }
    public required string Nome { get; set; }
    public DateTime DataLancamento { get; set; }
    public required string Idioma { get; set; }
    public int TotalPaginas { get; set; }

    [Required]
    public int AutorId { get; set; }
    public virtual AutorModel Autor { get; set; } = default!;

    [Required]
    public int CategoriaId { get; set; }
    public virtual CategoriaModel Categoria { get; set; } = default!;
}
