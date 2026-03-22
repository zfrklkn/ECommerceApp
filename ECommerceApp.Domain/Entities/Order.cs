using ECommerceApp.Domain.Enums;

namespace ECommerceApp.Domain.Entities;

public class Order : BaseEntity
{
    public int UserId { get; set; }

    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    public decimal TotalAmount { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public User User { get; set; } = null!;
}
