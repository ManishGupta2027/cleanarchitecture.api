using MediatR;
using ProductApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.CQRS.Queries.Brands
{
    public class GetBrandByIdQuery : IRequest<BrandDto>
    {
        public Guid Id { get; set; }
    }
}
