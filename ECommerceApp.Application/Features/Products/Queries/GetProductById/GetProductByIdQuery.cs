using ECommerceApp.Application.DTOs;
using MediatR;

namespace ECommerceApp.Application.Features.Products.Queries.GetProductById;

public record GetProductByIdQuery(int Id) : IRequest<ProductDto>;
