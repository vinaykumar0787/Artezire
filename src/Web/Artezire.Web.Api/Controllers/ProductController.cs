using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Artezire.Data.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Cors;
using Artezire.Data.Entities;
using System.IO;


namespace Artezire.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    public class ProductController : Controller
    {

        private IProductRepository _productRepository;
        private IConfiguration _config;

        public ProductController(IProductRepository _productRepository, IConfiguration _config)
        {
            this._productRepository = _productRepository;
            this._config = _config;
        }

        // GET api/values
        [HttpGet]
        //[Authorize]
        public async Task<IEnumerable<Product>> Get()
        {
            var products = await _productRepository.GetAllProducts();
            //return new string[] { "value1", "value2", _config.GetConnectionString("DefaultConnection") };
            return products;
        }

        [HttpGet("seedproducts")]
        public string SeedProducts()
        {
            List<Product> products = System.IO.File.ReadAllLines("SeedData//products.csv")
            .Skip(1)
               .Select(x => x.Split(','))
               .Select(x => new Product
               {
                   Id = int.Parse(x[0]),
                   ProductName = x[3],
                   ProductDescription = x[4],
                   ProductTypeId = int.Parse(x[5]),
                   ProductStatusId = int.Parse(x[6]),
                   NoOfLikes = int.Parse(x[7]),
                   Price = double.Parse(x[8])
               }).ToList();

            _productRepository.AddProducts(products);

            return "Products Added";
        }

        // GET api/values/5 
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
