namespace JobPortalBackend.Models
{
    public class EmployerProfile
    {
        public int EmployerProfileId { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public string Industry { get; set; }
        public string? CompanyWebsite { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Location { get; set; }

        public ICollection<JobListing>? JobListings { get; set; }
    }
}