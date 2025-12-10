namespace ShoppingList.WebAPI.Settings;

public static class ShoppingListSettingsReader
{
    public static ShoppingListSettings Read(IConfiguration configuration)
    {
        return new ShoppingListSettings()
        {
            ShoppingListDbContextConnectionString = configuration.GetValue<string>("ShoppingListDbContext")
        };
    }
}