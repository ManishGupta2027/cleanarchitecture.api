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
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
		private readonly IProductService _productService;
		

        public GetAllProductsQueryHandler(IProductService productService)
        {
			_productService = productService;
			
        }

        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
			return await _productService.GetAllProductsAsync();
          
        }
    }
}
