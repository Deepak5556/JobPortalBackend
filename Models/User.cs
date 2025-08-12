namespace JobPortalBackend.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        public string Role { get; set; } // "JobSeeker", "Employer", "Admin"
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}