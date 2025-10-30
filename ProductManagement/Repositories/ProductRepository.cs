using Microsoft.EntityFrameworkCore;
using ProductManagement.Data;
using ProductManagement.Models;
using ProductManagement.Repositories.Interfaces;

namespace ProductManagement.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _db;
        public ProductRepository(AppDbContext db) => _db = db;

        public async Task<IEnumerable<Product>> GetAllAsync()
            => await _db.Products.ToListAsync();

        public async Task<Product?> GetByIdAsync(int id)
            => await _db.Products.FindAsync(id);

        public async Task AddAsync(Product p)
        {
            _db.Products.Add(p);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product p)
        {
            _db.Products.Update(p);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var p = await _db.Products.FindAsync(id);
            if (p != null)
            {
                _db.Products.Remove(p);
                await _db.SaveChangesAsync();
            }
        }
    }
}
