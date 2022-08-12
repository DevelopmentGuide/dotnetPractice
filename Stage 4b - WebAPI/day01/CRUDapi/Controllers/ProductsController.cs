using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDapi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUDapi.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product{Id=1,Name="pen",Price=35},
            new Product{Id=2,Name="pencil",Price=5},
            new Product{Id=3,Name="eraser",Price=3},
            new Product{Id=4,Name="sharpner",Price=5},
            new Product{Id=5,Name="notebook",Price=45}
        };
        // GET: api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return products;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            Product product = products.Find(p => p.Id == id);
            return product;
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody] Product product)
        {
            products.Add(product);
            return "Product created successfully!";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Product product)
        {
            Product pro = products.Find(p => p.Id == id);
            pro.Name = product.Name;
            pro.Price = product.Price;
            return "Product updated successfully!";
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            Product pro = products.Find(p => p.Id == id);
            products.Remove(pro);
            return "Deleted successfully!";
        }
    }
}
