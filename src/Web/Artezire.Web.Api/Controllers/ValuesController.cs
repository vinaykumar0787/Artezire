using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Artezire.Data.Core;
using Microsoft.Extensions.Configuration;

namespace Artezire.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        private IProductRepository _productRepository;
        private IConfiguration _config;

        public ValuesController(IProductRepository _productRepository, IConfiguration _config)
        {
            this._productRepository = _productRepository;
            this._config = _config;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var data = _productRepository.GetAllProducts();
            return new string[] { "value1", "value2", _config.GetConnectionString("DefaultConnection") };
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
