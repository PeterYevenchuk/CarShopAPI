using BLL.Helpers.EmailValidation;
using BLL.Helpers.PasswordHasher;
using BLL.Helpers.PasswordValidation;
using BLL.Services.ChangePasswordServices;
using BLL.Services.DTOService;
using BLL.Services.NotificationServices;
using BLL.Services.PaymentSystem;
using BLL.Services.SearchingServices;
using CarShop.BLL.Services.BasicServices;
using DAL.Db;
using DAL.Models;
using DAL.Models.ModelsDTO;
using DAL.Services;
using DAL.Services.SortingServices;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extentions;

public static class ServiceCollectionExt
{
    public static IServiceCollection AddBLLServices(this IServiceCollection services)
    {
        services.AddScoped<IService<User>, UserService>();
        services.AddScoped<IService<Car>, CarService>();
        services.AddScoped<IService<Order>, OrderService>();
        services.AddScoped<IService<CarPhoto>, CarPhotoService>();
        services.AddScoped<IService<AddFuncPrice>, AddFuncPriceService>();
        services.AddScoped<IPaymentStrategy, CreditCardPaymentStrategy>();
        services.AddScoped<IPaymentStrategy, PayPalPaymentStrategy>();
        services.AddScoped<IPasswordHash, PasswordHash>();
        services.AddScoped<IService<AddFuncPriceDTO>, AddFuncPriceDTOService>();
        services.AddScoped<IService<OrderDTO>, OrderDTOService>();
        services.AddScoped<IService<CarPhotoDTO>, CarPhotoDTOService>();
        services.AddScoped<SearchingUserService>();
        services.AddScoped<SearchingCarService>();
        services.AddScoped<SearchingOrderService>();
        services.AddScoped<ChangeUserPasswordService>();
        services.AddScoped<SortCarsService>();
        services.AddScoped<EmailService>();
        services.AddScoped<AuthService>();

        return services;
    }
}
