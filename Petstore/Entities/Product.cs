using System.ComponentModel.DataAnnotations.Schema;

namespace Petstore.Models
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }
        public int ProductNumber { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
