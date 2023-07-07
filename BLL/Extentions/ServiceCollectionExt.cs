using BLL.Helpers.EmailValidation;
using BLL.Helpers.PasswordHasher;
using BLL.Helpers.PasswordValidation;
using BLL.Services.ChangePasswordServices;
using BLL.Services.DTOService;
using BLL.Services.PaymentSystem;
using BLL.Services.SearchingServices;
using DAL.Db;
using DAL.Models.ModelsDTO;
using DAL.Services;
using DAL.Services.SortingServices;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extentions;

public static class ServiceCollectionExt
{
    public static IServiceCollection AddBLLServices(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHash, PasswordHash>();
        services.AddScoped<IService<OrderDTO>, OrderDTOService>();
        services.AddScoped<IService<CarPhotoDTO>, CarPhotoDTOService>();
        services.AddScoped<SearchingUserService>();
        services.AddScoped<SearchingAdminService>();
        services.AddScoped<SearchingCarService>();
        services.AddScoped<SearchingOrderService>();
        services.AddScoped<ChangeAdminPasswordService>();
        services.AddScoped<ChangeUserPasswordService>();
        services.AddScoped<SortCarsService>();

        return services;
    }
}
