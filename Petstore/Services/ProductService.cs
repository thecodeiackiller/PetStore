using Petstore.Data.Repositories;
using Petstore.Models;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petstore.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            if (product.Quantity <= 0)
            {
                throw new Exception("Product quantity must be greater than 0.");
            }

            productRepository.AddProduct(product);
        }

        public Product GetProductById(int id)
        {
            var product = productRepository.GetProductById(id);

            if (product == null)
            {
                Console.WriteLine("Product not found.");
            }

            return product;
        }
    }
}
