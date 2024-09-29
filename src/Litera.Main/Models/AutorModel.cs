using System.ComponentModel.DataAnnotations;

namespace Litera.Main.Models;

public class AutorModel
{
    [Key]
    public int Id { get; set; }
    public required string NomeCompleto { get; set; }
    public DateTime DataNascimento { get; set; }
    public required string Nacionalidade { get; set; }
    public string Biografia { get; set; } = string.Empty;

    //

    public virtual ICollection<ObraModel> Obras { get; set; } = [];
}