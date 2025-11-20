using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _3045_002_finalapiproject_smmk.Data;
using _3045_002_finalapiproject_smmk.Models;

namespace _3045_002_finalapiproject_smmk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Pets or api/Pets/0
        [HttpGet("{id?}")]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets(int? id)
        {
            if (id == null || id == 0)
                return await _context.Pets.Take(5).ToListAsync();

            var pet = await _context.Pets.FindAsync(id);
            if (pet == null) return NotFound();
            return new List<Pet> { pet };
        }

        // POST: api/Pets
        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet(Pet pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPets), new { id = pet.PetID }, pet);
        }

        // PUT: api/Pets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPet(int id, Pet pet)
        {
            if (id != pet.PetID) return BadRequest();
            _context.Entry(pet).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Pets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null) return NotFound();
            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
