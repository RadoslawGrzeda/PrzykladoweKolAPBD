using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrzykładKol.Properties.Models;

public class Order
{
    [Key]
    public int ID { get; set; }
    public int ClientId { get; set; }
    public int StatusId { get; set; }
    [Column(TypeName = "timestamp with time zone")]
    public DateTime CreatedAt { get; set; }
    [Column(TypeName = "timestamp with time zone")]
    public DateTime? FulfilledAt { get; set; }

    [ForeignKey(nameof(ClientId))]
    public Client Client { get; set; }
    [ForeignKey(nameof(StatusId))]
    public Status Status { get; set; }
    
    public ICollection<Product_Order> ProductOrders { get; set; }
}