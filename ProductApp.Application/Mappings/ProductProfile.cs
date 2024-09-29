using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProductApp.Application.DTOs;
using ProductApp.Domain.Entities;

namespace ProductApp.Application.Mappings
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			CreateMap<Product, ProductDto>().ReverseMap();
		}
	}
}
