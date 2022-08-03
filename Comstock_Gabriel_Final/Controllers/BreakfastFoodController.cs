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
    public class BreakfastFoodController : ControllerBase
    {

        private readonly ILogger<BreakfastFoodController> _logger;
        private readonly IBreakfastFoodContextDAO _context;

        public BreakfastFoodController(ILogger<BreakfastFoodController> logger, IBreakfastFoodContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

        private List<BreakfastFood> Get()
        {
            var foods = _context.GetAllFoods();
            return foods;
        }

        [HttpGet("id")]
        public IActionResult GetByID(int id)
        {
            if(id == 0)
                return Ok(Get());
            var food = _context.GetFoodById(id);
            if (food == null)
                return NotFound(id);
            return Ok(food);
        }
        
        [HttpPost]
        public IActionResult Post(BreakfastFood food)
        {
            var result = _context.Add(food);

            if (result == null)
                return StatusCode(500, "Breakfast food already exists.");

            if (result == 0)
                return StatusCode(500, "Error occurred while processing your request.");
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _context.RemoveFoodById(id);
            if(result == null)
                return NotFound(id);
            if(result == 0)
                return StatusCode(500, "An error occurred while processing your request.");
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(BreakfastFood food)
        {
            
            var result = _context.UpdateFood(food);
            if(result == null)
                return NotFound(food.FoodId);
            if(result == 0)
                return StatusCode(500, "An error occurred while processing your request.");
            return Ok();
        }
        
    }
}
