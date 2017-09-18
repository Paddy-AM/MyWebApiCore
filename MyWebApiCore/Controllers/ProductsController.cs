using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWebApiCore.Models;
using Microsoft.EntityFrameworkCore;

namespace MyWebApiCore.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private WebapicoreContext _dbContext { get; set; }

        public ProductsController(WebapicoreContext dbContext)
        {
            _dbContext = dbContext;
        }
     
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _dbContext.Product.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            return await _dbContext.Product.FindAsync(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Product value)
        {
            _dbContext.Product.Add(value);
            _dbContext.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product value)
        {
            _dbContext.Update(value);
            _dbContext.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dbContext.Product.Remove(_dbContext.Product.Single(a => a.Id == id));
            _dbContext.SaveChanges();
        }

        // DELETE api/values/5
        [HttpPatch("{id}")]
        public void Patch(int id, [FromBody]Product value)
        {
            _dbContext.Update(value);
            _dbContext.SaveChanges();
        }
    }
}
