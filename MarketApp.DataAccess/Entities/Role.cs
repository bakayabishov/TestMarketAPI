using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace MarketApp.DataAccess.Entities;
public enum Role { Administrator, Manager, Seller };

public class AuthorizedAttribute : AuthorizeAttribute {

    public AuthorizedAttribute(params Role[] roles) : base() {

        Roles = String.Join(",", Enum.GetNames(typeof(Role)));

    }
}

