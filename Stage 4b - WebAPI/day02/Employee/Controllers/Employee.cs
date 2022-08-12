using EmployeeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    // [ApiController]
    public class EmployeesController : Controller
    {
        private List<Employee> employees = new List<Employee>();

        public EmployeesController()
        {
            employees.Add(new Employee
            {
                Id = 25094,
                Name = "Pratik Kabade",
                DateOfBirth = new DateTime(1999, 11, 18),
                Salary = 250000,
                Permanent = true,
                Department = new Department { Id = 25, DeptName = "Development" },
                Skills = new List<Skill>()
                {
                    new Skill { Id = 1, SkillName = "React" },
                    new Skill { Id = 2, SkillName = "DotNet" }
                }
            });
            employees.Add(new Employee
            {
                Id = 25094,
                Name = "Pratik Kabade",
                DateOfBirth = new DateTime(1999, 11, 18),
                Salary = 250000,
                Permanent = true,
                Department = new Department { Id = 25, DeptName = "Development" },
                Skills = new List<Skill>()
                {
                    new Skill { Id = 1, SkillName = "React" },
                    new Skill { Id = 2, SkillName = "DotNet" }
                }
            });
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(employees);
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            Employee emp = employees.Find(p => p.Id == id);
            employees.Remove(emp);
            return "Deleted successfully!";
        }

        // GET: api/<EmployeesController>
        // [HttpGet]
        // public IActionResult Get()
        // {
        //     return Ok(employees);
        // }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(employees.FirstOrDefault(c => c.Id == id));
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public IActionResult Post([FromBody] Employee emp)
        {
            if (ModelState.IsValid)
            {
                employees.Add(emp);
                return Ok(employees);
            }
            else
                return BadRequest();
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee emp)
        {
            if (id <= 0)
                return BadRequest("Invalid Employee Id");
            Employee employee = employees.FirstOrDefault(c => c.Id == id);
            if (employee == null)
                return BadRequest("Invalid Employee Id");
            employee.Name = emp.Name;
            employee.Department = emp.Department;
            employee.DateOfBirth = emp.DateOfBirth;
            employee.Skills = emp.Skills;
            employee.Salary = emp.Salary;
            employee.Permanent = emp.Permanent;
            return Ok(employee);
        }

        // DELETE api/<EmployeesController>/5
        // [HttpDelete("{id}")]
        // public IActionResult Delete(int id)
        // {
        //     Employee employee = employees.FirstOrDefault(c => c.Id == id);
        //     employees.Remove(employee);
        //     return Ok(employees);
        // }
    }
}
