using Artezire.Data.Access.Repository;
using Artezire.Data.Core;
using Artezire.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artezire.Data.Access
{
    public class ProductRepository : BaseRepository<BaseEntity>, IProductRepository
    {

        #region Constructors and Destructors

        /// <summary>
        /// Constructor to create an instance for Db context
        /// </summary>
        public ProductRepository(ArtezireDbContext _context) : base(_context)
        {
            
        }

        #endregion

        /// <summary>
        /// interface method to fetch products
        /// </summary>
        /// <param ></param>
        /// <returns>Product</returns>
        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                List<Product> products = await (from b in _dbContext.Products
                                                select b).ToListAsync();
                return products;
            }
            catch (Exception ex)
            {

                throw;
            }
            return null;
        }

        public async void AddProducts(List<Product> products)
        {
            try
            {
                _dbContext.Products.AddRange(products);
                await _dbContext.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
