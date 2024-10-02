using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Entities;
using ProductApp.Domain.Repositories.Products;
using ProductApp.Infrastructure.Data;

namespace ProductApp.Infrastructure.Repositories.Products
{
	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public ProductRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Product> GetByIdAsync(Guid id)
		{
			return await _dbContext.Products.FindAsync(id);
		}

		public async Task<List<Product>> GetAllAsync()
		{
			return await _dbContext.Products.ToListAsync();
		}

		public async Task<Guid> AddAsync(Product product)
		{
			_dbContext.Products.Add(product);
			await _dbContext.SaveChangesAsync();
			return product.Id;
		}

		public async Task UpdateAsync(Product product)
		{
			_dbContext.Products.Update(product);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(Guid id)
		{
			var product = await _dbContext.Products.FindAsync(id);
			if (product != null)
			{
				_dbContext.Products.Remove(product);
				await _dbContext.SaveChangesAsync();
			}
		}

	}
}
