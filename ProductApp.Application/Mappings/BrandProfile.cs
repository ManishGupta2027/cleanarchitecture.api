using AutoMapper;
using ProductApp.Application.DTOs;
using ProductApp.Domain.Entities;
using ProductApp.Domain.Entities.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Mappings
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, BrandDto>().ReverseMap();
        }
    }
}
