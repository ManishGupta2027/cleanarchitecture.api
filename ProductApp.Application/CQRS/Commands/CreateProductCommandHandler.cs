using MediatR;
using ProductApp.Application.DTOs;
using ProductApp.Application.Services.Products;
using ProductApp.Domain.Entities;
using ProductApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.CQRS.Commands
{
	public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
	{
		private readonly IProductService _productService;

		public CreateProductCommandHandler(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
		{
			var productDto = new ProductDto
			{
				Name = request.Name,
				Price = request.Price,
				Stock = request.Stock
			};

			return await _productService.CreateProductAsync(productDto);
		}
	}
}
