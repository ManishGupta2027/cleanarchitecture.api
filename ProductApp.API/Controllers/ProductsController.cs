using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.CQRS.Commands;
using ProductApp.Application.CQRS.Queries;
using ProductApp.Application.DTOs;

namespace ProductApp.API.Controllers
{
  
        [Route("api/[controller]")]
        [ApiController]
        public class ProductsController : ControllerBase
        {
            private readonly IMediator _mediator;

            public ProductsController(IMediator mediator)
            {
                _mediator = mediator;
            }

            // POST: api/products
            [HttpPost]
            public async Task<ActionResult<int>> CreateProduct([FromBody] CreateProductCommand command)
            {
                var productId = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetProductById), new { id = productId }, productId);
            }

            // PUT: api/products/{id}
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductCommand command)
            {
                if (id != command.Id)
                {
                    return BadRequest();
                }

                await _mediator.Send(command);
                return NoContent();
            }

            // GET: api/products/{id}
            [HttpGet("{id}")]
            public async Task<ActionResult<ProductDto>> GetProductById(int id)
            {
                var query = new GetProductByIdQuery { Id = id };
                var product = await _mediator.Send(query);

                return product == null ? NotFound() : Ok(product);
            }

            // GET: api/products
            [HttpGet]
            public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
            {
                var query = new GetAllProductsQuery();
                var products = await _mediator.Send(query);
                return Ok(products);
            }

            // DELETE: api/products/{id}
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteProduct(int id)
            {
                var command = new DeleteProductCommand { Id = id };
                await _mediator.Send(command);
                return NoContent();
            }
        }
    }

