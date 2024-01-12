using CQRS.Commands;
using CQRS.Model;
using CQRS.Queries;
using CQRS.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly DataStore _dataStore;

    // public ProductsController(IMediator mediator) => _mediator = mediator;
    public ProductsController(IMediator mediator, DataStore dataStore)
    {
        _mediator = mediator;
        _dataStore = dataStore;
    }
    
    [HttpGet]
    public async Task<ActionResult> GetProducts()
    {
        var products = 
            await _mediator.Send(new GetProductsQuery());

        return Ok(products);
    }
    
    [HttpGet("{id:int}", Name = "GetProductById")]
    public async Task<ActionResult> GetProductById(int id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> AddProduct([FromBody] Product product)
    {
        var productToReturn = 
            await _mediator.Send(new AddProductCommand(product));

        if (product != null)
        {
            return CreatedAtRoute("GetProductById", 
                new {id = productToReturn.Id}, productToReturn);
        }
        return NotFound("Product not found");
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));

        if (product != null)
        {
            await _dataStore.DeleteProduct(product);
            return Ok("Deleted");
        } 
        return NotFound("Product not found");
    }
}