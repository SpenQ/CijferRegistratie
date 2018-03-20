namespace ExamControl.Models
{
    using System.Data.Entity;
    using ExamControl.Domain;
    using ExamControl.Models.Auth;
    using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>
    /// Defines the <see cref="AppDbContext" />
    /// </summary>
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        public AppDbContext()
            : base("ExamControl.Properties.Settings.ConnectionString")
        {
        }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<ExamRegistration> ExamRegistrations { get; set; }
    }
}
