using ShoppingList.WebAPI.Settings;
using Microsoft.EntityFrameworkCore;
using ShoppingList.DataAccess;

namespace ShoppingList.WebAPI.IoC;

public static class DbContextConfigurator
{
    public static void ConfigureService(IServiceCollection services, ShoppingListSettings settings)
    {
        services.AddDbContextFactory<ShoppingListDbContext>(
            options => { options.UseNpgsql(settings.ShoppingListDbContextConnectionString); }, 
            ServiceLifetime.Scoped);
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<ShoppingListDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate(); //makes last migrations to db and creates database if it doesn't exist
    }
}