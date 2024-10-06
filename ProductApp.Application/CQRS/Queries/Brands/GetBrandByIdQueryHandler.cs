using MediatR;
using ProductApp.Application.DTOs;
using ProductApp.Application.Services.Brands;
using ProductApp.Application.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.CQRS.Queries.Brands
{
    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, BrandDto>
    {
        private readonly IBrandService _brandService;
        public GetBrandByIdQueryHandler(IBrandService brandService)
        {
            _brandService = brandService;

        }

        public async Task<BrandDto> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {

            return await _brandService.GetBrandByIdAsync(request.Id);

        }
    }
}
