using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.CQRS.Commands
{
    public class CreateProductCommand : IRequest<Guid> // Returns the created product's Id
    {
        public string Name { get; set; }
        public string StockCode { get; set; }
        public decimal Price { get; set; }
        public int StockQTY { get; set; }
    }
}
