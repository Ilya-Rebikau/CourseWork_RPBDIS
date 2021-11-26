using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Infrastructure.Data;
/// <summary>
/// Initializer of roles in database
/// </summary>
public class RoleInitializer
{
    /// <summary>
    /// Initialize base roles for admin and moder
    /// Create admin account
    /// </summary>
    /// <param name="context">DbContext object</param>
    /// <returns>Task</returns>
    public static async Task Initialize(HttpContext context)
    {
        UserManager<User> userManager = context.RequestServices.GetRequiredService<UserManager<User>>();
        RoleManager<IdentityRole> roleManager = context.RequestServices.GetRequiredService<RoleManager<IdentityRole>>();
        string adminName = "admin";
        string password = "Qwer!1";
        if (await roleManager.FindByNameAsync("admin") == null)
        {
            await roleManager.CreateAsync(new IdentityRole("admin"));
        }
        if (await roleManager.FindByNameAsync("moder") == null)
        {
            await roleManager.CreateAsync(new IdentityRole("moder"));
        }
        if (await userManager.FindByNameAsync(adminName) == null)
        {
            User admin = new()
            {
                UserName = adminName
            };
            IdentityResult result = await userManager.CreateAsync(admin, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "admin");
            }
        }
    }
}
