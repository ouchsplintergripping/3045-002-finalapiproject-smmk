using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FinalProject_Member_Info_Table.Models;
using System.Threading.Tasks;

namespace FinalProject_Member_Info_Table.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMembersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeamMembersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> Get(int id)
        {
            if (id == null || id == 0)
            {
                return Ok (await _context.TeamMembers.Take(5).ToListAsync());
            }
            var member = await _context.TeamMembers.FindAsync(id);
            if (member == null) return NotFound();
            return Ok(member);
        }

        [HttpPost]

        public async Task<IActionResult> Post(TeamMember member)
        {
            _context.TeamMembers.Add(member);   
            await _context.SaveChangesAsync();  
            return CreatedAtAction(nameof(Get), new { id = member.Id }, member);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, TeamMember member)
        {
            if (id != member.Id) return BadRequest();
            _context.Entry(member).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var member = await _context.TeamMembers.FindAsync(id);
            if (member == null) return NotFound();
            _context.TeamMembers.Remove(member);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
