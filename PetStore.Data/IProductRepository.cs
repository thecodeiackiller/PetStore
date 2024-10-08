using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Data
{
    public interface IProductRepository
    {
        public void addProduct(ProductEntity productEntity);
        public ProductEntity getProductById(int productId);
        public List<ProductEntity> getAllProducts();

    }
}
