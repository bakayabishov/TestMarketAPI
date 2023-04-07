#nullable enable
using MarketApp.Business.Interfaces;
using MarketApp.Business.Models.Validators;
using MarketApp.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using IUnitOfWork = MarketApp.Business.UnitOfWork.IUnitOfWork;

namespace MarketApp.Business; 

public static class ServicesDiRegistration {
    public static void AddServices(
        this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        services.AddScoped<IUsersServices, UsersServices>();
        services.AddValidators();
    }
}