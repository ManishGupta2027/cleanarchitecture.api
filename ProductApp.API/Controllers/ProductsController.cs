using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.CQRS.Commands;
using ProductApp.Application.CQRS.Queries;
using ProductApp.Application.DTOs;
using ProductApp.Application.Responses;

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
		public async Task<ActionResult<ApiResponse<Guid>>> CreateProduct([FromBody] CreateProductCommand command)
		{
			try
			{
				var productId = await _mediator.Send(command);
				var response = new ApiResponse<Guid>(true, productId, "Product created successfully.", StatusCodes.Status201Created);
				return CreatedAtAction(nameof(GetProductById), new { id = productId }, response);
			}
			catch (Exception ex)
			{
				var response = new ApiResponse<Guid>(false, Guid.Empty, $"Error creating product: {ex.Message}", StatusCodes.Status500InternalServerError);
				return StatusCode(StatusCodes.Status500InternalServerError, response);
			}
		}

		// PUT: api/products/{id}
		[HttpPut("{id}")]
		public async Task<ActionResult<BoolResponse>> UpdateProduct(Guid id, [FromBody] UpdateProductCommand command)
		{
			try
			{
				if (id != command.Id)
				{
					return BadRequest(new BoolResponse(false, "Product ID mismatch."));
				}

				await _mediator.Send(command);
				return Ok(new BoolResponse(true, "Product updated successfully."));
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new BoolResponse(false, $"Error updating product: {ex.Message}"));
			}
		}

		// GET: api/products/{id}
		[HttpGet("{id}")]
		public async Task<ActionResult<ApiResponse<ProductDto>>> GetProductById(Guid id)
		{
			try
			{
				var query = new GetProductByIdQuery { Id = id };
				var product = await _mediator.Send(query);

				if (product == null)
				{
					var response = new ApiResponse<ProductDto>(false, null, "Product not found.", StatusCodes.Status404NotFound);
					return NotFound(response);
				}

				var successResponse = new ApiResponse<ProductDto>(true, product, "Product retrieved successfully.", StatusCodes.Status200OK);
				return Ok(successResponse);
			}
			catch (Exception ex)
			{
				var response = new ApiResponse<ProductDto>(false, null, $"Error retrieving product: {ex.Message}", StatusCodes.Status500InternalServerError);
				return StatusCode(StatusCodes.Status500InternalServerError, response);
			}
		}

		// GET: api/products
		[HttpGet]
		public async Task<ActionResult<ApiResponse<List<ProductDto>>>> GetAllProducts()
		{
			try
			{
				var query = new GetAllProductsQuery();
				var products = await _mediator.Send(query);
				var successResponse = new ApiResponse<List<ProductDto>>(true, products, "Products retrieved successfully.", StatusCodes.Status200OK);
				return Ok(successResponse);
			}
			catch (Exception ex)
			{
				var response = new ApiResponse<List<ProductDto>>(false, null, $"Error retrieving products: {ex.Message}", StatusCodes.Status500InternalServerError);
				return StatusCode(StatusCodes.Status500InternalServerError, response);
			}
		}

		// DELETE: api/products/{id}
		[HttpDelete("{id}")]
		public async Task<ActionResult<BoolResponse>> DeleteProduct(Guid id)
		{
			try
			{
				var command = new DeleteProductCommand { Id = id };
				await _mediator.Send(command);
				return Ok(new BoolResponse(true, "Product deleted successfully."));
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new BoolResponse(false, $"Error deleting product: {ex.Message}"));
			}
		}
	}
}

