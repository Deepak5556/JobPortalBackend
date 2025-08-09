using static System.Net.Mime.MediaTypeNames;

namespace JobPortalBackend.Models
{
    public class JobListing
    {
        public int JobListingId { get; set; }
        public int EmployerProfileId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string Location { get; set; }
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }
        public string EmploymentType { get; set; }
        public string Industry { get; set; }
        public string Status { get; set; } // "Open", "Closed"
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Application> Applications { get; set; }
    }
}