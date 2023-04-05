#nullable enable
using MarketApp.Business.Interfaces;
using MarketApp.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using TestAPIMarket.Data.Repositories.Interfaces;

namespace MarketApp.Business; 

public static class ServicesDiRegistration {
    public static void AddServices(
        this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

        services.AddScoped<IUsersServices, UsersServices>();
    }
}