using Microsoft.EntityFrameworkCore;

namespace Litera.Main.Infrastructure.Database;

public static class DatabaseServices
{
    public static IServiceCollection AddDevelopmentDatabaseService(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite("Data source=LiteraDev.db");
        });

        return services;
    }
}
