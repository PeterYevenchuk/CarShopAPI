﻿using BLL.Helpers.PasswordHasher;
using BLL.services.DeliveryOrder;
using BLL.services.DeliveryOrderProces;
using BLL.Services.PaymentSystem;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extentions;

public static class ServiceCollectionExt
{
    public static IServiceCollection AddBLLServices(this IServiceCollection services)
    {
        //services.AddScoped<IOrderService, OrderService>();
        //services.AddScoped<PaymentSystem>();
        //services.AddScoped<IPasswordHash, PasswordHash>();

        return services;
    }
}
