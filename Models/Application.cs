namespace JobPortalBackend.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public int JobListingId { get; set; }
        public int JobSeekerProfileId { get; set; }
        public string Status { get; set; }
        public string CoverLetter { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.Now;
    }
}