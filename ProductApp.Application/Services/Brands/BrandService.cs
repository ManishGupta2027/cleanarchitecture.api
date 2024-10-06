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
        public async Task UpdateBrandAsync(BrandDto brandDto)
        {
            var brand = await _brandRepository.GetByIdAnsyc(brandDto.Id);
            if (brand == null)
            {
                throw new Exception("Brand not found");
            }
            brand.Name = brandDto.Name;
            brand.Description = brandDto.Description;
            brand.ShortDescription = brandDto.ShortDescription;
            await _brandRepository.UpdateAsync(brand);
        }

        public async Task<BrandDto> GetBrandByIdAsync(Guid id)
        {
           var brand = await _brandRepository.GetByIdAnsyc(id);
            if(brand == null)

            {
                throw new Exception("Brand Not Found");
            }
            return _mapper.Map<BrandDto>(brand);
        }

        public async Task<List<BrandDto>> GetAllBrandsAsync()
        {
            var brand = await _brandRepository.GetAllAsync();
            return _mapper.Map<List<BrandDto>>(brand);
        }

        public async Task DeleteBrandAsync(Guid id)
        {
            var brand = await _brandRepository.GetByIdAnsyc(id);
            if(brand == null)
            {
                throw new Exception("Brnad Not Found");
            }
        }
    }
}
