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
        
        // seed roles
        var roles = Enum.GetValues(typeof(ApplicationRole));
        var roleEntities = new List<IdentityRole>();

        foreach (ApplicationRole role in roles)
        {
            roleEntities.Add(new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = role.ToString(),
                NormalizedName = role.ToString().ToUpper()
            });
        }

        builder.Entity<IdentityRole>().HasData(roleEntities);
    }
}