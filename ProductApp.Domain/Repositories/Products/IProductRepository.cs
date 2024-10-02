using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductApp.Domain.Entities;

namespace ProductApp.Domain.Repositories.Products
{
	public interface IProductRepository
	{
		Task<Product> GetByIdAsync(Guid id);
		Task<List<Product>> GetAllAsync();
		Task<Guid> AddAsync(Product product);
		Task UpdateAsync(Product product);
		Task DeleteAsync(Guid id);
	}
}
