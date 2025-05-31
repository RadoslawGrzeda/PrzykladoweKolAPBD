using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrzykładKol.Properties.Models;

public class Client
{
    [Key]
    public int ID { get; set; }
    [MaxLength(50)]
    [Column(TypeName = "varchar(50)")]
    public string FirstName { get; set; }
    [MaxLength(100)]
    [Column(TypeName = "varchar(100)")]
    public string LastName { get; set; }
    
    public ICollection<Order> Orders { get; set; }
}