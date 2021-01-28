using Products.Data;
using Products.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) => _context = context;
        public async Task Add(Product product) => await _context.AddAsync(product);
        public async Task<Product> Get(int id) => await _context.Products.FindAsync(id);
        public async Task<IEnumerable<Product>> List() => _context.Products.ToList();
        public async Task Remove(Product product) => _context.Remove(product);
        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
        public async Task Update(Product product) => _context.Update(product);
    }
}
