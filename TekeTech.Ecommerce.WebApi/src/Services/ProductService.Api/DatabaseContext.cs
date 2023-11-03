﻿using System.Collections.Generic;
using ProductService.Api.Models;
using Microsoft.EntityFrameworkCore;
using ProductService.Api.Models.BasketService.Api.Models;

namespace ProductService.Api
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductMedia> ProductMedias { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ProductCampaign> ProductCampaigns { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }


        private readonly IConfiguration _configuration; // Add a private field for IConfiguration

        public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Use the connection string from appsettings.json
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
