using PrzykładKol.Properties.DTOs;

namespace PrzykładKol.Properties.Service;

public interface IOrderService
{
        Task<OrderDto> GetOrderById(int orderId);
}