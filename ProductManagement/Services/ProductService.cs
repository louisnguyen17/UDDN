using ProductManagement.Models;
using ProductManagement.Repositories.Interfaces;
using ProductManagement.Services.Interfaces;

namespace ProductManagement.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo) => _repo = repo;

        public Task<IEnumerable<Product>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Product?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Product p) => _repo.AddAsync(p);
        public Task UpdateAsync(Product p) => _repo.UpdateAsync(p);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
