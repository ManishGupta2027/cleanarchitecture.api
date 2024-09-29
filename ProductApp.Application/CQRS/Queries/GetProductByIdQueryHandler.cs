using AutoMapper;
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

namespace ProductApp.Application.CQRS.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
		private readonly IProductService _productService;
        public GetProductByIdQueryHandler(IProductService productService)
        {
            _productService = productService;

		}

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {

            return await _productService.GetProductByIdAsync(request.Id);

		}
    }
}
