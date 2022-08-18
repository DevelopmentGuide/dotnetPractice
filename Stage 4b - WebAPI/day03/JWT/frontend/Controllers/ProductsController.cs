using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using frontend.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace frontend.Controllers
{

    public class ProductsController : Controller
    {
        //INDEX
        private static HttpClient httpClient = new HttpClient();
        public ProductsController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            var response = await httpClient.GetAsync(Configuration.GetValue<string>("WebAPIBaseUrl") + "/products");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var products = new List<Product>();
                if (response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    products = JsonConvert.DeserializeObject<List<Product>>(content);
                }
                return View(products);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }


        //CREATE
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var serializedProductToCreate = JsonConvert.SerializeObject(product);
                var request = new HttpRequestMessage(HttpMethod.Post, Configuration.GetValue<string>("WebAPIBaseUrl") + "/products");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedProductToCreate);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Products");
                }
                else
                {
                    ViewBag.Message = "Admin access required";
                    return View("Create");
                }
            }
            else
                return View("Create");
        }


        //EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await httpClient.GetAsync(Configuration.GetValue<string>("WebAPIBaseUrl") + $"/products/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var product = new Product();
            if (response.Content.Headers.ContentType.MediaType == "application/json")
            {
                product = JsonConvert.DeserializeObject<Product>(content);
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                var serializedProductToEdit = JsonConvert.SerializeObject(product);
                var request = new HttpRequestMessage(HttpMethod.Put, Configuration.GetValue<string>("WebAPIBaseUrl") + $"/products/{product.Id}");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedProductToEdit);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Products");
                }
                else
                {
                    ViewBag.Message = "Admin access required";
                    return View("Edit");
                }
            }
            else
                return View("Edit");
        }



        //DELETE
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await httpClient.GetAsync(Configuration.GetValue<string>("WebAPIBaseUrl") + $"/products/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var product = new Product();
            if (response.Content.Headers.ContentType.MediaType == "application/json")
            {
                product = JsonConvert.DeserializeObject<Product>(content);
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            if (ModelState.IsValid)
            {
                //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                var serializedProductToDelete = JsonConvert.SerializeObject(product);
                var request = new HttpRequestMessage(HttpMethod.Delete, Configuration.GetValue<string>("WebAPIBaseUrl") + $"/products/{product.Id}");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedProductToDelete);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Products");
                }
                else
                {
                    ViewBag.Message = "Admin access required";
                    return View("Delete");
                }
            }
            else
                ViewBag.Message = "wrong";
            return View("Delete");
        }
    }
}
