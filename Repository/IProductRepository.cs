using Products.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Products.Repository
{
    public interface IProductRepository
    {
        Task Add(Product product);
        Task Remove(Product product);
        Task Update(Product product);
        Task<IEnumerable<Product>> List();
        Task<Product> Get(int id);
        Task<bool> SaveChangesAsync();
    }
}
