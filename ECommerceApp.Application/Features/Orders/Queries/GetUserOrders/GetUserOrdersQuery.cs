using ECommerceApp.Application.DTOs;
using MediatR;

namespace ECommerceApp.Application.Features.Orders.Queries.GetUserOrders;

public record GetUserOrdersQuery(int UserId) : IRequest<List<OrderDto>>;
