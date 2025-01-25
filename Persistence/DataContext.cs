global using Domain.Entities;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Persistence.Configurations;
using Core.Domain;

namespace Persistence;

public sealed class DataContext(DbContextOptions options) : IdentityDbContext<
    Account,
    AccountRole,
    string,
    IdentityUserClaim<string>, // TUserClaim
    AccountIdentityUserRole, // TUserRole,
    IdentityUserLogin<string>, // TUserLogin
    IdentityRoleClaim<string>, // TRoleClaim
    IdentityUserToken<string> // TUserToken
>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Identity tables
        modelBuilder.Entity<Account>().ToTable("AspNetUsers");
        modelBuilder.Entity<AccountIdentityUserRole>().ToTable("AspNetUserRoles");
        modelBuilder.Entity<AccountRole>().ToTable("AspNetRoles");
        modelBuilder.Entity<AccountIdentityUserRole>()
            .HasOne(p => p.User)
            .WithMany(b => b.Roles)
            .HasForeignKey(p => p.UserId);

        modelBuilder.Entity<AccountIdentityUserRole>()
            .HasOne(x => x.Role)
            .WithMany(x => x.Roles)
            .HasForeignKey(p => p.RoleId);

        // Configurations
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

    }

    public DbSet<Car>? Cars { get; set; }
    public DbSet<Owner>? Owners { get; set; }
    public DbSet<ServiceRecord>? ServiceRecords { get; set; }
    public DbSet<Inspection>? Inspections { get; set; }
    public DbSet<Booking>? Bookings { get; set; }
    public DbSet<ServiceCenter>? ServiceCenters { get; set; }
}
