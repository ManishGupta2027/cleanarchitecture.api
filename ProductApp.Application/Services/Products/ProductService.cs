using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProductApp.Application.DTOs;
using ProductApp.Domain.Entities;
using ProductApp.Domain.Repositories.Products;

namespace ProductApp.Application.Services.Products
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;

		public ProductService(IProductRepository productRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_mapper = mapper;
		}

		public async Task<int> CreateProductAsync(ProductDto productDto)
		{
			var product = _mapper.Map<Product>(productDto);
			// Business logic, e.g., discount calculations
			product.Price = CalculateDiscount(product.Price);
			return await _productRepository.AddAsync(product);
		}

		public async Task UpdateProductAsync(ProductDto productDto)
		{
			// Ensure the product exists
			var product = await _productRepository.GetByIdAsync(productDto.Id);
			if (product == null)
			{
				throw new KeyNotFoundException("Product not found");
			}

			// Update the product entity properties
			product.Name = productDto.Name;
			product.Price = productDto.Price;
			product.Stock = productDto.Stock;
			// Update other properties as needed

			await _productRepository.UpdateAsync(product);
		}

		public async Task<ProductDto> GetProductByIdAsync(int id)
		{
			var product = await _productRepository.GetByIdAsync(id);
			if (product == null)
			{
				throw new Exception("Product not found");
			}
			return _mapper.Map<ProductDto>(product);
		}

		public async Task<List<ProductDto>> GetAllProductsAsync()
		{
			var products = await _productRepository.GetAllAsync();
			return _mapper.Map<List<ProductDto>>(products);
		}

		public async Task DeleteProductAsync(int id)
		{
			// Ensure the product exists (optional)
			var product = await _productRepository.GetByIdAsync(id);
			if (product == null)
			{
				throw new KeyNotFoundException("Product not found");
			}

			await _productRepository.DeleteAsync(id);
		}

		private decimal CalculateDiscount(decimal price)
		{
			// Example business logic for discount calculation
			return price * 0.9m; // 10% discount
		}
	}
}
