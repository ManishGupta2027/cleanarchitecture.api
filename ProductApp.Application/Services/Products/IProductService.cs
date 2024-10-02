using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductApp.Application.DTOs;

namespace ProductApp.Application.Services.Products
{
	public interface IProductService
	{
		Task<Guid> CreateProductAsync(ProductDto productDto);
		Task UpdateProductAsync(ProductDto productDto);
		Task<ProductDto> GetProductByIdAsync(Guid id);
		Task<List<ProductDto>> GetAllProductsAsync();
		Task DeleteProductAsync(Guid id);
	}
}
