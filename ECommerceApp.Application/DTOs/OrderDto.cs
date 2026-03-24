using ECommerceApp.Domain.Enums;

namespace ECommerceApp.Application.DTOs;

public record OrderDto(
   int Id,
   OrderStatus Status,
   decimal TotalAmount,
   DateTime CreatedAt,
   List<OrderItemDto> Items
);

public record OrderItemDto(
    string? ProductName,
    decimal UnitPrice,
    int Quantity
);
