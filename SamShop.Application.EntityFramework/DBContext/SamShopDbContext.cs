using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Models.Entities;
using SamShop.Infrastructure.EntityFramework.Configurations;
using SamShop.Infrastructure.EntityFramework.Configurations.IdentityDataSeeder;

namespace SamShop.Infrastructure.EntityFramework.DBContext;

public partial class SamShopDbContext : IdentityDbContext<AppUser , AppRole, int>
{
    public SamShopDbContext()
    {
    }

    public SamShopDbContext(DbContextOptions<SamShopDbContext> options)
        : base(options)
    {
    }

    #region DataSets

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Auction> Auctions { get; set; }

    public virtual DbSet<AuctionOffer> AuctionOffers { get; set; }

    public virtual DbSet<CartProducts> CartProducts { get; set; }

    public virtual DbSet<Booth> Booths { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Medal> Medals { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    public virtual DbSet<Wage> Wages { get; set; }



    #endregion


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=SamShopDB;integrated security=sspi;TrustServerCertificate=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region configuration

        modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
        modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        modelBuilder.ApplyConfiguration(new AppUserAppRoleConfiguration());
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ApplyConfiguration(new AuctionConfiguration());
        modelBuilder.ApplyConfiguration(new AdminConfiguration());
        modelBuilder.ApplyConfiguration(new AuctionOfferConfiguration());
        modelBuilder.ApplyConfiguration(new BoothConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new CartConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new MedalConfiguration());
        modelBuilder.ApplyConfiguration(new PictureConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new SellerConfiguration());
        modelBuilder.ApplyConfiguration(new WageConfiguration());
        
       

        base.OnModelCreating(modelBuilder);
        #endregion
    }


}
