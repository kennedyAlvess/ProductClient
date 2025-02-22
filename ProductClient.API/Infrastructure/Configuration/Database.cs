using Microsoft.EntityFrameworkCore;
using ProductClient.API.Infrastructure.Repository;

namespace ProductClient.API.Infrastructure.Configuration;

public static class Configuration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDatabase()
                .AddRepository();

        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();
        if (configuration.GetConnectionString("DefaultConnection") != null)
        {
            services.AddDbContext<ProductClienteDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly("ProductClient.API"));
            });
        }

        return services;
    }

    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IClientProductsRepository, ClientProductsRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}
