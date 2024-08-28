    using System;
    using System.Collections.Generic;
    using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
    using System.Threading.Tasks;

    namespace Petstore
    {
    internal class ProductLogic : IProductLogic
    {

        private List<Product> _products; // The underscore before products is typical syntax to let everybody know that the variable is private. 
                                         // The variable being private is a form of encapsulation. The variable is only accessible to this class, the ProductLogic class
        private Dictionary<string, DogLeash> _dogLeash;
        private Dictionary<string, CatFood> _catsFood;

        public ProductLogic()
        {
            this._products = new List<Product>();
            this._dogLeash = new Dictionary<string, DogLeash>();
            this._catsFood = new Dictionary<string, CatFood>();

            AddProduct(new Product { Name = "Leather Leash", Price = 26.99M, Quantity = 5 }); // This is object initializer syntax
            AddProduct(new Product { Name = "Beddazzled Leash", Price = 50.00M, Quantity = 0 });
        }

        public void AddProduct(Product product)
        {
            this._products.Add(product);

            if (product is DogLeash)  // Wow, using the keyword "is" is new. Didn't know we could do that. Nevertheless, this is called Type Checking. 
            {
                this._dogLeash.Add(product.Name, product as DogLeash); // We are casting the product that was passed in as a DogLeash so deez folks know what we're referencing
            }

            if (product is CatFood)
            {
                this._catsFood.Add(product.Name, product as CatFood); // Again, casting the product we passed in as CatFood. 
            }
        }
        // Adding a dictionary to this class and adding key value pairs to the dictionary within the AddProduct class is an important lesson when it comes to polymorphism, types, and inheritance
    
        
        public void GetAllProducts()
        {
            foreach (Product product in _products)
            {
                Console.WriteLine($"{product.Name}");
            }
        }

        public DogLeash GetDogLeashByName(string name)
        {
            if(this._dogLeash.ContainsKey(name))
            {
                return _dogLeash[name];
            }
            else
            {
                throw new Exception("Cannot find product. Please enter new name or add new Dog Leash product.");
            }                      
        }

        // Going to define the GetInStockItems here because that's what I'm assuming they want us to do
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
