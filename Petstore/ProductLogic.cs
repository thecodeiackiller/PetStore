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
            // The variable being private is a form of encapsulation. The variable is only accessible to this class, the ProductLogic class.

            public ProductLogic()
            {
                    this._products = new List<Product>();
            }

            public void AddProduct(Product product)
            {
                this._products.Add(product);
            }

        public void GetAllProducts()
        {
            foreach (Product product in _products)
            {
                Console.WriteLine($"{product.Name}");
            }
        }
        }
    }
