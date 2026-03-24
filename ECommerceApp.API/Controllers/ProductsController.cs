using ECommerceApp.Application.Features.Products.Commands.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //[HttpGet]
    //public async Task<IActionResult> GetAll()
    //    => Ok(await _mediator.Send(new GetAllProductsQuery()));

    //[HttpGet("{id}")]
    //public async Task<IActionResult> GetById(int id)
    //    => Ok(await _mediator.Send(new GetProductByIdQuery(id)));

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(CreateProductCommand command)
        => Ok(await _mediator.Send(command));

}
