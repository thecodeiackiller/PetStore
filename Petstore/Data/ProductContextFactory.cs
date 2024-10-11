using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using PetStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petstore.Data
{
    public class ProductContextFactory : IDesignTimeDbContextFactory<ProductContext>
    {
        public ProductContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProductContext>();

            // Use the relative path or absolute path for your database file
            var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "products.db");

            optionsBuilder.UseSqlite($"Data Source={dbPath}");

            return new ProductContext(optionsBuilder.Options);
        }
    }
}
