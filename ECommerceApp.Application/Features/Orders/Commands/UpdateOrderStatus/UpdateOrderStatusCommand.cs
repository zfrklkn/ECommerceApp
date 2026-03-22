using ECommerceApp.Domain.Enums;
using MediatR;

namespace ECommerceApp.Application.Features.Orders.Commands.UpdateOrderStatus;

public record UpdateOrderStatusCommand
(
    int OrderId,
    OrderStatus NewStatus
) : IRequest<bool>;
