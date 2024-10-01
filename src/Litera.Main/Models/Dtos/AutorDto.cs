namespace Litera.Main.Models.Dtos;

public partial class AutorDto
{
    public int Id { get; set; }
    public required string NomeCompleto { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Nacionalidade { get; set; } = null!;
    public string Biografia { get; set; } = string.Empty;

    //

    public virtual ICollection<ObraDto> Obras { get; set; }
}
