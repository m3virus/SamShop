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

    public virtual DbSet<AddressCustomer> AddressCustomers { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Auction> Auctions { get; set; }

    public virtual DbSet<AuctionOffer> AuctionOffers { get; set; }

    public virtual DbSet<Booth> Booths { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Medal> Medals { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCart> ProductCarts { get; set; }

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
        modelBuilder.ApplyConfiguration(new AddressCustomerConfiguration());
        modelBuilder.ApplyConfiguration(new AuctionOfferConfiguration());
        modelBuilder.ApplyConfiguration(new BoothConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new CartConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfiguration(new MedalConfiguration());
        modelBuilder.ApplyConfiguration(new PictureConfiguration());
        modelBuilder.ApplyConfiguration(new ProductCartConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new SellerConfiguration());
        modelBuilder.ApplyConfiguration(new WageConfiguration());
        
       

        base.OnModelCreating(modelBuilder);
        #endregion
    }




    #region Dataseeder



    //private List<Admin> GetAdmins()
    //{
    //    return Enumerable.Range(1, 2).Select(index => new Admin
    //    {
    //        AdminId = index,
    //        UserName = $"StringSample {index}",
    //        AddressId = index,
    //        PictureId = null,
    //        FirstName = $"StringSample {index}",
    //        LastName = $"StringSample {index}",
    //        Wallet = index * 100,
    //        Password = $"StringSample {index}",
    //        Email = $"StringSample {index}@google.com",
    //        Phone = $"StringSample {index}",
    //        IsDeleted = false,
    //    }).ToList();
    //}

    //private List<Seller> GetSellers()
    //{
    //    return Enumerable.Range(1, 10).Select(index => new Seller
    //    {
    //        SellerId = index,
    //        UserName = $"SellerSample {index}",
    //        FirstName = $"SellerSample {index}",
    //        LastName = $"SellerSample {index}",
    //        Wallet = index * 100,
    //        Password = $"SellerSample {index}",
    //        Email = $"SellerSample {index}",
    //        Phone = $"SellerSample {index}",
    //        BoothId = index,
    //        MedalId = 1,
    //        PictureId = null,
    //        AddressId = index + 2,
    //        IsDeleted = false,
    //    }).ToList();

    //}

    //private List<Customer> GetCustomer()
    //{
    //    return Enumerable.Range(1, 30).Select(index => new Customer
    //    {
    //        CustomerId = index,
    //        UserName = $"CustomerSample {index}",
    //        FirstName = $"CustomerSample {index}",
    //        LastName = $"CustomerSample {index}",
    //        Wallet = index * 100,
    //        PasswordHash = $"CustomerSample {index}",
    //        Email = $"CustomerSample {index}",
    //        Phone = $"CustomerSample {index}",
    //        PictureId = null,
    //        AddressId = index + 12,
    //        IsDeleted = false,
    //    }).ToList();

    //}

    //private List<Auction> GetAuctions()
    //{
    //    return Enumerable.Range(1, 1).Select(index => new Auction
    //    {
    //        AuctionId = index,
    //        ProductId = index,
    //        AuctionTitle = $"AuctionSample {index}",
    //        TheLowestOffer = index * 10,
    //        SellerId = index,
    //        IsAccepted = false,
    //        IsCanceled = false,
    //        StartTime = DateTime.Now,
    //        EndTime = DateTime.Today,

    //    }).ToList();

    //}

    //private List<AuctionOffer> GetAuctionOffers()
    //{
    //    return Enumerable.Range(1, 3).Select(index => new AuctionOffer
    //    {
    //        OfferId = index,
    //        AuctionId = 1,
    //        OfferValue = index * 11,
    //        CustomerId = index,
    //        IsCanceled = false,
    //        IsAccept = false,


    //    }).ToList();

    //}

    //private List<Booth> GetBooth()
    //{
    //    return Enumerable.Range(1, 10).Select(index => new Booth
    //    {
    //        BoothId = index,
    //        BoothName = $"booth {index}",
    //        AddressId = index + 42,

    //    }).ToList();

    //}

    //private List<Cart> GetCarts()
    //{
    //    return Enumerable.Range(1, 10).Select(index => new Cart
    //    {
    //        CartId = index,
    //        TotalPrice = 0,
    //        CustomerId = index,
    //        IsCanceled = false,
    //        IsPayed = false,


    //    }).ToList();

    //}

    //private List<Category> GetCategories()
    //{
    //    return Enumerable.Range(1, 10).Select(index => new Category
    //    {
    //        CategoryId = index,
    //        CategoryName = $"category {index}",
    //        IsAccepted = true,
    //        IsDeleted = false,


    //    }).ToList();

    //}

    //private List<Comment> GetComments()
    //{
    //    return Enumerable.Range(1, 10).Select(index => new Comment
    //    {
    //        CommentId = index,
    //        ProductId = 1,
    //        CustomerId = index,
    //        IsAccepted = true,
    //        Message = $"Message {index}"

    //    }).ToList();

    //}

    //private List<Medal> GetMedals()
    //{
    //    return Enumerable.Range(1, 10).Select(index => new Medal
    //    {
    //        MedalId = index,
    //        MedalType = $"Medal {index}",
    //        IsDeleted = false,
    //        Wage = index * 5,


    //    }).ToList();

    //}

    //private List<Picture> GetPictures()
    //{
    //    return Enumerable.Range(1, 10).Select(index => new Picture
    //    {
    //        PictureId = index,
    //        Url = $"Url {index}",
    //        ProductId = index,
    //        IsDeleted = false,

    //    }).ToList();

    //}

    //private List<Product> GetProducts()
    //{
    //    return Enumerable.Range(1, 10).Select(index => new Product
    //    {
    //        ProductId = index,
    //        ProductName = $"Product {index}",
    //        CategoryId = index,
    //        Price = index * 6,
    //        BoothId = index,
    //        IsDeleted = false,
    //        IsAvailable = true,
    //        IsAccepted = true,
    //        Amount = 5,


    //    }).ToList();
    //}

    #endregion
}
