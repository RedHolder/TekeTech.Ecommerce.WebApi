﻿using Customer.Api.Models;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Customer.Api
{
   
        public class DatabaseContext : DbContext
        {
            public DbSet<CustomerInfo> CustomerInfo { get; set; }
            

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
