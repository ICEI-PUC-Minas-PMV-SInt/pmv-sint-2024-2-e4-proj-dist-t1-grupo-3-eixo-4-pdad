using Microsoft.EntityFrameworkCore;
using todoz.api.Models;

namespace todoz.api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        // Tabelas que serão criadas ao criar a conexão com o banco
        public DbSet<AutorModel> Autores { get; set; }
    }
}
