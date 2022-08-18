using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private ProductManagementDbContext productManagementDbContext;
        public ProductsController(ProductManagementDbContext productManagementDbContext)
        {
            this.productManagementDbContext = productManagementDbContext;
        }

        // INDEX
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productManagementDbContext.Products.ToList();
        }

        // DETAILS
        [Authorize(Roles = "Admin,User")]
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return this.productManagementDbContext.Products.Where(product => product.Id == id).FirstOrDefault();
        }

        // CREATE
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public string Post([FromBody] Product product)
        {
            this.productManagementDbContext.Products.Add(product);
            this.productManagementDbContext.SaveChanges();
            return "Product created successfully!";
        }

        // EDIT
        [Authorize(Roles = Roles.Admin)]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            this.productManagementDbContext.Products.Update(product);
            this.productManagementDbContext.SaveChanges();
        }


        // DELETE
        [Authorize(Roles = Roles.Admin)]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.productManagementDbContext.Products.Remove(this.productManagementDbContext.Products.Where(product => product.Id == id).FirstOrDefault());
            this.productManagementDbContext.SaveChanges();
        }
    }
}
