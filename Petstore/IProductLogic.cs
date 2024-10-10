using Petstore.Models;
using PetStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petstore
{
    internal interface IProductLogic
    {
        public void AddProduct(Product product);
    }
}
