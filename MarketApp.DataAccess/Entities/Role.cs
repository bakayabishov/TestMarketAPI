using System.ComponentModel.DataAnnotations;

namespace MarketApp.DataAccess.Entities;

public enum Roles {

    [Display(Name = "Администратор")]
    Administrator = 1,

    [Display(Name = "Менеджер")]
    Manager = 2,

    [Display(Name = "Продавец")]
    Seller = 3
}