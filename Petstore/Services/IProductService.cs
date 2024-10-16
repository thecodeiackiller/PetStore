using Petstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petstore.Services
{
    public interface IProductService
    {
        void AddProduct(Product product);
        Product GetProductById(int id);
    }
}
