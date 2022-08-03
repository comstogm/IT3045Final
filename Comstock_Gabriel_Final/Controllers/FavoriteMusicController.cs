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
    public class FavoriteMusicController : ControllerBase
    {

        private readonly ILogger<FavoriteMusicController> _logger;
        private readonly IFavoriteMusicContextDAO _context;

        public FavoriteMusicController(ILogger<FavoriteMusicController> logger, IFavoriteMusicContextDAO context)
        {
            _logger = logger;
            _context = context;
        }

         private List<Music> Get()
        {
            var musics = _context.GetAllMusic();
            return musics;
        }

        [HttpGet("id")]
        public IActionResult GetByID(int id)
        {
            if(id == 0)
                return Ok(Get());
            var music = _context.GetMusicById(id);
            if (music == null)
                return NotFound(id);
            return Ok(music);
        }
        
        [HttpPost]
        public IActionResult Post(Music music)
        {
            var result = _context.Add(music);

            if (result == null)
                return StatusCode(500, "This music already exists.");

            if (result == 0)
                return StatusCode(500, "Error occurred while processing your request.");
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _context.RemoveMusicById(id);
            if(result == null)
                return NotFound(id);
            if(result == 0)
                return StatusCode(500, "An error occurred while processing your request.");
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Music music)
        {
            var result = _context.UpdateMusic(music);
            if(result == null)
                return NotFound(music.MusicId);
            if(result == 0)
                return StatusCode(500, "An error occurred while processing your request.");
            return Ok();
        }
        
    }
}
