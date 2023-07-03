using BLL.Helpers.PasswordHasher;
using BLL.Services.PaymentSystem;
using BLL.Services.SearchingServices;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extentions;

public static class ServiceCollectionExt
{
    public static IServiceCollection AddBLLServices(this IServiceCollection services)
    {
        //services.AddScoped<IOrderService, OrderService>();
        //services.AddScoped<PaymentSystem>();
        services.AddScoped<IPasswordHash, PasswordHash>();
        services.AddScoped<SearchingUserService>();
        services.AddScoped<SearchingAdminService>();

        return services;
    }
}
