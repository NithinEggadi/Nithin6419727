using Microsoft.AspNetCore.Mvc;
using WebApi_4.Models;

namespace WebApi_4.Controllers 

{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // Hardcoded employee list
        private static List<Employee> employees = new()
        {
            new Employee { Id = 1, Name = "Alice", Department = "HR", Salary = 50000 },
            new Employee { Id = 2, Name = "Bob", Department = "IT", Salary = 60000 },
            new Employee { Id = 3, Name = "Charlie", Department = "Finance", Salary = 55000 }
        };

        // ✅ PUT method to update an employee
        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(int id, [FromBody] Employee updatedEmp)
        {
            // 🔴 Validate id
            if (id <= 0)
                return BadRequest("Invalid employee id");

            // 🔍 Find employee
            var existingEmp = employees.FirstOrDefault(e => e.Id == id);

            if (existingEmp == null)
                return BadRequest("Employee not found");

            // ✅ Update properties
            existingEmp.Name = updatedEmp.Name;
            existingEmp.Department = updatedEmp.Department;
            existingEmp.Salary = updatedEmp.Salary;

            return Ok(existingEmp);
        }
    }
}