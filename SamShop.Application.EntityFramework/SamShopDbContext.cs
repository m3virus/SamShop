using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SamShop.Domain.Core.Models;

public partial class SamShopDbContext : DbContext
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

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    public virtual DbSet<Wallet> Wallets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=SamShopDB;integrated security=sspi;TrustServerCertificate=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");

            entity.Property(e => e.AddressId).ValueGeneratedOnAdd();
            entity.Property(e => e.Alley).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.PostCode).HasMaxLength(20);
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.Street).HasMaxLength(50);

            entity.HasOne(d => d.AddressNavigation).WithOne(p => p.Address)
                .HasForeignKey<Address>(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Address_Admin");

            entity.HasOne(d => d.Address1).WithOne(p => p.Address)
                .HasForeignKey<Address>(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Address_Booth");

            entity.HasOne(d => d.Address2).WithOne(p => p.Address)
                .HasForeignKey<Address>(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Address_Seller");

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
                    });
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.ToTable("Admin");

            entity.Property(e => e.AdminId).ValueGeneratedOnAdd();
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FirstName).HasMaxLength(256);
            entity.Property(e => e.LastName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasOne(d => d.AdminNavigation).WithOne(p => p.Admin)
                .HasForeignKey<Admin>(d => d.AdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Admin_Picture");

            entity.HasOne(d => d.Admin1).WithOne(p => p.Admin)
                .HasForeignKey<Admin>(d => d.AdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Admin_Wallet");
        });

        modelBuilder.Entity<Auction>(entity =>
        {
            entity.ToTable("Auction");

            entity.Property(e => e.AuctionId).ValueGeneratedOnAdd();
            entity.Property(e => e.AuctionTitle).HasMaxLength(50);
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.TheLowestOffer).HasColumnType("money");

            entity.HasOne(d => d.AuctionNavigation).WithOne(p => p.Auction)
                .HasForeignKey<Auction>(d => d.AuctionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Auction_Product");

            entity.HasOne(d => d.Seller).WithMany(p => p.Auctions)
                .HasForeignKey(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Auction_Seller");
        });

        modelBuilder.Entity<AuctionOffer>(entity =>
        {
            entity.HasKey(e => e.OfferId);

            entity.ToTable("AuctionOffer");

            entity.Property(e => e.OfferValue).HasColumnType("money");

            entity.HasOne(d => d.Auction).WithMany(p => p.AuctionOffers)
                .HasForeignKey(d => d.AuctionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuctionOffer_Auction");

            entity.HasOne(d => d.Customer).WithMany(p => p.AuctionOffers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuctionOffer_Customer");
        });

        modelBuilder.Entity<Booth>(entity =>
        {
            entity.ToTable("Booth");

            entity.Property(e => e.BoothId).ValueGeneratedOnAdd();
            entity.Property(e => e.BoothName).HasMaxLength(50);

            entity.HasOne(d => d.BoothNavigation).WithOne(p => p.Booth)
                .HasForeignKey<Booth>(d => d.BoothId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booth_Seller");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.ToTable("Cart");

            entity.Property(e => e.CartId).ValueGeneratedOnAdd();
            entity.Property(e => e.TotalPrice).HasColumnType("money");

            entity.HasOne(d => d.CartNavigation).WithOne(p => p.Cart)
                .HasForeignKey<Cart>(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cart_Customer");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryName).HasMaxLength(256);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.Property(e => e.Message).HasColumnType("ntext");

            entity.HasOne(d => d.Customer).WithMany(p => p.Comments)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Customer");

            entity.HasOne(d => d.Product).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Product1");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).ValueGeneratedOnAdd();
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FirstName)
                .HasMaxLength(256)
                .HasColumnName("FIrstName");
            entity.Property(e => e.LastName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasOne(d => d.CustomerNavigation).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Picture");

            entity.HasOne(d => d.Customer1).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Wallet");

            entity.HasMany(d => d.AddressesNavigation).WithMany(p => p.CustomersNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "CustomerAddress",
                    r => r.HasOne<Address>().WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CustomerAddress_Address"),
                    l => l.HasOne<Customer>().WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CustomerAddress_Customer"),
                    j =>
                    {
                        j.HasKey("CustomerId", "AddressId");
                        j.ToTable("CustomerAddress");
                    });
        });

        modelBuilder.Entity<Medal>(entity =>
        {
            entity.ToTable("Medal");

            entity.Property(e => e.MedalId).ValueGeneratedOnAdd();
            entity.Property(e => e.MedalType).HasMaxLength(50);
            entity.Property(e => e.Wage).HasColumnType("decimal(3, 2)");

            entity.HasOne(d => d.MedalNavigation).WithOne(p => p.Medal)
                .HasForeignKey<Medal>(d => d.MedalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medal_Seller");
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.ToTable("Picture");

            entity.Property(e => e.Url).HasColumnName("URL");

            entity.HasOne(d => d.Product).WithMany(p => p.Pictures)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Picture_Product");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.ToTable("Price");

            entity.Property(e => e.ChangeDate).HasColumnType("datetime");
            entity.Property(e => e.PriceAmount).HasColumnType("money");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId).ValueGeneratedOnAdd();
            entity.Property(e => e.ProductName).HasMaxLength(256);

            entity.HasOne(d => d.Booth).WithMany(p => p.Products)
                .HasForeignKey(d => d.BoothId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Booth");

            entity.HasOne(d => d.ProductNavigation).WithOne(p => p.Product)
                .HasForeignKey<Product>(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");

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
                    });
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.ToTable("Seller");

            entity.Property(e => e.SellerId).ValueGeneratedOnAdd();
            entity.Property(e => e.FirstName).HasMaxLength(256);
            entity.Property(e => e.LastName).HasMaxLength(256);
            entity.Property(e => e.Phone).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasOne(d => d.SellerNavigation).WithOne(p => p.Seller)
                .HasForeignKey<Seller>(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seller_Picture");

            entity.HasOne(d => d.Seller1).WithOne(p => p.Seller)
                .HasForeignKey<Seller>(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seller_Wallet");
        });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.ToTable("Wallet");

            entity.Property(e => e.WalletId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
