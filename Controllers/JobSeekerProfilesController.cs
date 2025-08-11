using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobPortalBackend.Data;
using JobPortalBackend.Models;

namespace JobPortalBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekerProfilesController : ControllerBase
    {
        private readonly JobPortalContext _context;

        public JobSeekerProfilesController(JobPortalContext context)
        {
            _context = context;
        }

        // GET: api/JobSeekerProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobSeekerProfile>>> GetJobSeekerProfiles()
        {
            return await _context.JobSeekerProfiles.ToListAsync();
        }

        // GET: api/JobSeekerProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobSeekerProfile>> GetJobSeekerProfile(int id)
        {
            var jobSeekerProfile = await _context.JobSeekerProfiles.FindAsync(id);

            if (jobSeekerProfile == null)
            {
                return NotFound();
            }

            return jobSeekerProfile;
        }

        // PUT: api/JobSeekerProfiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobSeekerProfile(int id, JobSeekerProfile jobSeekerProfile)
        {
            if (id != jobSeekerProfile.JobSeekerProfileId)
            {
                return BadRequest();
            }

            _context.Entry(jobSeekerProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobSeekerProfileExists(id))
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

        // POST: api/JobSeekerProfiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobSeekerProfile>> PostJobSeekerProfile(JobSeekerProfile jobSeekerProfile)
        {
            _context.JobSeekerProfiles.Add(jobSeekerProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobSeekerProfile", new { id = jobSeekerProfile.JobSeekerProfileId }, jobSeekerProfile);
        }

        // DELETE: api/JobSeekerProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobSeekerProfile(int id)
        {
            var jobSeekerProfile = await _context.JobSeekerProfiles.FindAsync(id);
            if (jobSeekerProfile == null)
            {
                return NotFound();
            }

            _context.JobSeekerProfiles.Remove(jobSeekerProfile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobSeekerProfileExists(int id)
        {
            return _context.JobSeekerProfiles.Any(e => e.JobSeekerProfileId == id);
        }
    }
}
