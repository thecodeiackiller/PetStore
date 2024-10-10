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
        

        // We are creating a private readonly variable with the type being the interface for the repository class
        private readonly IProductRepository _repository; // This is going to allow us to add products into the database. 
        // My only worry here is that our original Product.cs entity doesn't have Id. So we might have to use Identity or AutoGenerate to populate an Id.


        public ProductLogic(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            // Need to create validation class instantiation here and put everything in a try catch block
            // Throw Validation Exception if the results have errors and then print the errors that we encountered for extra pudding.

            _productRepository.addProduct(product); // Now when we press one and "Add" a new product, we'll be adding it to the db.

            // Need to replace the above code with a call to the repositories add method. We are going to keep the code just to reference what we were doing, though. 
        }
        
        public void GetProductById(int Id)
        {
            // We changed this method, but we really didn't need to. All we have to do is call the method from the ProductRepository.
        }

    }
}
