using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Petstore.Models;

namespace PetStore.Data
{
    public class ProductContext : DbContext 
    {
        public DbSet<Product> Products { get; set; }

        private string? DbPath { get;} // Unlike other databases where we connect to a server through a connection string, we'll setup an actually path to the SQLite context as it is file based

        public ProductContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "products.db");

            // Just want to see where the path of the folder is
            Console.WriteLine($"The path of the SQLite folder is {DbPath}");
        }

        // Now we need to configue the ability the EF to set up the environment in the local folder that we specified.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

    }
}


