using ProductClient.API.Services.ClientProducts;
using ProductClient.API.Services.Clients;
using ProductClient.API.Services.Products;

namespace ProductClient.API;
public static class ApplicationModules
{
    public static IServiceCollection AddApplicationModules(this IServiceCollection services)
    {
        services.AddServices();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        //Cliente
        services.AddScoped<IUpdateClientServicie, UpdateClientServicie>();
        services.AddScoped<IGetClientService, BuscarClienteService>();
        services.AddScoped<IRegisterClientService, RegisterClientService>();
        services.AddScoped<IDeleteClientService, DeleteClientService>();
        services.AddScoped<IListAllClientsService, ListAllClientsService>();
        
        //ClientProducts
        services.AddScoped<IRefundProductService, refundProductService>();
        services.AddScoped<IInsertClientProductService, insertClientProductService>();
        services.AddScoped<IListClientSalesOrderService, ListClientSalesOrderService>();
        services.AddScoped<IRefundSalesOrderService, refundSalesOrderServiceService>();

        //Produto
        services.AddScoped<IGetProductService, BuscarProdutoService>();
        services.AddScoped<IRegisterProductService, RegisterProductService>();
        services.AddScoped<IDeleteProductService, DeleteProductService>();
        services.AddScoped<IListProductService, ListProductservice>();

        return services;
    }
}
