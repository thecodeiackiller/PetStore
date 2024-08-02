    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Petstore
    {
        internal class ProductLogic
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
            }

            public void AddProduct(Product product)
            {
                this._products.Add(product);

            if (product is DogLeash)  // Wow, using the keyword "is" is new. Didn't know we could do that. Nevertheless, this is called Type Checking. 
            {
                this._dogLeash.Add(product.Name, product as DogLeash); // We are casting the product that was passed in as a DogLeash so deez folks know what we're referencing
            }
            
            if(product is CatFood)
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
                


     // Need to implement some exception handling here using try catch if DogLeash name does not exist and prompt user to enter new name or enter new dog leash
               
        }
        }
    }
