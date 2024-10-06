using MediatR;
using ProductApp.Application.DTOs;
using ProductApp.Application.Services.Brands;
using ProductApp.Application.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.CQRS.Commands.Brands
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand>
    {
        private readonly IBrandService _brandService;

        public UpdateBrandCommandHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<Unit> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brandDto = new BrandDto
            {
                Id=request.Id,
                Name = request.Name,
                Description = request.Description,
                ShortDescription = request.ShortDescription,
            };
            await _brandService.UpdateBrandAsync(brandDto);
            return Unit.Value;
        }
    }
}
