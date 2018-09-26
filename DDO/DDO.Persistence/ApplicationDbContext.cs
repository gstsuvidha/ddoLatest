
using DDO.Domain.Accounting;
using DDO.Domain.AdminModule;
using DDO.Domain.SupplierModule;
using DDO.Domain.TdsModule;
using Microsoft.EntityFrameworkCore;

namespace DDO.Persistence
{
    public class ApplicationDbContext : DbContext
    {
    
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base((DbContextOptions)options)

        {
        }
        public DbSet<Tds> Tdss {get; set;}
         public DbSet<AccountingUnit> AccountingUnits { get; set; }
         public DbSet<Supplier> Suppliers { get; set; }
         public DbSet<Admin> Admins { get; set; }
         
       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           modelBuilder.Entity<AccountingUnit>()
                .HasOne(fk => fk.Admin)
                .WithMany(p => p.AccountingUnits)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Supplier>()
                .HasOne(fk => fk.Admin)
                .WithMany(p => p.Suppliers)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tds>()
                .HasOne(fk => fk.Admin)
                .WithMany(p => p.Tdss)
                .OnDelete(DeleteBehavior.Restrict);        

            base.OnModelCreating(modelBuilder);    
       }
    }
}