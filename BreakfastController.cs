using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _3045_002_FinalApiProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreakfastController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public BreakfastController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<Breakfast>> Get()
        {
            return await _db.Breakfast.ToListAsync();
        }

        [HttpGet("{id?}")]
        public async Task<ActionResult<IEnumerable<Breakfast>>> Get(int? id)
        {
            if (id == null || id == 0)
            {
                // Return first 5 records
                return await _db.Breakfast.Take(5).ToListAsync();
            }

            var breakfast = await _db.Breakfast.FindAsync(id);
            if (breakfast == null) return NotFound();
            return new List<Breakfast> { breakfast };
        }

        [HttpPost]
        public async Task<ActionResult<Breakfast>> Post(Breakfast breakfast)
        {
            _db.Breakfast.Add(breakfast);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = breakfast.ID }, breakfast);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Breakfast updated)
        {
            if (id != updated.ID) return BadRequest();
            _db.Entry(updated).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var breakfast = await _db.Breakfast.FindAsync(id);
            if (breakfast == null) return NotFound();
            _db.Breakfast.Remove(breakfast);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
