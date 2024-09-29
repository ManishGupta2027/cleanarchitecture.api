using MediatR;
using ProductApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.CQRS.Queries
{
    public class GetAllProductsQuery : IRequest<List<ProductDto>>
    {
    }
}
