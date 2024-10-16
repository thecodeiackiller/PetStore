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
        public void addProduct(Product product);
        public Product getProductById(int productId);
        public List<Product> getAllProducts();

    }
}
