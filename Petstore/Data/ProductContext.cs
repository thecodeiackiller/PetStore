using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using Petstore.Models;

namespace Petstore.Data
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        //Constructor that accepts DbContextOptions and passes it to the base class
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options) // Pass options to the base DbContext class
        {
            Database.EnsureCreated();
        }
    }
}
