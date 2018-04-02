namespace ExamControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ExamControl.Domain;
    using ExamControl.Models;
    using ExamControl.Models.Auth;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>
    /// Defines the <see cref="Configuration" />
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        /// <summary>
        /// The Seed
        /// </summary>
        /// <param name="context">The <see cref="AppDbContext"/></param>
        protected override void Seed(AppDbContext context)
        {
            CreateRoles(context);

            CreateUsers(context);

            CreateOthers(context);
        }

        /// <summary>
        /// The CreateUsers
        /// </summary>
        /// <param name="context">The <see cref="AppDbContext"/></param>
        private static void CreateUsers(AppDbContext context)
        {
            var store = new UserStore<AppUser>(context);
            var manager = new UserManager<AppUser>(store);

            if (!context.Users.Any(u => u.UserName == "administratie@examcontrol.com"))
            {
                var user = new AppUser
                {
                    UserName = "administratie@examcontrol.com",
                    Country = "The Netherlands"
                };

                manager.Create(user, "22INF2A");
                manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "docent@examcontrol.com"))
            {
                var user = new AppUser
                {
                    UserName = "docent@examcontrol.com",
                    Country = "The Netherlands"
                };

                manager.Create(user, "22INF2A");
                manager.AddToRole(user.Id, "Teacher");
            }

            if (!context.Users.Any(u => u.UserName == "student@examcontrol.com"))
            {
                var user = new AppUser
                {
                    UserName = "student@examcontrol.com",
                    Country = "The Netherlands"
                };

                manager.Create(user, "22INF2A");
                manager.AddToRole(user.Id, "Student");
            }
        }

        /// <summary>
        /// The CreateRoles
        /// </summary>
        /// <param name="context">The <see cref="AppDbContext"/></param>
        private static void CreateRoles(AppDbContext context)
        {
            // Users
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                manager.Create(
                    new IdentityRole
                    {
                        Name = "Admin"
                    });
            }

            if (!context.Roles.Any(r => r.Name == "Teacher"))
            {
                manager.Create(
                    new IdentityRole
                    {
                        Name = "Teacher"
                    });
            }

            if (!context.Roles.Any(r => r.Name == "Student"))
            {
                manager.Create(
                    new IdentityRole
                    {
                        Name = "Student"
                    });
            }
        }

        private static void CreateOthers(AppDbContext context)
        {
            // Subjects, exams and registrations
            if (!context.Subjects.Any() && !context.Exams.Any())
            {
                var subjectEnglish = new Subject("Engels");

                var classroom = new Classroom(16, true, "ABC");

                var examEnglish = new Exam(DateTime.Now.AddDays(7), subjectEnglish, 15, classroom, true, true, new TimeSpan(1, 30, 0));
                var examEnglish2 = new Exam(DateTime.Now.AddDays(7).AddHours(3), subjectEnglish, 15, classroom, true, true, new TimeSpan(1, 30, 0));

                context.Classrooms.Add(classroom);

                context.Subjects.Add(subjectEnglish);

                context.Exams.Add(examEnglish);
                context.Exams.Add(examEnglish2);
            }
        }
    }
}
