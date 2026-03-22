using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Interfaces;
using ECommerceApp.Infrastructure.Persistence;

namespace ECommerceApp.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    private IRepository<Product>? _products;
    private IRepository<Order>? _orders;
    private IRepository<User>? _users;
    private IRepository<Category>? _categories;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IRepository<Product> Products => _products ??= new GenericRepository<Product>(_context);

    public IRepository<Order> Orders => _orders ??= new GenericRepository<Order>(_context);

    public IRepository<User> Users => _users ??= new GenericRepository<User>(_context);

    public IRepository<Category> Categories => _categories ??= new GenericRepository<Category>(_context);

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
