using Microsoft.EntityFrameworkCore;
using PrzykładKol.Properties.Data;
using PrzykładKol.Properties.DTOs;

namespace PrzykładKol.Properties.Service;

public class OrderService: IOrderService
{
    readonly protected Database _context;

    public OrderService(Database context)
    {
        _context = context;
    }
    

    public async Task<OrderDto> GetOrderById(int orderId)
    {
        var thisOrder = await _context.Orders
            .Select(e=> new OrderDto
        {
            ID = e.ID,
            CreatedAt = e.CreatedAt,
            FulfilledAt = e.FulfilledAt,
            Status = e.Status.Name,
            Client=new ClientDto()
            {
                FirstName = e.Client.FirstName,
                LastName = e.Client.LastName,
            },
            products = e.ProductOrders.Select(e => new ProductDto()
            {
                Name = e.Product.Name,
                Price = e.Product.Price,
                Amount=e.Amount
            }).ToList(),
        }).FirstOrDefaultAsync(e=>e.ID==orderId);
        
        if (thisOrder==null)
            throw new KeyNotFoundException();
        
        return thisOrder;
        
    }
        

        // throw new NotImplementedException();
    
}