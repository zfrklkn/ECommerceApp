using ECommerceApp.Domain.Entities;

namespace ECommerceApp.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Product> Products { get; }
    IRepository<Order> Orders { get; }
    IRepository<User> Users { get; }
    Task<int> SaveChangesAsync();
}
