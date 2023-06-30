﻿using CarShop.Data_Access_Layer;
using DAL.Db;
using DAL.Models;
using DAL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extentions;

public static class ServiceCollectionExt
{
    public static IServiceCollection AddDALServices(this IServiceCollection services)
    {
        services.AddScoped<CarsDbContext>();
        services.AddScoped<IService<User>, UserService>();
        services.AddScoped<IService<Admin>, AdminService>();

        return services;
    }
}
