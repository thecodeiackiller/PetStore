    using System;
    using System.Collections.Generic;
    using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
    using System.Threading.Tasks;
using System.Text.Json;
using PetStore.Data;
using Petstore.Models;

namespace Petstore
    {
    public class ProductLogic : IProductLogic
    {
        private readonly IProductRepository _productRepository;
        private List<Product> _products; 
        private Dictionary<string, DogLeash> _dogLeash;
        private Dictionary<string, CatFood> _catsFood;

        // We are creating a private readonly variable with the type being the interface for the repository class
        private readonly IProductRepository _repository; // This is going to allow us to add products into the database. 
        // My only worry here is that our original Product.cs entity doesn't have Id. So we might have to use Identity or AutoGenerate to populate an Id.


        public ProductLogic(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
            this._products = new List<Product>();
            this._dogLeash = new Dictionary<string, DogLeash>();
            this._catsFood = new Dictionary<string, CatFood>();

            AddProduct(new DogLeash { Name = "Leather Leash", Price = 26.99M, Quantity = 5 }); // This is object initializer syntax
            AddProduct(new DogLeash { Name = "Beddazzled Leash", Price = 50.00M, Quantity = 0 });
        }

        public void AddProduct(Product product)
        {
            // Need to create validation class instantiation here and put everything in a try catch block
            // Throw Validation Exception if the results have errors and then print the errors that we encountered for extra pudding.

            _productRepository.addProduct(product); // Now when we press one and "Add" a new product, we'll be adding it to the db.

            this._products.Add(product);

            if (product is DogLeash)
            {
                this._dogLeash.Add(product.Name, product as DogLeash);
            }

            if (product is CatFood)
            {
                this._catsFood.Add(product.Name, product as CatFood);
            }

            // Need to replace the above code with a call to the repositories add method. We are going to keep the code just to reference what we were doing, though. 
        }
        
    
        
        public void GetAllProducts()
        {
            foreach (Product product in _products)
            {
                Console.WriteLine($"{product.Name}");
            }
        }

        //public DogLeash GetDogLeashByName(string name)
        //{
        //    if(this._dogLeash.ContainsKey(name))
        //    {
        //        return _dogLeash[name];
        //    }
        //    else
        //    {
        //        throw new Exception("Cannot find product. Please enter new name or add new Dog Leash product.");
        //    }                      
        //}

        public T GetProductByNameGenericMethod<T>(string name) where T : Product
        {
            foreach(Product product in _products)
            {
                if(product.Name == name)
                {
                    if(product.GetType() == typeof(T))
                    {
                        return (T)product;
                    }
                }
                
            }
            return null;
        }
        public void GetInStockItems()
        {
            List<string> productsAsStrings = new List<string>();
            foreach (Product product in _products)
            {
                if(product.Quantity != 0)
                {
                    productsAsStrings.Add(product.Name);
                }
                
            }
            foreach(string  product in productsAsStrings)
            {
                Console.WriteLine(product + " is still available!");
            }
        }

        public void GetOutOfStockItems()
        {
            List<string> outOfItems = new List<string>();

            var outofItems = _products.Where(propa => propa.Quantity == 0).Select(propa => propa.Name).ToList();

            foreach(string product in outofItems)
            {
                Console.WriteLine(product + " is out of stock! We apologize for the inconvenience. Just kidding, we could care less about you.");
            }
        }
    }
}
