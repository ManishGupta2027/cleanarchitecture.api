using ProductApp.Domain.Entities;
using ProductApp.Domain.Entities.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Domain.Repositories.Brands
{
    public interface IBrandRepository
    {
        Task<Brand> GetByIdAnsyc(Guid id);
        Task<List<Brand>> GetAllAsync();
        Task<Guid> AddAsync(Brand brand);
        Task UpdateAsync(Brand brand);
        Task DeleteAsync(Guid id);
    }
}
