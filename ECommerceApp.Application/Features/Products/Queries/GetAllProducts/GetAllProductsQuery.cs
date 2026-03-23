using ECommerceApp.Application.DTOs;
using MediatR;

namespace ECommerceApp.Application.Features.Products.Queries.GetAllProducts;

public record GetAllProductsQuery : IRequest<List<ProductDto>>;
