using ECommerceApp.Application.DTOs;
using ECommerceApp.Application.Interfaces;
using ECommerceApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Infrastructure.Services;

public class OrderQueryService : IOrderQueryService
{
    private readonly AppDbContext _context;

    public OrderQueryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<OrderDto>> GetUserOrdersAsync(int userId, CancellationToken cancellationToken)
    {
        var orders = await _context.Orders
            .AsNoTracking()
            .Include(o => o.OrderItems)
            .ThenInclude(i => i.Product)
            .Where(o => o.UserId == userId)
            .OrderByDescending(o => o.CreatedAt)
            .ToListAsync(cancellationToken);

        return orders.Select(o => new OrderDto
        (
            o.Id,
            o.Status,
            o.TotalAmount,
            o.CreatedAt,
            o.OrderItems.Select(i => new OrderItemDto
            (
                i.Product.Name,
                i.UnitPrice,
                i.Quantity
            )).ToList()
        )).ToList();
    }
}
