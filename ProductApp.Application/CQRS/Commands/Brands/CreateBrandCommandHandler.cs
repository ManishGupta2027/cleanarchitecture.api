using MediatR;
using ProductApp.Application.DTOs;
using ProductApp.Application.Services.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.CQRS.Commands.Brands
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Guid>
    {
        private readonly IBrandService _brandService;
        public CreateBrandCommandHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public async Task<Guid> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brandDto = new BrandDto
            {
                Name = request.Name,
                Description = request.Description,
                ShortDescription = request.ShortDescription,
            };
            return await _brandService.CreateBrandAsync(brandDto);
        }
    }
}
