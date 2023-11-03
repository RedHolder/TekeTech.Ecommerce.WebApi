﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductService.Api;

#nullable disable

namespace ProductService.Api.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductService.Api.Models.Campaign", b =>
                {
                    b.Property<int>("CampaignId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CampaignId"));

                    b.Property<float>("DiscountRate")
                        .HasColumnType("real");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CampaignId");

                    b.HasIndex("ProductId");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("ProductService.Api.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ProductService.Api.Models.Media", b =>
                {
                    b.Property<int>("MediaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MediaId"));

                    b.Property<string>("MediaURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("MediaId");

                    b.HasIndex("ProductId");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("ProductService.Api.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Features")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Inventory")
                        .HasColumnType("int");

                    b.Property<string>("MarketPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SellerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShipmentDay")
                        .HasColumnType("int");

                    b.Property<string>("Sizes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProductService.Api.Models.ProductCampaign", b =>
                {
                    b.Property<int>("ProductCampaignId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductCampaignId"));

                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("ProductCampaignId");

                    b.HasIndex("CampaignId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCampaigns");
                });

            modelBuilder.Entity("ProductService.Api.Models.ProductMedia", b =>
                {
                    b.Property<int>("ProductMediaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductMediaId"));

                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("ProductMediaId");

                    b.HasIndex("MediaId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductMedias");
                });

            modelBuilder.Entity("ProductService.Api.Models.ProductReview", b =>
                {
                    b.Property<int>("ProductReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductReviewId"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ReviewId")
                        .HasColumnType("int");

                    b.HasKey("ProductReviewId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ReviewId");

                    b.ToTable("ProductReviews");
                });

            modelBuilder.Entity("ProductService.Api.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("ProductId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("ProductService.Api.Models.Campaign", b =>
                {
                    b.HasOne("ProductService.Api.Models.Product", null)
                        .WithMany("ProductCampaign")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("ProductService.Api.Models.Media", b =>
                {
                    b.HasOne("ProductService.Api.Models.Product", null)
                        .WithMany("ProductMedia")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("ProductService.Api.Models.ProductCampaign", b =>
                {
                    b.HasOne("ProductService.Api.Models.Campaign", "Campaign")
                        .WithMany()
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductService.Api.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProductService.Api.Models.ProductMedia", b =>
                {
                    b.HasOne("ProductService.Api.Models.Media", "Media")
                        .WithMany()
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductService.Api.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Media");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProductService.Api.Models.ProductReview", b =>
                {
                    b.HasOne("ProductService.Api.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductService.Api.Models.Review", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("ProductService.Api.Models.Review", b =>
                {
                    b.HasOne("ProductService.Api.Models.Product", null)
                        .WithMany("ProductReview")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("ProductService.Api.Models.Product", b =>
                {
                    b.Navigation("ProductCampaign");

                    b.Navigation("ProductMedia");

                    b.Navigation("ProductReview");
                });
#pragma warning restore 612, 618
        }
    }
}