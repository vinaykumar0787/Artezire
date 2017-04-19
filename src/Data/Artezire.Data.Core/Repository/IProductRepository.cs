using Artezire.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Artezire.Data.Core
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();

        void AddProducts(List<Product> products);
    }
}
