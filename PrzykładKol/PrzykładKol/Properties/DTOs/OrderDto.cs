namespace PrzykładKol.Properties.DTOs;

public class OrderDto
{
    public int ID { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? FulfilledAt { get; set; }
    public string Status { get; set; }
    public ClientDto Client { get; set; }
    public List<ProductDto> products { get; set; }
}

public class ClientDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

}
//
// public class StatusDto
// {
//     public int ID { get; set; }
//     public string Name { get; set; }
//     
    

// }

// public class Product_OrderDto
// {
//     public int ProductId { get; set; }
//     public int OrderId { get; set; }
//     public int Amount { get; set; }
//     public ProductDto Product { get; set; }
//     public OrderDto Order { get; set; }
// }

public class ProductDto
{
    public int ID { get; set; }
    public string Name { get; set; }
    public Double Price { get; set; }
    public int Amount { get; set; }
    // public ICollection<Product_OrderDto> ProductOrders { get; set; }
}

