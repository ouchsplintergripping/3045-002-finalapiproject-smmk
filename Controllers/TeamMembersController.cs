using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _3045_002_FinalApiProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamMembersController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public TeamMembersController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<TeamMember>> Get()
        {
            return await _db.TeamMembers.ToListAsync();
        }

        [HttpGet("{id?}")]
        public async Task<ActionResult<IEnumerable<TeamMember>>> Get(int? id)
        {
            if (id == null || id == 0)
            {
                // Return first 5 records
                return await _db.TeamMembers.Take(5).ToListAsync();
            }
            
            var member = await _db.TeamMembers.FindAsync(id);
            if (member == null) return NotFound();
            return new List<TeamMember> { member };
        }

        [HttpPost]
        public async Task<ActionResult<TeamMember>> Post(TeamMember member)
        {
            _db.TeamMembers.Add(member);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = member.Id }, member);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TeamMember updated)
        {
            if (id != updated.Id) return BadRequest();
            _db.Entry(updated).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var member = await _db.TeamMembers.FindAsync(id);
            if (member == null) return NotFound();
            _db.TeamMembers.Remove(member);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
