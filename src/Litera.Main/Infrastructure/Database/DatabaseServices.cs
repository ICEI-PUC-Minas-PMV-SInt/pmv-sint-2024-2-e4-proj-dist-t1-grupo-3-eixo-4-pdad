using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Litera.Main.Infrastructure.Database;

public static class DatabaseServices
{
    public static IServiceCollection AddSqlServerDatabaseService(
        this IServiceCollection services,
        string? connectionString = null
    )
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        return services;
    }

    public static IServiceCollection AddSqliteDatabaseService(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite("Data source=Litera.db");
        });

        return services;
    }
}
