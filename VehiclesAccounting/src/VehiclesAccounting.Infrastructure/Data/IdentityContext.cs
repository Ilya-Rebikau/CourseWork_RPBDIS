using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VehiclesAccounting.Core.ProjectAggregate;

namespace VehiclesAccounting.Infrastructure.Data;

/// <summary>
/// Context for identity
/// </summary>
public class IdentityContext : IdentityDbContext<User>
{
    /// <summary>
    /// Constructor of class
    /// </summary>
    /// <param name="options">DbContextOptions object</param>
    public IdentityContext(DbContextOptions<IdentityContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
}
