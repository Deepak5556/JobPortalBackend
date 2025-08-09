using static System.Net.Mime.MediaTypeNames;

namespace JobPortalBackend.Models
{
    public class JobSeekerProfile
    {
        public int JobSeekerProfileId { get; set; }
        public int UserId { get; set; }
        public long Phone { get; set; }
        public string Location { get; set; }
        public int? ExperienceYears { get; set; }
        public string ResumeUrl { get; set; }
        public string Skills { get; set; }
        public ICollection<Application>? Applications { get; set; }
    }
}