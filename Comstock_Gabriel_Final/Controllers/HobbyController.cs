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
    public class HobbyController : ControllerBase
    {

        private readonly ILogger<HobbyController> _logger;
        private readonly IHobbyContextDAO _context;

        public HobbyController(ILogger<HobbyController> logger, IHobbyContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

        private List<Hobby> Get()
        {
            var hobbies = _context.GetAllHobbies();
            return hobbies;
        }

        [HttpGet("id")]
        public IActionResult GetByID(int id)
        {
            if(id == 0)
                return Ok(Get());
            var hobby = _context.GetHobbyById(id);
            if (hobby == null)
                return NotFound(id);
            return Ok(hobby);
        }
        
        [HttpPost]
        public IActionResult Post(Hobby hobby)
        {
            var result = _context.Add(hobby);

            if (result == null)
                return StatusCode(500, "This hobby already exists.");

            if (result == 0)
                return StatusCode(500, "Error occurred while processing your request.");
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _context.RemoveHobbyById(id);
            if(result == null)
                return NotFound(id);
            if(result == 0)
                return StatusCode(500, "An error occurred while processing your request.");
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Hobby hobby)
        {
            var result = _context.UpdateHobby(hobby);
            if(result == null)
                return NotFound(hobby.HobbyId);
            if(result == 0)
                return StatusCode(500, "An error occurred while processing your request.");
            return Ok();
        }
    }
}
