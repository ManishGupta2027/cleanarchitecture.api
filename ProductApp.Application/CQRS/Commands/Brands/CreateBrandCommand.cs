﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.CQRS.Commands.Brands
{
    public class CreateBrandCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription {  get; set; }   

    }
}
