using Litera.Main.Models;
using Microsoft.EntityFrameworkCore;
using Litera.Main.Models.Dtos;

namespace Litera.Main.Infrastructure.Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("Litera");

        builder.Entity<AutorModel>();
        builder.Entity<CategoriaModel>();
        builder.Entity<ObraModel>(table =>
        {
            table
                .HasOne(autor => autor.Autor)
                .WithMany(obra => obra.Obras)
                .HasForeignKey(key => key.AutorId);
            table
                .HasOne(categoria => categoria.Categoria)
                .WithMany(obra => obra.Obras)
                .HasForeignKey(key => key.CategoriaId);
        });
    }

    public DbSet<AutorModel> Autores { get; set; }
    public DbSet<CategoriaModel> Categorias { get; set; }
    public DbSet<ObraModel> Obras { get; set; }

public DbSet<Litera.Main.Models.Dtos.ObraDto> ObraDto { get; set; } = default!;
}
