using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Supermarket.Domain.Entities;
using Supermarket.Domain.Enums;

namespace Supermarket.Data.Database;

public class SuperContext(DbContextOptions<SuperContext> options) : IdentityDbContext<AppUser>(options)
{
    // public SuperContext(DbContextOptions<SuperContext> options) : base(options) { }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductDiscount> ProductDiscounts { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // seed roles with fixed IDs to prevent ID refresh on migrations
        var roleEntities = new List<IdentityRole>();

        // Define fixed IDs for each role to ensure consistency across migrations
        var roleIdMap = new Dictionary<ApplicationRole, string>
        {
            { ApplicationRole.Admin, "6c33cde8-cdf1-4aca-a8f0-0ab43903000e" },
            { ApplicationRole.Moderator, "61926441-8fa0-4d2b-85a3-91a4ab95e2d0" },
            { ApplicationRole.Supervisor, "ec79da32-4d4d-48ae-be26-fbee5ec56f93" },
            { ApplicationRole.Employee, "fa174c70-8bff-4b6b-94a1-d567f8d0b3d4" },
            { ApplicationRole.Customer, "83f1e13a-0a0a-447c-9007-5e6a07676c0d" }
        };

        foreach (ApplicationRole role in Enum.GetValues(typeof(ApplicationRole)))
        {
            // Skip the 'None' role as it's not a real user role
            if (role == ApplicationRole.None) continue;

            roleEntities.Add(new IdentityRole
            {
                Id = roleIdMap[role],
                Name = role.ToString(),
                NormalizedName = role.ToString().ToUpper()
            });
        }

        builder.Entity<IdentityRole>().HasData(roleEntities);
    }
}