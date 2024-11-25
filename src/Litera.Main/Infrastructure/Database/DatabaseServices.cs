using Microsoft.EntityFrameworkCore;

namespace Litera.Main.Infrastructure.Database;

public static class DatabaseServices
{
    public static IServiceCollection AddDatabaseService(
        this IServiceCollection services,
        string? connectionString = null
    )
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            if (connectionString != null)
            {
                options.UseSqlServer(connectionString);
            }
            else
            {
                options.UseSqlite("Data source=LiteraDev.db");
            }
        });

        return services;
    }
}
