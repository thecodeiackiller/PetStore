using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Petstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petstore.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _db;

        public ProductRepository(ProductContext db)
        {
            _db = db;
        }

        public void addProduct(Product prodEntity)
        {
            _db.Products.Add(prodEntity);
            int result = _db.SaveChanges();

            if (result > 0)
            {
                Console.WriteLine("Product successfully added.");
            }
            else
            {
                Console.WriteLine("Failed to add product.");
            }

        }
        public List<Product> getAllProducts()
        {
            var products = _db.Products.ToList();
            return products;
        }
        public Product getProductById(int productId)
        {
            var product = _db.Products.Where(e => e.Id == productId).FirstOrDefault();

            if (product != null)
            {
                return product;
            }
            return null;

        }
    }
}
