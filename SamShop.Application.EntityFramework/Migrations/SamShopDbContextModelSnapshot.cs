﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SamShop.Application.EntityFramework.DBContext;

#nullable disable

namespace SamShop.Application.EntityFramework.Migrations
{
    [DbContext(typeof(SamShopDbContext))]
    partial class SamShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AddressCustomer", b =>
                {
                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("AddressId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("AddressCustomer", (string)null);
                });

            modelBuilder.Entity("ProductCart", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CartId");

                    b.HasIndex("CartId");

                    b.ToTable("ProductCart", (string)null);
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Alley")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ExtraPart")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AddressId");

                    b.ToTable("Address", (string)null);
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<decimal>("Wallet")
                        .HasColumnType("money");

                    b.HasKey("AdminId");

                    b.ToTable("Admin", (string)null);
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Auction", b =>
                {
                    b.Property<int>("AuctionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AuctionTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime");

                    b.Property<decimal>("TheLowestOffer")
                        .HasColumnType("money");

                    b.HasKey("AuctionId");

                    b.HasIndex("SellerId");

                    b.ToTable("Auction", (string)null);
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.AuctionOffer", b =>
                {
                    b.Property<int>("OfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OfferId"));

                    b.Property<int>("AuctionId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAccept")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCanceled")
                        .HasColumnType("bit");

                    b.Property<decimal>("OfferValue")
                        .HasColumnType("money");

                    b.HasKey("OfferId");

                    b.HasIndex("AuctionId");

                    b.HasIndex("CustomerId");

                    b.ToTable("AuctionOffer", (string)null);
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Booth", b =>
                {
                    b.Property<int>("BoothId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BoothName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BoothId");

                    b.ToTable("Booth", (string)null);
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsCanceled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPayed")
                        .HasColumnType("bit");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("money");

                    b.HasKey("CartId");

                    b.ToTable("Cart", (string)null);
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("CategoryId");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("FIrstName");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<decimal>("Wallet")
                        .HasColumnType("money");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Medal", b =>
                {
                    b.Property<int>("MedalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("MedalType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Wage")
                        .HasColumnType("decimal(3, 2)");

                    b.HasKey("MedalId");

                    b.ToTable("Medal", (string)null);
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Picture", b =>
                {
                    b.Property<int>("PictureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PictureId"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("URL");

                    b.HasKey("PictureId");

                    b.HasIndex("ProductId");

                    b.ToTable("Picture", (string)null);
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("BoothId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("ProductId");

                    b.HasIndex("BoothId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Seller", b =>
                {
                    b.Property<int>("SellerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<decimal>("Wallet")
                        .HasColumnType("money");

                    b.HasKey("SellerId");

                    b.ToTable("Seller", (string)null);
                });

            modelBuilder.Entity("AddressCustomer", b =>
                {
                    b.HasOne("SamShop.Domain.Core.Models.Entity.Address", null)
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .IsRequired()
                        .HasConstraintName("FK_AddressCustomer_Address");

                    b.HasOne("SamShop.Domain.Core.Models.Entity.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK_AddressCustomer_Customer1");
                });

            modelBuilder.Entity("ProductCart", b =>
                {
                    b.HasOne("SamShop.Domain.Core.Models.Entity.Cart", null)
                        .WithMany()
                        .HasForeignKey("CartId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductCart_Cart");

                    b.HasOne("SamShop.Domain.Core.Models.Entity.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductCart_Product");
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Address", b =>
                {
                    b.HasOne("SamShop.Domain.Core.Models.Entity.Admin", "AddressNavigation")
                        .WithOne("Address")
                        .HasForeignKey("SamShop.Domain.Core.Models.Entity.Address", "AddressId")
                        .IsRequired()
                        .HasConstraintName("FK_Address_Admin");

                    b.HasOne("SamShop.Domain.Core.Models.Entity.Booth", "Address1")
                        .WithOne("Address")
                        .HasForeignKey("SamShop.Domain.Core.Models.Entity.Address", "AddressId")
                        .IsRequired()
                        .HasConstraintName("FK_Address_Booth");

                    b.HasOne("SamShop.Domain.Core.Models.Entity.Seller", "Address2")
                        .WithOne("Address")
                        .HasForeignKey("SamShop.Domain.Core.Models.Entity.Address", "AddressId")
                        .IsRequired()
                        .HasConstraintName("FK_Address_Seller");

                    b.Navigation("Address1");

                    b.Navigation("Address2");

                    b.Navigation("AddressNavigation");
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Admin", b =>
                {
                    b.HasOne("SamShop.Domain.Core.Models.Entity.Picture", "AdminNavigation")
                        .WithOne("Admin")
                        .HasForeignKey("SamShop.Domain.Core.Models.Entity.Admin", "AdminId")
                        .IsRequired()
                        .HasConstraintName("FK_Admin_Picture");

                    b.Navigation("AdminNavigation");
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Auction", b =>
                {
                    b.HasOne("SamShop.Domain.Core.Models.Entity.Product", "AuctionNavigation")
                        .WithOne("Auction")
                        .HasForeignKey("SamShop.Domain.Core.Models.Entity.Auction", "AuctionId")
                        .IsRequired()
                        .HasConstraintName("FK_Auction_Product");

                    b.HasOne("SamShop.Domain.Core.Models.Entity.Seller", "Seller")
                        .WithMany("Auctions")
                        .HasForeignKey("SellerId")
                        .IsRequired()
                        .HasConstraintName("FK_Auction_Seller");

                    b.Navigation("AuctionNavigation");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.AuctionOffer", b =>
                {
                    b.HasOne("SamShop.Domain.Core.Models.Entity.Auction", "Auction")
                        .WithMany("AuctionOffers")
                        .HasForeignKey("AuctionId")
                        .IsRequired()
                        .HasConstraintName("FK_AuctionOffer_Auction");

                    b.HasOne("SamShop.Domain.Core.Models.Entity.Customer", "Customer")
                        .WithMany("AuctionOffers")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK_AuctionOffer_Customer");

                    b.Navigation("Auction");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Booth", b =>
                {
                    b.HasOne("SamShop.Domain.Core.Models.Entity.Seller", "BoothNavigation")
                        .WithOne("Booth")
                        .HasForeignKey("SamShop.Domain.Core.Models.Entity.Booth", "BoothId")
                        .IsRequired()
                        .HasConstraintName("FK_Booth_Seller");

                    b.Navigation("BoothNavigation");
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Cart", b =>
                {
                    b.HasOne("SamShop.Domain.Core.Models.Entity.Customer", "CartNavigation")
                        .WithOne("Cart")
                        .HasForeignKey("SamShop.Domain.Core.Models.Entity.Cart", "CartId")
                        .IsRequired()
                        .HasConstraintName("FK_Cart_Customer");

                    b.Navigation("CartNavigation");
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Comment", b =>
                {
                    b.HasOne("SamShop.Domain.Core.Models.Entity.Customer", "Customer")
                        .WithMany("Comments")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK_Comments_Customer");

                    b.HasOne("SamShop.Domain.Core.Models.Entity.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_Comments_Product1");

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Customer", b =>
                {
                    b.HasOne("SamShop.Domain.Core.Models.Entity.Picture", "CustomerNavigation")
                        .WithOne("Customer")
                        .HasForeignKey("SamShop.Domain.Core.Models.Entity.Customer", "CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK_Customer_Picture");

                    b.Navigation("CustomerNavigation");
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Medal", b =>
                {
                    b.HasOne("SamShop.Domain.Core.Models.Entity.Seller", "MedalNavigation")
                        .WithOne("Medal")
                        .HasForeignKey("SamShop.Domain.Core.Models.Entity.Medal", "MedalId")
                        .IsRequired()
                        .HasConstraintName("FK_Medal_Seller");

                    b.Navigation("MedalNavigation");
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Picture", b =>
                {
                    b.HasOne("SamShop.Domain.Core.Models.Entity.Product", "Product")
                        .WithMany("Pictures")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_Picture_Product");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Product", b =>
                {
                    b.HasOne("SamShop.Domain.Core.Models.Entity.Booth", "Booth")
                        .WithMany("Products")
                        .HasForeignKey("BoothId")
                        .IsRequired()
                        .HasConstraintName("FK_Product_Booth");

                    b.HasOne("SamShop.Domain.Core.Models.Entity.Category", "ProductNavigation")
                        .WithOne("Product")
                        .HasForeignKey("SamShop.Domain.Core.Models.Entity.Product", "ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_Product_Category");

                    b.Navigation("Booth");

                    b.Navigation("ProductNavigation");
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Seller", b =>
                {
                    b.HasOne("SamShop.Domain.Core.Models.Entity.Picture", "SellerNavigation")
                        .WithOne("Seller")
                        .HasForeignKey("SamShop.Domain.Core.Models.Entity.Seller", "SellerId")
                        .IsRequired()
                        .HasConstraintName("FK_Seller_Picture");

                    b.Navigation("SellerNavigation");
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Admin", b =>
                {
                    b.Navigation("Address");
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Auction", b =>
                {
                    b.Navigation("AuctionOffers");
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Booth", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Category", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Customer", b =>
                {
                    b.Navigation("AuctionOffers");

                    b.Navigation("Cart");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Picture", b =>
                {
                    b.Navigation("Admin");

                    b.Navigation("Customer");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Product", b =>
                {
                    b.Navigation("Auction");

                    b.Navigation("Comments");

                    b.Navigation("Pictures");
                });

            modelBuilder.Entity("SamShop.Domain.Core.Models.Entity.Seller", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Auctions");

                    b.Navigation("Booth");

                    b.Navigation("Medal");
                });
#pragma warning restore 612, 618
        }
    }
}
