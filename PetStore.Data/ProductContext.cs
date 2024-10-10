using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using Petstore.Models;

namespace PetStore.Data
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        //Constructor that accepts DbContextOptions and passes it to the base class
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options) // Pass options to the base DbContext class
        {
        }

        // If you want to use the path logic, we can still use the OnConfiguring method, but this is optional now
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured) // Prevent overriding if the options are already configured
        //    {
        //        var folder = Environment.SpecialFolder.LocalApplicationData;
        //        var path = Environment.GetFolderPath(folder);
        //        var dbPath = Path.Join(path, "products.db");
        //        optionsBuilder.UseSqlite($"Data Source={dbPath}");
        //    }
        //}
    }
}
