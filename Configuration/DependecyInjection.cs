using ShopeeAPI.Modules.Owners.Repositories;
using ShopeeAPI.Modules.Owners.Services;
using ShopeeAPI.Modules.Stores.Repositories;
using ShopeeAPI.Modules.Stores.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IOwnerRepository, OwnerRepository>();
        services.AddScoped<IOwnerService, OwnerService>();

        services.AddScoped<IStoreRepository, StoreRepository>();
        services.AddScoped<IStoreService, StoreService>();

        return services;
    }
}