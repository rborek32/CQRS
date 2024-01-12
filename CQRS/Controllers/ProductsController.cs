using CQRS.Commands;
using CQRS.Model;
using CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    // public ProductsController(IMediator mediator) => _mediator = mediator;
    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
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
        // await _mediator.Send(new AddProductCommand(product));
        // return StatusCode(201);

        var productToReturn = 
            await _mediator.Send(new AddProductCommand(product));

        return CreatedAtRoute("GetProductById", 
            new {id = productToReturn.Id}, productToReturn);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var deleteQuery = new DeleteProductByIdQuery(id); // Create the query with the product ID
        var deletedProduct = await _mediator.Send(deleteQuery);

        if (deletedProduct != null)
        {
            return Ok("Product Deleted");
        }
        else
        {
            // Handle the case where the product was not found or couldn't be deleted
            // Return a NotFound or BadRequest response, as appropriate.
            return NotFound("Product not found or couldn't be deleted");
        }
    }
}