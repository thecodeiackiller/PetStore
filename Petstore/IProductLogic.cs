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
        public DogLeash GetDogLeashByName(string name);
        public void AddProduct(Product product);

        public void GetInStockItems(); // Defining this method before looking further into instructions
        public void GetOutOfStockItems();

    }
}
