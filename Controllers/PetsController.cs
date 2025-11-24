using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _3045_002_FinalApiProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public PetsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<Pet>> Get()
        {
            return await _db.Pets.ToListAsync();
        }

        [HttpGet("{id?}")]
        public async Task<ActionResult<IEnumerable<Pet>>> Get(int? id)
        {
            if (id == null || id == 0)
            {
                // Return first 5 records
                return await _db.Pets.Take(5).ToListAsync();
            }
            
            var pet = await _db.Pets.FindAsync(id);
            if (pet == null) return NotFound();
            return new List<Pet> { pet };
        }

        [HttpPost]
        public async Task<ActionResult<Pet>> Post(Pet pet)
        {
            _db.Pets.Add(pet);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = pet.PetID }, pet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Pet updated)
        {
            if (id != updated.PetID) return BadRequest();
            _db.Entry(updated).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pet = await _db.Pets.FindAsync(id);
            if (pet == null) return NotFound();
            _db.Pets.Remove(pet);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
