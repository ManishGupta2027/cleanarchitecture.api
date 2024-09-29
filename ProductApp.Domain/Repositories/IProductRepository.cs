using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductApp.Domain.Entities;

namespace ProductApp.Domain.Repositories
{
	public interface IProductRepository
	{
		Task<Product> GetByIdAsync(int id);
		Task<List<Product>> GetAllAsync();
		Task<int> AddAsync(Product product);
		Task UpdateAsync(Product product);
		Task DeleteAsync(int id);
	}
}
