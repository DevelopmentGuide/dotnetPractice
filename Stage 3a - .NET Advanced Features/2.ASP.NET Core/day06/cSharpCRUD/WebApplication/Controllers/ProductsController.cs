using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductCrudList.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductCrudList.Controllers
{
    public class ProductsController : Controller
    {
        //CRUD: Create Read Update Delete 
        private static List<Product> products = new List<Product>
        {
            new Product{Id=1,Name="pen",Price=30},
            new Product{Id=2,Name="pencil",Price=3},
            new Product{Id=3,Name="eraser",Price=4}
        };

        public IActionResult Index()//Read
        {
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()//Read

        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)//Read
        {
            products.Add(product);
            return View("Index", products);
        }

        [HttpGet]
        public IActionResult Update(int id)//Read
        {
            var product = products.Where(p => p.Id == id).FirstOrDefault();
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(Product product)//Read
        {
            Product productToUpdate = products.Where(p => p.Id == product.Id).FirstOrDefault();
            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;
            return View("Index", products);
        }
        [HttpGet]
        public IActionResult Delete(int id)//Read
        {
            var product = products.Where(p => p.Id == id).FirstOrDefault();
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(Product product)//Read
        {
            Product productToDelete = products.Where(p => p.Id == product.Id).FirstOrDefault();
            products.Remove(productToDelete);
            return View("Index", products);
        }
    }
}
