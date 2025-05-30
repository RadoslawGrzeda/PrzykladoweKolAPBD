using System.ComponentModel.DataAnnotations;

namespace PrzykładKol.Properties.Models;

public class Product
{
    [Key]
    public int ID { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    
    public Double Price { get; set; }
    
    public ICollection<Product_Order> ProductOrders { get; set; }
}
