using System.ComponentModel.DataAnnotations;

namespace PrzykładKol.Properties.Models;

public class Client
{
    [Key]
    public int ID { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    
    public ICollection<Order> Orders { get; set; }
}