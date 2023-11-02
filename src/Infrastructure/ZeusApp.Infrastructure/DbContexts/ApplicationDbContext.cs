using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Abstractions.Domain;
using AspNetCoreHero.EntityFrameworkCore.AuditTrail.Contexts;
using Microsoft.EntityFrameworkCore;
using ZeusApp.Application.Interfaces.Contexts;
using ZeusApp.Application.Interfaces.Shared;
using ZeusApp.Domain.Entities.Catalog;

namespace ZeusApp.Infrastructure.DbContexts;

public class ApplicationDbContext : AuditableContext, IApplicationDbContext
{
    private readonly IDateTimeService _dateTime;
    private readonly IAuthenticatedUserService _authenticatedUser;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
    {
        _dateTime = dateTime;
        _authenticatedUser = authenticatedUser;
    }

    public DbSet<Ayar> Ayarlar { get; set; }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }
    public DbSet<CustomerSupplier> CustomerSuppliers { get; set; }
    public DbSet<IndividualCustomerSupplier> IndividualCustomerSuppliers { get; set; }
    public DbSet<CorporateCustomerSupplier> CorporateCustomerSuppliers { get; set; }
    public DbSet<Bank> Banks { get; set; }
    public DbSet<OtherAddress> OtherAddresses { get; set; }
    public DbSet<RelatedPerson> RelatedPersons { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<CustomerCategory> CustomerCategories { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<StockIn> StockIns { get; set; }
    public DbSet<StockOut> StockOuts { get; set; }
    public DbSet<StockCategory> StockCategories { get; set; }
    public DbSet<ProductStock> ProductStocks { get; set; }
    public DbSet<ProductSalesInvoice> ProductSalesInvoices { get; set; }
    public DbSet<SalesInvoice> SalesInvoices { get; set; }
    public DbSet<SalesInvoiceCategory> SalesInvoiceCategories { get; set; }


    #region Connection
    public IDbConnection Connection => Database.GetDbConnection();
    public bool HasChanges => ChangeTracker.HasChanges();
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>().ToList())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedOn = _dateTime.NowUtc;
                    entry.Entity.CreatedBy = _authenticatedUser.UserId;
                    entry.Entity.Status = 1; // durum aktif olarak ekleniyor
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedOn = _dateTime.NowUtc;
                    entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
                    break;
            }
        }

        return _authenticatedUser.UserId == null
            ? await base.SaveChangesAsync(cancellationToken)
            : await base.SaveChangesAsync(_authenticatedUser.UserId);
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        {
            property.SetColumnType("decimal(18,8)");
        }

        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        builder.Entity<CustomerSupplier>().HasMany(x => x.RelatedPersons)
            .WithOne(x => x.CustomerSupplier)
            .HasForeignKey(x => x.CustomerSupplierId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<CustomerSupplier>().HasMany(x => x.OtherAddresses)
            .WithOne(x => x.CustomerSupplier)
            .HasForeignKey(x => x.CustomerSupplierId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<CustomerSupplier>().HasMany(x => x.Banks)
           .WithOne(x => x.CustomerSupplier)
           .HasForeignKey(x => x.CustomerSupplierId)
           .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<CustomerSupplier>().HasOne(x => x.Contact)
            .WithOne(x => x.CustomerSupplier)
            .HasForeignKey<Contact>(x => x.CustomerSupplierId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(builder);
    }
    #endregion
}
