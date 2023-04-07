using FluentValidation;
using MarketApp.DataAccess.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace MarketApp.Business.Models.Validators;

public static class RegisterValidators {
    public static void AddValidators(this IServiceCollection services) {
        services.AddScoped<IValidator<User>, UserValidator>();
    }
}