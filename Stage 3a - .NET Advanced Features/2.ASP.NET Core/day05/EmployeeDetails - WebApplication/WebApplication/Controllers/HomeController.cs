using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult EmployeeDetails()
        {
            List<Employee> Employeedetails = new List<Employee>
        {
            new Employee{id = 1,name = "John",salary = 10000,isPermanent = true},
            new Employee{id = 2,name = "Smith",salary = 5000,isPermanent = false},
            new Employee{id = 3,name = "Mark",salary = 5000,isPermanent = false},
            new Employee{id = 4,name = "Mary",salary = 5000,isPermanent = false},
        };
            return View(Employeedetails);
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
