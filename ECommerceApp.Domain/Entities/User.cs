namespace ECommerceApp.Domain.Entities;

public class User : BaseEntity
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public int Role { get; set; }
}
