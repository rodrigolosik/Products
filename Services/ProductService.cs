using Products.Models;
using Products.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Products.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo) => _repo = repo;
        public async Task<IEnumerable<Product>> List() => await _repo.List();
        public async Task<Product> Get(int id) => await _repo.Get(id);
        public async Task<bool> Add(Product product)
        {
            await _repo.Add(product);
            return await _repo.SaveChangesAsync();
        }
        public async Task<bool> Remove(Product product)
        {
            await _repo.Remove(product);
            return await _repo.SaveChangesAsync();
        }
        public async Task<bool> Update(Product product)
        {
            await _repo.Update(product);
            return await _repo.SaveChangesAsync();
        }
    }
}
