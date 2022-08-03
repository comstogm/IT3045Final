using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Comstock_Gabriel_Final.Models;
using Comstock_Gabriel_Final.Data;
using Comstock_Gabriel_Final.Interfaces;

namespace Comstock_Gabriel_Final.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {

        private readonly ILogger<StudentController> _logger;
        private readonly IStudentContextDAO _context;

        public StudentController(ILogger<StudentController> logger, IStudentContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

         private List<Student> Get()
        {
            var students = _context.GetAllStudents();
            return students;
        }

        [HttpGet("id")]
        public IActionResult GetByID(int id)
        {
            if(id == 0)
                return Ok(Get());
            var student = _context.GetStudentById(id);
            if (student == null)
                return NotFound(id);
            return Ok(student);
        }
        
        [HttpPost]
        public IActionResult Post(Student student)
        {
            var result = _context.Add(student);

            if (result == null)
                return StatusCode(500, "Student already exists.");

            if (result == 0)
                return StatusCode(500, "Error occurred while processing your request.");
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _context.RemoveStudentById(id);
            if(result == null)
                return NotFound(id);
            if(result == 0)
                return StatusCode(500, "An error occurred while processing your request.");
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Student student)
        {
            var result = _context.UpdateStudent(student);
            if(result == null)
                return NotFound(student.StudentId);
            if(result == 0)
                return StatusCode(500, "An error occurred while processing your request.");
            return Ok();
        }
    }
}
