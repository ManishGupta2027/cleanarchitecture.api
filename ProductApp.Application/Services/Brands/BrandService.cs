using AutoMapper;
using ProductApp.Application.DTOs;
using ProductApp.Domain.Entities;
using ProductApp.Domain.Entities.Brands;
using ProductApp.Domain.Repositories.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Services.Brands
{
    public class BrandService : IBrandService
    {
        private IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        public BrandService(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<Guid> CreateBrandAsync(BrandDto brandDto)
        {
            var brand = _mapper.Map<Brand>(brandDto);
            return await _brandRepository.AddAsync(brand);
        }

        public async Task<List<BrandDto>> GetAllBrandsAsync()
        {
            var brands = await _brandRepository.GetAllAsync();
            return _mapper.Map<List<BrandDto>>(brands);
        }
    }
}
s