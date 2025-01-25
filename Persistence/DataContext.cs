using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;
using Contract; // Proveri da li ti treba custom namespace.
using Services.Abstractions;
using Domain.Entities;
using Domain.Repositories;


namespace Persistence;

public sealed class DataContext : IdentityDbContext<
    Account,
    AccountRole,
    string,
    IdentityUserClaim<string>,
    AccountIdentityUserRole,
    IdentityUserLogin<string>,
    IdentityRoleClaim<string>,
    IdentityUserToken<string>
>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Mapiranje tabela za Identity
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

        // Primena konfiguracija
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

        // Dodatne Fluent API konfiguracije po potrebi
    }

    // DbSet-ovi za tvoje entitete
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<ServiceRecord> ServiceRecords { get; set; }
    public DbSet<Inspection> Inspections { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
}