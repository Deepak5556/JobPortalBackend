namespace JobPortalBackend.Models
{
    public class JobSeekerProfile
    {
        public int JobSeekerProfileId { get; set; }
        public int UserId { get; set; }

        public string? ProfileURL { get; set; }
        public string? Location { get; set; }
        public int ExperienceYears { get; set; }
        public string? ResumeUrl { get; set; }
        public string? Skills { get; set; }
        public string? Phone { get; set; }
        // Applications made by the seeker
        public ICollection<Application>? Applications { get; set; }

        // TEMP: store as JSON/text until you make a proper join table
        public string? SavedJobIds { get; set; }
    }
}
