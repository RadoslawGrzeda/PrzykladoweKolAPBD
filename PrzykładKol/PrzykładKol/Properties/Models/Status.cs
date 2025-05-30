using System.ComponentModel.DataAnnotations;

namespace PrzykładKol.Properties.Models;

public class Status
{
    [Key]
    public int ID { get; set; }
    [MaxLength(50)]
    public string Nam { get; set; }
    
    public ICollection<Order> Orders { get; set; }

}