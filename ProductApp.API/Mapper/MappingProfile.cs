using AutoMapper;
using ProductApp.Application.DTOs;
using ProductApp.Domain.Entities;

namespace ProductApp.API.Mapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			// Map Product to ProductDto and vice versa
			CreateMap<Product, ProductDto>().ReverseMap();
		}
	}
}
