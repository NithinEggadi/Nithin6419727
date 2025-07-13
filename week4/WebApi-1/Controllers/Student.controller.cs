using Microsoft.AspNetCore.Mvc;
using WebApi_1.Models;

namespace WebApi_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Alice" },
            new Student { Id = 2, Name = "Bob" },
            new Student { Id = 3, Name = "Charlie" }
        };

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound("Student not found");

            return Ok(student);
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            if (string.IsNullOrWhiteSpace(student.Name))
                return BadRequest("Name cannot be empty");

            student.Id = students.Max(s => s.Id) + 1;
            students.Add(student);

            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound("Student not found");

            if (string.IsNullOrWhiteSpace(updatedStudent.Name))
                return BadRequest("Name cannot be empty");

            student.Name = updatedStudent.Name;
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound("Student not found");

            students.Remove(student);
            return Ok($"{student.Name} removed");
        }
    }
}