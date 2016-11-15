using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Artezire.Data.Core;
using Artezire.Data.Entities;

namespace Artezire.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    public class ProductController : Controller
    {
        public IProductRepository _productRepo { get; set; }

        public ProductController(IProductRepository _productRepo)
        {
            this._productRepo = _productRepo;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productRepo.GetAllProducts();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<string> Get(int id)
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
