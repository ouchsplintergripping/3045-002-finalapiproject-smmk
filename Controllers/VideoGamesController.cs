using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _3045_002_FinalApiProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoGamesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public VideoGamesController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<VideoGame>> Get()
        {
            return await _db.VideoGames.ToListAsync();
        }

        [HttpGet("{id?}")]
        public async Task<ActionResult<IEnumerable<VideoGame>>> Get(int? id)
        {
            if (id == null || id == 0)
            {
                // Return first 5 records
                return await _db.VideoGames.Take(5).ToListAsync();
            }
            
            var game = await _db.VideoGames.FindAsync(id);
            if (game == null) return NotFound();
            return new List<VideoGame> { game };
        }

        [HttpPost]
        public async Task<ActionResult<VideoGame>> Post(VideoGame game)
        {
            _db.VideoGames.Add(game);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = game.Id }, game);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, VideoGame updated)
        {
            if (id != updated.Id) return BadRequest();
            _db.Entry(updated).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var game = await _db.VideoGames.FindAsync(id);
            if (game == null) return NotFound();
            _db.VideoGames.Remove(game);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
