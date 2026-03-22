using MediatR;

namespace ECommerceApp.Application.Features.Orders.Commands.CreateOrder;

public record CreateOrderCommand(
    int UserId,
    List<CreateOrderItemDto> Items
) : IRequest<int>;

public record CreateOrderItemDto(
    int ProductId,
    int Quantity
);
