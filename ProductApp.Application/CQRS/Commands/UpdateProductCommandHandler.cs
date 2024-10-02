using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductApp.Application.DTOs;
using ProductApp.Application.Services.Products;
using ProductApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.CQRS.Commands
{
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
	{
		private readonly IProductService _productService;

		public UpdateProductCommandHandler(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
		{
			// Create a ProductDto object from the command properties
			var productDto = new ProductDto
			{
				Id = request.Id,
				Name = request.Name,
                StockCode = request.StockCode,
				Price = request.Price,
                StockQTY = request.StockQTY
                // Map other properties as needed
            };

			// Call the product service to update the product
			await _productService.UpdateProductAsync(productDto);
			return Unit.Value; // Return a unit value to signify completion
		}
	}
}
