using System.ComponentModel.DataAnnotations.Schema;

namespace Petstore.Models
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        // Adding an Order .EF knows this is a foreign key to Order when we set our navigation property of type Order
        public int OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
