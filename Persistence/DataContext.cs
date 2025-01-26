global using Domain.Entities;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Persistence.Configurations;
using Core.Domain;
using Domain.Entities.JointTables;

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

        // CarOwner relationship configuration (if needed)
        modelBuilder.Entity<CarOwner>()
            .HasKey(co => new { co.CarId, co.OwnerId }); // Composite key

        modelBuilder.Entity<CarOwner>()
            .HasOne(co => co.Car)
            .WithMany(c => c.CarOwners)
            .HasForeignKey(co => co.CarId);

        modelBuilder.Entity<CarOwner>()
            .HasOne(co => co.Owner)
            .WithMany(o => o.CarOwners)
            .HasForeignKey(co => co.OwnerId);
    }

    public DbSet<Car>? Cars { get; set; }
    public DbSet<Owner>? Owners { get; set; }
    public DbSet<ServiceRecord>? ServiceRecords { get; set; }
    public DbSet<Inspection>? Inspections { get; set; }
    public DbSet<Booking>? Bookings { get; set; }
    public DbSet<ServiceCenter>? ServiceCenters { get; set; }
    public DbSet<CarOwner>? CarOwners { get; set; } // New DbSet for CarOwner
}
