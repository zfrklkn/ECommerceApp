using ECommerceApp.Application.DTOs;
using ECommerceApp.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Application.Features.Orders.Queries.GetUserOrders;

public class GetUserOrdersQueryHandler : IRequestHandler<GetUserOrdersQuery, List<OrderDto>>
{
    private readonly AppDbContext _context;

    public GetUserOrdersQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<OrderDto>> Handle(GetUserOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _context.Orders
            .Where(o => o.UserId == request.UserId)
            .Include(o => o.OrderItems)
            .ThenInclude(i => i.Product)
            .OrderByDescending(o => o.CreatedAt)
            .ToListAsync(cancellationToken);

        return orders.Select(o => new OrderDto(

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
