using System.ComponentModel.DataAnnotations;

namespace Litera.Main.Models;

public class CategoriaModel
{
    [Key]
    public int Id { get; set; }
    public required string Nome { get; set; }

    //

    public virtual ICollection<ObraModel> Obras { get; set; } = [];
}
