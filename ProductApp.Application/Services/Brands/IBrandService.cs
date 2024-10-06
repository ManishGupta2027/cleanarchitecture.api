using ProductApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Services.Brands
{
    public interface IBrandService
    {
        Task<Guid> CreateBrandAsync(BrandDto brandDto);
        Task UpdateBrandAsync(BrandDto brandDto);
        Task<BrandDto> GetBrandByIdAsync(Guid id);
        Task<List<BrandDto>> GetAllBrandsAsync();
        Task DeleteBrandAsync(Guid id);
    }
}
