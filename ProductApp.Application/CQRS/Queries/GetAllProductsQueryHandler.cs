using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductApp.Application.DTOs;
using ProductApp.Domain.Repositories;
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
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;

		public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_mapper = mapper;
		}

		public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
		{
			var products = await _productRepository.GetAllAsync();
			return _mapper.Map<List<ProductDto>>(products);
		}
	}
}
