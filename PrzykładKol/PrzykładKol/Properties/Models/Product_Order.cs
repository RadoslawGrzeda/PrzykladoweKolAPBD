using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PrzykładKol.Properties.Models;


// [PrimaryKey(nameof(ProductId),nameof(OrderId))]
public class Product_Order
{
    
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    public int Amount { get; set; }
    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; }
    [ForeignKey(nameof(OrderId))]
    public Order Order { get; set; }
}