using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrzykładKol.Properties.Models;

public class Status
{
    [Key]
    public int ID { get; set; }
    [MaxLength(50)]
    [Column(TypeName = "varchar(50)")]
    public string Name { get; set; }
    
    public ICollection<Order> Orders { get; set; }

}