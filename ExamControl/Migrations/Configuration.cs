namespace ExamControl.Migrations
{
    using System;
    using System.Collections.Generic;
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

            var students = CreateUsers(context);

            CreateOthers(context, students);
        }

        /// <summary>
        /// The CreateUsers
        /// </summary>
        /// <param name="context">The <see cref="AppDbContext"/></param>
        private static IEnumerable<AppUser> CreateUsers(AppDbContext context)
        {
            var students = new List<AppUser>();

            var store = new UserStore<AppUser>(context);
            var manager = new UserManager<AppUser>(store);

            if (!context.Users.Any(u => u.UserName == "administratie@examcontrol.com"))
            {
                var user = new AppUser
                {
                    Name = "Administratie",
                    UserName = "administratie@examcontrol.com"
                };

                manager.Create(user, "22INF2A");
                manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "docent@examcontrol.com"))
            {
                var user = new AppUser
                {
                    Name = "Maurice van Haperen",
                    UserName = "docent@examcontrol.com"
                };

                manager.Create(user, "22INF2A");
                manager.AddToRole(user.Id, "Teacher");
            }

            if (!context.Users.Any(u => !string.IsNullOrEmpty(u.StudentNumber)))
            {
                var stephanie = new AppUser
                {
                    Name = "Stephanie",
                    StudentNumber = "002119031",
                    UserName = "stephanie@examcontrol.com"
                };

                manager.Create(stephanie, "22INF2A");
                manager.AddToRole(stephanie.Id, "Student");

                students.Add(stephanie);

                var koen = new AppUser
                {
                    Name = "Koen",
                    StudentNumber = "002119032",
                    UserName = "koen@examcontrol.com"
                };

                manager.Create(koen, "22INF2A");
                manager.AddToRole(koen.Id, "Student");

                students.Add(koen);

                var freek = new AppUser
                {
                    Name = "Freek",
                    StudentNumber = "002119033",
                    UserName = "freek@examcontrol.com"
                };

                manager.Create(freek, "22INF2A");
                manager.AddToRole(freek.Id, "Student");

                students.Add(freek);

                var arie = new AppUser
                {
                    Name = "Arie",
                    StudentNumber = "002119034",
                    UserName = "arie@examcontrol.com"
                };

                manager.Create(arie, "22INF2A");
                manager.AddToRole(arie.Id, "Student");

                students.Add(arie);

                var frank = new AppUser
                {
                    Name = "Frank",
                    StudentNumber = "002119035",
                    UserName = "frank@examcontrol.com"
                };

                manager.Create(frank, "22INF2A");
                manager.AddToRole(frank.Id, "Student");

                students.Add(frank);
            }

            return students;
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

        private static void CreateOthers(AppDbContext ctx, IEnumerable<AppUser> students)
        {
            // Subjects, exams and registrations
            if (!ctx.Subjects.Any() && !ctx.Exams.Any())
            {
                var subjectEnglish = new Subject("Engels");

                var classroom = new Classroom(16, true, "ABC");

                var examEnglish = new Exam(DateTime.Now.AddDays(-7), subjectEnglish, 15, classroom, true, true, new TimeSpan(1, 30, 0));
                var examEnglish2 = new Exam(DateTime.Now.AddDays(7).AddHours(3), subjectEnglish, 15, classroom, true, true, new TimeSpan(1, 30, 0));
                var examEnglish3 = new Exam(DateTime.Now.AddDays(7), subjectEnglish, 15, classroom, true, true, new TimeSpan(1, 30, 0));


                ctx.Classrooms.Add(classroom);

                ctx.Subjects.Add(subjectEnglish);

                ctx.Exams.Add(examEnglish);
                ctx.Exams.Add(examEnglish2);

                if (!ctx.ExamRegistrations.Any())
                {
                    foreach (var s in students)
                    {
                        var reg = new ExamRegistration(examEnglish, s.Id, DateTime.Now);

                        ctx.ExamRegistrations.Add(reg);
                    }
                }
            }
        }
    }
}
