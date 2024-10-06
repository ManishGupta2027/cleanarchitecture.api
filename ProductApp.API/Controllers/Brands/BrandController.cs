using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.CQRS.Commands;
using ProductApp.Application.CQRS.Commands.Brands;
using ProductApp.Application.CQRS.Queries;
using ProductApp.Application.CQRS.Queries.Brands;
using ProductApp.Application.DTOs;
using ProductApp.Application.Responses;

namespace ProductApp.API.Controllers.Brands
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<Guid>>> CreateBrand([FromBody] CreateBrandCommand command)
        {
            try
            {
                var brandId = await _mediator.Send(command);
                var response = new ApiResponse<Guid>(true, brandId, "Brand Created Successfully");
                return CreatedAtAction(nameof(GetBrandById), new { id = brandId }, response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<Guid>(false, Guid.Empty, $"Error creating product: {ex.Message}", StatusCodes.Status500InternalServerError);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<BoolResponse>> UpdateBrand(Guid id, [FromBody] UpdateBrandCommand command)
        {
            try
            {
                if (id != command.Id)
                {
                    return BadRequest(new BoolResponse(false, "Brand ID mismatch."));
                }

                await _mediator.Send(command);
                return Ok(new BoolResponse(true, "Brand updated successfully."));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BoolResponse(false, $"Error updating product: {ex.Message}"));
            }
        }

        // GET: api/brands/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<BrandDto>>> GetBrandById(Guid id)
        {
            try
            {
                var query = new GetBrandByIdQuery { Id = id };
                var brand = await _mediator.Send(query);

                if (brand == null)
                {
                    var response = new ApiResponse<BrandDto>(false, brand, "Brand retrieved successfully.", StatusCodes.Status404NotFound);
                    return NotFound(response);
                }

                var successResponse = new ApiResponse<BrandDto>(true, brand, "Brand retrieved successfully.", StatusCodes.Status200OK);
                return Ok(successResponse);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<BrandDto>(false, null, $"Error retrieving brand: {ex.Message}", StatusCodes.Status500InternalServerError);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        // GET: api/brands
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<BrandDto>>>> GetAllBrand()
        {
            try
            {
                var query = new GetAllBrandsQuery();
                var brands = await _mediator.Send(query);
                var successResponse = new ApiResponse<List<BrandDto>>(true, brands, "Brand retrieved successfully.", StatusCodes.Status200OK);
                return Ok(successResponse);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<List<BrandDto>>(false, null, $"Error retrieving brands: {ex.Message}", StatusCodes.Status500InternalServerError);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        // DELETE: api/brand/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<BoolResponse>> DeleteBrand(Guid id)
        {
            try
            {
                var command = new DeleteBrandCommand { Id = id };
                await _mediator.Send(command);
                return Ok(new BoolResponse(true, "Brand deleted successfully."));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BoolResponse(false, $"Error deleting product: {ex.Message}"));
            }
        }
    }
}
