using MediatR;

namespace ECommerceApp.Application.Features.Products.Commands.DeleteProduct;

public record DeleteProductCommand(int Id) : IRequest<bool>;
