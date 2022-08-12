using JWTAuthentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private List<Employee> _employees = new List<Employee>();

        public EmployeesController()
        {
            _employees.Add(new Employee
            {
                Id = 1,
                Name = "Vraj Shah",
                DateOfBirth = new DateTime(1999, 07, 09),
                Salary = 25000,
                Permanent = true,
                Department = new Department { Id = 1, DeptName = "Computer" },
                Skills = new List<Skill>()
                {
                    new Skill { Id = 1, SkillName = "Gaming" }
                }
            });

        }

        // GET: api/<EmployeesController>
        [HttpGet]
        [Authorize(Roles = "Admin,POC")]
        public IActionResult Get()
        {
            return Ok(_employees);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "POC")]
        public IActionResult Get(int id)
        {
            return Ok(_employees.FirstOrDefault(c => c.Id == id));
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public IActionResult Post([FromBody] Employee emp)
        {
            if (ModelState.IsValid)
            {
                _employees.Add(emp);
                return Ok(_employees);
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
            Employee employee = _employees.FirstOrDefault(c => c.Id == id);
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
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Employee Id");
            Employee employee = _employees.FirstOrDefault(c => c.Id == id);
            if (employee == null)
                return BadRequest("Invalid Employee Id");
            _employees.Remove(employee);
            return Ok(_employees);
        }

    }
}
