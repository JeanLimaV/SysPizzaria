using Microsoft.EntityFrameworkCore;
using SysPizzaria.Domain.Contracts.Interfaces.Repositories;
using SysPizzaria.Domain.Entities;
using SysPizzaria.Infra.Data.Context;

namespace SysPizzaria.Infra.Data.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly BaseDbContext _db;

        public ProductsRepository(BaseDbContext db)
        {
            _db = db;
        }
        
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<Product>> GetProductsAsync()
        {
            return (await _db.Products.ToListAsync())!;
        }
        
        public async Task<Product> GetByCodErp(string codErp)
        {
            return await _db.Products.FirstOrDefaultAsync(p => p.CodERP == codErp);
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _db.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task UpdateAsync(Product product)
        {
            _db.Update(product);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _db.Remove(product);
            await _db.SaveChangesAsync();
        }
    }
}