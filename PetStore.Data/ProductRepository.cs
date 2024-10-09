using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Petstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Data
{
    public class ProductRepository : IProductRepository
    {

        private readonly ProductContext _db;

        // Injecting ProductContext to this class through the constructor
        public ProductRepository(ProductContext db)
        {
            this._db = db;
        }



        // Now that we have created a dbcontext instance, we can begin querying our database
        // We need to add a method add a product to the database. Let's first define that method in the IProductRepository interface
        // Now that we've implemented the interface, let's go ahead and use the commands from EFCore that we have at our fingertips to add a product to our dbcontext
        public void addProduct(Product prodEntity)
        {
                _db.Products.Add(prodEntity); // Did not have Products here at first but upon watching the videos it makes sense to add a Product to our products table. 
                _db.SaveChanges(); // Should be good to go now. // Typically, if we weren't using a console app, we'd use a RedirectToAction method to redirect the user to index.html or whatever page so that they don't submit twice. 
        }


        // Now we need to add a couple more method to get a product by Id. Then we want to add another method to get all products in the database.
        // Let's go ahead and define those in our IProductRepository


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

        // As stated in the directions, we'll need to add the ApplicationDbContext as a service to our dependency injection contrainer that ASP.NET Core provides us with
        // So we'll add the EntityFramework service but then we actually need to specify the AppDbContext which allows us the perform constructor injection throughout the app.


    }
}
