using ECommerceApp.Application.DTOs;

namespace ECommerceApp.Application.Interfaces;

public interface IOrderQueryService
{
    Task<List<OrderDto>> GetUserOrdersAsync(int userId, CancellationToken cancellationToken);
}
