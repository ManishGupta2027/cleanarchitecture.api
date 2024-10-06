using MediatR;
using ProductApp.Application.DTOs;
using ProductApp.Application.Services.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.CQRS.Queries.Brands
{
    public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, List<BrandDto>>
    {
        private readonly IBrandService _brandService;
        public GetAllBrandsQueryHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public async Task<List<BrandDto>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            return await _brandService.GetAllBrandsAsync();

        }
    }
}
