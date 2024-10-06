using MediatR;
using ProductApp.Application.CQRS.Commands.Brands;
using ProductApp.Application.Services.Brands;
using ProductApp.Application.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.CQRS.Commands.Brands
{
    public class DeleteBrandCommandHandler : IRequestHandler < DeleteBrandCommand>
    {
        private readonly IBrandService _brandService;

        public DeleteBrandCommandHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public async Task<Unit> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            await _brandService.DeleteBrandAsync(request.Id);
            return Unit.Value;
        }
    }
}
