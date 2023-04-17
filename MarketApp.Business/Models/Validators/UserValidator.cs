using FluentValidation;
using MarketApp.DataAccess.Entities;

namespace MarketApp.Business.Models.Validators;

public class UserValidator : AbstractValidator<User> {
    public UserValidator() {
        RuleFor(x => x.Name).NotNull().WithName("ФИО").NotEmpty().MaximumLength(256).Matches(@"^[А-ЯЁа-яё\s\.]+$")
            .WithMessage("Фио должно быть на кириллице");
        RuleFor(x => x.Password).NotNull().WithName("Пароль").NotEmpty().MinimumLength(6).MaximumLength(16).Matches(@"^[a-z0-9_/-]{3,24}$")
            .WithMessage("Пароль должен содержать только латиницу или цифры");
        RuleFor(x => x.Role).NotNull().WithName("Роль").NotEmpty().Equals(typeof(Role));
    }
}