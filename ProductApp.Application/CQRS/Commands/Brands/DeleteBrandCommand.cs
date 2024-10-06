using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.CQRS.Commands.Brands
{
    public class DeleteBrandCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
