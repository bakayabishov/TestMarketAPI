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

public class Role
{
    public const string Administrator = "administrator";
    public const string Manager = "manager";
    public const string Saller = "seller";

}