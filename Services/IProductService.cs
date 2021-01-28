using Products.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Products.Services
{
    public interface IProductService
    {
        Task<bool> Add(Product product);
        Task<bool> Remove(Product product);
        Task<bool> Update(Product product);
        Task<IEnumerable<Product>> List();
        Task<Product> Get(int id);
    }
}
