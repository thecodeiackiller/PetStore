using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petstore
{
    internal interface IProductLogic
    {

        public void GetAllProducts();
        public T GetProductByNameGenericMethod<T>(string name) where T : Product;
        public void AddProduct(Product product);

        public void GetInStockItems();
        public void GetOutOfStockItems();

    }
}
