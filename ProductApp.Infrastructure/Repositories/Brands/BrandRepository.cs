using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Entities.Brands;
using ProductApp.Domain.Repositories.Brands;
using ProductApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Infrastructure.Repositories.Brands
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public BrandRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> AddAsync(Brand brand)
        {
            _dbContext.Brands.Add(brand);
            await _dbContext.SaveChangesAsync();
            return brand.Id;
        }

        public async Task DeleteAsync(Guid id)
        {var brand = await _dbContext.Brands.FindAsync(id);
            if (brand != null)
            {
                _dbContext.Brands.Remove(brand);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Brand>> GetAllAsync()
        {
           return await _dbContext.Brands.ToListAsync();
        }

        public async Task<Brand> GetByIdAnsyc(Guid id)
        {
            return await _dbContext.Brands.FindAsync(id);
        }

        public async Task UpdateAsync(Brand brand)
        {
           _dbContext.Brands.Update(brand);
            await _dbContext.SaveChangesAsync();
        }
    }
}
