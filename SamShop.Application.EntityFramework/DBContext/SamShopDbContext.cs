using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SamShop.Domain.Core.Models.Entities;

namespace SamShop.Infrastructure.EntityFramework.DBContext;

public partial class SamShopDbContext : IdentityDbContext<IdentityUser, IdentityRole , string>
{
    public SamShopDbContext()
    {
    }

    public SamShopDbContext(DbContextOptions<SamShopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

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

    public virtual DbSet<Seller> Sellers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=SamShopDB1;integrated security=sspi;TrustServerCertificate=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");

            entity.Property(e => e.Alley).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.PostCode).HasMaxLength(20);
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.Street).HasMaxLength(50);

            entity.HasMany(d => d.Customers).WithMany(p => p.Addresses)
                .UsingEntity<Dictionary<string, object>>(
                    "AddressCustomer",
                    r => r.HasOne<Customer>().WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_AddressCustomer_Customer1"),
                    l => l.HasOne<Address>().WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_AddressCustomer_Address"),
                    j =>
                    {
                        j.HasKey("AddressId", "CustomerId");
                        j.ToTable("AddressCustomer");
                        j.HasIndex(new[] { "CustomerId" }, "IX_AddressCustomer_CustomerId");
                    });
            entity.HasData(GetAddresses());
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.ToTable("Admin");

            entity.HasIndex(e => e.AddressId, "IX_Admin_AddressId");

            entity.HasIndex(e => e.PictureId, "IX_Admin_PictureId");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FirstName).HasMaxLength(256);
            entity.Property(e => e.LastName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);
            entity.Property(e => e.Wallet).HasColumnType("money");

            entity.HasOne(d => d.Address).WithMany(p => p.Admins)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Admin_Address");

            entity.HasOne(d => d.Picture).WithMany(p => p.Admins)
                .HasForeignKey(d => d.PictureId)
                .HasConstraintName("FK_Admin_Picture1");
            entity.HasData(GetAdmins());
        });

        modelBuilder.Entity<Auction>(entity =>
        {
            entity.ToTable("Auction");

            entity.HasIndex(e => e.ProductId, "IX_Auction_ProductId");

            entity.HasIndex(e => e.SellerId, "IX_Auction_SellerId");

            entity.Property(e => e.AuctionTitle).HasMaxLength(50);
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.TheLowestOffer).HasColumnType("money");

            entity.HasOne(d => d.Product).WithMany(p => p.Auctions)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Auction_Product1");

            entity.HasOne(d => d.Seller).WithMany(p => p.Auctions)
                .HasForeignKey(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Auction_Seller");
            entity.HasData(GetAuctions());
        });

        modelBuilder.Entity<AuctionOffer>(entity =>
        {
            entity.HasKey(e => e.OfferId);

            entity.ToTable("AuctionOffer");

            entity.HasIndex(e => e.AuctionId, "IX_AuctionOffer_AuctionId");

            entity.HasIndex(e => e.CustomerId, "IX_AuctionOffer_CustomerId");

            entity.Property(e => e.OfferValue).HasColumnType("money");

            entity.HasOne(d => d.Auction).WithMany(p => p.AuctionOffers)
                .HasForeignKey(d => d.AuctionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuctionOffer_Auction");

            entity.HasOne(d => d.Customer).WithMany(p => p.AuctionOffers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuctionOffer_Customer");
            entity.HasData(GetAuctionOffers());
        });

        modelBuilder.Entity<Booth>(entity =>
        {
            entity.ToTable("Booth");

            entity.HasIndex(e => e.AddressId, "IX_Booth_AddressId");

            entity.Property(e => e.BoothName).HasMaxLength(50);

            entity.HasOne(d => d.Address).WithMany(p => p.Booths)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booth_Address");
            entity.HasData(GetBooth());
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.ToTable("Cart");

            entity.HasIndex(e => e.CustomerId, "IX_Cart_CustomerId");

            entity.Property(e => e.TotalPrice).HasColumnType("money");

            entity.HasOne(d => d.Customer).WithMany(p => p.Carts)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cart_Customer1");
            entity.HasData(GetCarts());
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryName).HasMaxLength(256);
            entity.HasData(GetCategories());
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "IX_Comments_CustomerId");

            entity.HasIndex(e => e.ProductId, "IX_Comments_ProductId");

            entity.Property(e => e.Message).HasColumnType("ntext");

            entity.HasOne(d => d.Customer).WithMany(p => p.Comments)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Customer");

            entity.HasOne(d => d.Product).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Product1");
            entity.HasData(GetComments());
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.HasIndex(e => e.AddressId, "IX_Customer_AddressId");

            entity.HasIndex(e => e.PictureId, "IX_Customer_PictureId");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FirstName)
                .HasMaxLength(256)
                .HasColumnName("FIrstName");
            entity.Property(e => e.LastName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);
            entity.Property(e => e.Wallet).HasColumnType("money");

            entity.HasOne(d => d.Address).WithMany(p => p.CustomersNavigation)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Address");

            entity.HasOne(d => d.Picture).WithMany(p => p.Customers)
                .HasForeignKey(d => d.PictureId)
                .HasConstraintName("FK_Customer_Picture1");
            entity.HasData(GetCustomer());
        });

        modelBuilder.Entity<Medal>(entity =>
        {
            entity.ToTable("Medal");

            entity.Property(e => e.MedalType).HasMaxLength(50);
            entity.Property(e => e.Wage).HasColumnType("decimal(18, 0)");
            entity.HasData(GetMedals());
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.ToTable("Picture");

            entity.HasIndex(e => e.ProductId, "IX_Picture_ProductId");

            entity.Property(e => e.Url).HasColumnName("URL");

            entity.HasOne(d => d.Product).WithMany(p => p.Pictures)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Picture_Product");
            entity.HasData(GetPictures());
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.HasIndex(e => e.BoothId, "IX_Product_BoothId");

            entity.HasIndex(e => e.CategoryId, "IX_Product_CategoryId");

            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ProductName).HasMaxLength(256);

            entity.HasOne(d => d.Booth).WithMany(p => p.Products)
                .HasForeignKey(d => d.BoothId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Booth");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category1");

            entity.HasMany(d => d.Carts).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductCart",
                    r => r.HasOne<Cart>().WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ProductCart_Cart"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ProductCart_Product"),
                    j =>
                    {
                        j.HasKey("ProductId", "CartId");
                        j.ToTable("ProductCart");
                        j.HasIndex(new[] { "CartId" }, "IX_ProductCart_CartId");
                    });
            entity.HasData(GetProducts());
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.ToTable("Seller");

            entity.HasIndex(e => e.AddressId, "IX_Seller_AddressId");

            entity.HasIndex(e => e.BoothId, "IX_Seller_BoothId");

            entity.HasIndex(e => e.MedalId, "IX_Seller_MedalId");

            entity.HasIndex(e => e.PictureId, "IX_Seller_PictureId");

            entity.Property(e => e.FirstName).HasMaxLength(256);
            entity.Property(e => e.LastName).HasMaxLength(256);
            entity.Property(e => e.Phone).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);
            entity.Property(e => e.Wallet).HasColumnType("money");

            entity.HasOne(d => d.Address).WithMany(p => p.Sellers)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seller_Address");

            entity.HasOne(d => d.Booth).WithMany(p => p.Sellers)
                .HasForeignKey(d => d.BoothId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seller_Booth");

            entity.HasOne(d => d.Medal).WithMany(p => p.Sellers)
                .HasForeignKey(d => d.MedalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seller_Medal");

            entity.HasOne(d => d.Picture).WithMany(p => p.Sellers)
                .HasForeignKey(d => d.PictureId)
                .HasConstraintName("FK_Seller_Picture1");
            entity.HasData(GetSellers());
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    #region Dataseeder

    private List<Address> GetAddresses()
    {
        return Enumerable.Range(1, 52).Select(index => new Address
        {
            AddressId = index,
            State = $"State {index}",
            City = $"City {index}",
            Street = $"street {index}",
            Alley = $"alley {index}",
            ExtraPart = $"level 1",
            PostCode = $"{index * 1000}",



        }).ToList();
    }

    private List<Admin> GetAdmins()
    {
        return Enumerable.Range(1, 2).Select(index => new Admin
        {
            AdminId = index,
            UserName = $"StringSample {index}",
            AddressId = index,
            PictureId = null,
            FirstName = $"StringSample {index}",
            LastName = $"StringSample {index}",
            Wallet = index * 100,
            Password = $"StringSample {index}",
            Email = $"StringSample {index}@google.com",
            Phone = $"StringSample {index}",
            IsDeleted = false,
        }).ToList();
    }

    private List<Seller> GetSellers()
    {
        return Enumerable.Range(1, 10).Select(index => new Seller
        {
            SellerId = index,
            UserName = $"SellerSample {index}",
            FirstName = $"SellerSample {index}",
            LastName = $"SellerSample {index}",
            Wallet = index * 100,
            Password = $"SellerSample {index}",
            Email = $"SellerSample {index}",
            Phone = $"SellerSample {index}",
            BoothId = index,
            MedalId = 1,
            PictureId = null,
            AddressId = index + 2,
            IsDeleted = false,
        }).ToList();

    }

    private List<Customer> GetCustomer()
    {
        return Enumerable.Range(1, 30).Select(index => new Customer
        {
            CustomerId = index,
            UserName = $"CustomerSample {index}",
            FirstName = $"CustomerSample {index}",
            LastName = $"CustomerSample {index}",
            Wallet = index * 100,
            PasswordHash = $"CustomerSample {index}",
            Email = $"CustomerSample {index}",
            Phone = $"CustomerSample {index}",
            PictureId = null,
            AddressId = index + 12,
            IsDeleted = false,
        }).ToList();

    }

    private List<Auction> GetAuctions()
    {
        return Enumerable.Range(1, 1).Select(index => new Auction
        {
            AuctionId = index,
            ProductId = index,
            AuctionTitle = $"AuctionSample {index}",
            TheLowestOffer = index * 10,
            SellerId = index,
            IsAccepted = false,
            IsCanceled = false,
            StartTime = DateTime.Now,
            EndTime = DateTime.Today,

        }).ToList();

    }

    private List<AuctionOffer> GetAuctionOffers()
    {
        return Enumerable.Range(1, 3).Select(index => new AuctionOffer
        {
            OfferId = index,
            AuctionId = 1,
            OfferValue = index * 11,
            CustomerId = index,
            IsCanceled = false,
            IsAccept = false,


        }).ToList();

    }

    private List<Booth> GetBooth()
    {
        return Enumerable.Range(1, 10).Select(index => new Booth
        {
            BoothId = index,
            BoothName = $"booth {index}",
            AddressId = index + 42,

        }).ToList();

    }

    private List<Cart> GetCarts()
    {
        return Enumerable.Range(1, 10).Select(index => new Cart
        {
            CartId = index,
            TotalPrice = 0,
            CustomerId = index,
            IsCanceled = false,
            IsPayed = false,


        }).ToList();

    }

    private List<Category> GetCategories()
    {
        return Enumerable.Range(1, 10).Select(index => new Category
        {
            CategoryId = index,
            CategoryName = $"category {index}",
            IsAccepted = true,
            IsDeleted = false,


        }).ToList();

    }

    private List<Comment> GetComments()
    {
        return Enumerable.Range(1, 10).Select(index => new Comment
        {
            CommentId = index,
            ProductId = 1,
            CustomerId = index,
            IsAccepted = true,
            Message = $"Message {index}"

        }).ToList();

    }

    private List<Medal> GetMedals()
    {
        return Enumerable.Range(1, 10).Select(index => new Medal
        {
            MedalId = index,
            MedalType = $"Medal {index}",
            IsDeleted = false,
            Wage = index * 5,


        }).ToList();

    }

    private List<Picture> GetPictures()
    {
        return Enumerable.Range(1, 10).Select(index => new Picture
        {
            PictureId = index,
            Url = $"Url {index}",
            ProductId = index,
            IsDeleted = false,

        }).ToList();

    }

    private List<Product> GetProducts()
    {
        return Enumerable.Range(1, 10).Select(index => new Product
        {
            ProductId = index,
            ProductName = $"Product {index}",
            CategoryId = index,
            Price = index * 6,
            BoothId = index,
            IsDeleted = false,
            IsAvailable = true,
            IsAccepted = true,
            Amount = 5,


        }).ToList();
    }

    #endregion
}
