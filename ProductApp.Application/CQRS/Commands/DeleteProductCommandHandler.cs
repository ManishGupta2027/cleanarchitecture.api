using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductApp.Application.Services.Products;
using ProductApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.CQRS.Commands
{
	public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
	{
		private readonly IProductService _productService;

		public DeleteProductCommandHandler(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
		{
			// Call the product service to delete the product
			await _productService.DeleteProductAsync(request.Id);
			return Unit.Value; // Return a unit value to signify completion
		}
	}
}
