using BLL.Helpers.EmailValidation;
using BLL.Helpers.PasswordHasher;
using BLL.Helpers.PasswordValidation;
using BLL.Services.ChangePasswordServices;
using BLL.Services.PaymentSystem;
using BLL.Services.SearchingServices;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extentions;

public static class ServiceCollectionExt
{
    public static IServiceCollection AddBLLServices(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHash, PasswordHash>();
        services.AddScoped<SearchingUserService>();
        services.AddScoped<SearchingAdminService>();
        services.AddScoped<ChangeAdminPasswordService>();
        services.AddScoped<ChangeUserPasswordService>();

        return services;
    }
}
