using JobPortalBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortalBackend.Data
{
    public class JobPortalContext : DbContext
    {
        public JobPortalContext(DbContextOptions<JobPortalContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<EmployerProfile> EmployerProfiles { get; set; }
        public DbSet<JobSeekerProfile> JobSeekerProfiles { get; set; }
        public DbSet<JobListing> JobListings { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User and EmployerProfile: One-to-One
            modelBuilder.Entity<User>()
                .HasOne<EmployerProfile>()
                .WithOne()
                .HasForeignKey<EmployerProfile>(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // User and JobSeekerProfile: One-to-One
            modelBuilder.Entity<User>()
                .HasOne<JobSeekerProfile>()
                .WithOne()
                .HasForeignKey<JobSeekerProfile>(j => j.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // EmployerProfile and JobListings: One-to-Many
            modelBuilder.Entity<EmployerProfile>()
                .HasMany(e => e.JobListings)
                .WithOne()
                .HasForeignKey(j => j.EmployerProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            // JobSeekerProfile and Applications: One-to-Many
            modelBuilder.Entity<JobSeekerProfile>()
                .HasMany(js => js.Applications)
                .WithOne()
                .HasForeignKey(a => a.JobSeekerProfileId) // nullable foreign key
                .IsRequired(false) // make it optional
                .OnDelete(DeleteBehavior.SetNull); // instead of cascade delete


            // JobListing and Applications: One-to-Many (optional navigation)
            modelBuilder.Entity<JobListing>()
                .HasMany(j => j.Applications)
                .WithOne()
                .HasForeignKey(a => a.JobListingId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}