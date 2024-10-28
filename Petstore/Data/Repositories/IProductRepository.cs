using Petstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petstore.Data.Repositories
{
    public interface IProductRepository
    {
        public void AddProduct(Product product);
        public List<Product> GetProductsByProductNumber(int productId);
        public Task<List<Product>> GetAllProducts();

    }
}
