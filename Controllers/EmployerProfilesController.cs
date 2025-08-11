using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortalBackend.Data;
using JobPortalBackend.Models;

namespace JobPortalBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerProfilesController : ControllerBase
    {
        private readonly JobPortalContext _context;

        public EmployerProfilesController(JobPortalContext context)
        {
            _context = context;
        }

        // GET: api/EmployerProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployerProfile>>> GetEmployerProfiles()
        {
            return await _context.EmployerProfiles.ToListAsync();
        }

        // GET: api/EmployerProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployerProfile>> GetEmployerProfile(int id)
        {
            var employerProfile = await _context.EmployerProfiles.FindAsync(id);

            if (employerProfile == null)
            {
                return NotFound();
            }

            return employerProfile;
        }

        // PUT: api/EmployerProfiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployerProfile(int id, EmployerProfile employerProfile)
        {
            if (id != employerProfile.EmployerProfileId)
            {
                return BadRequest();
            }

            _context.Entry(employerProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployerProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmployerProfiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployerProfile>> PostEmployerProfile(EmployerProfile employerProfile)
        {
            _context.EmployerProfiles.Add(employerProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployerProfile", new { id = employerProfile.EmployerProfileId }, employerProfile);
        }

        // DELETE: api/EmployerProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployerProfile(int id)
        {
            var employerProfile = await _context.EmployerProfiles.FindAsync(id);
            if (employerProfile == null)
            {
                return NotFound();
            }

            _context.EmployerProfiles.Remove(employerProfile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployerProfileExists(int id)
        {
            return _context.EmployerProfiles.Any(e => e.EmployerProfileId == id);
        }
    }
}
