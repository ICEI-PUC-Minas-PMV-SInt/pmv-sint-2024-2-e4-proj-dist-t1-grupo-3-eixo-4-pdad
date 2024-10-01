namespace Litera.Main.Models.Dtos;

public class CategoriaDto {
    public int Id { get; set; }
    public required string Nome { get; set; }

    //

    public ICollection<ObraDto> Obras { get; set; }
}