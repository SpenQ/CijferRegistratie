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

            CreateStaffUsers(context);

            IEnumerable<AppUser> students = CreateStudents(context);

            CreateOthers(context, students);
        }

        private IEnumerable<AppUser> CreateStudents(AppDbContext context)
        {
            if (!context.Users.Any(u => !string.IsNullOrEmpty(u.StudentNumber)))
            {
                var store = new UserStore<AppUser>(context);
                var manager = new UserManager<AppUser>(store);

                var userList = new AppUser[]
                {
                    new AppUser
                    {
                        Name = "Stephanie",
                        StudentNumber = "002119031",
                        UserName = "stephanie@examcontrol.com"
                    },
                    new AppUser
                    {
                        Name = "Koen",
                        StudentNumber = "002119032",
                        UserName = "koen@examcontrol.com"
                    },
                    new AppUser
                    {
                        Name = "Freek",
                        StudentNumber = "002119033",
                        UserName = "freek@examcontrol.com"
                    },
                    new AppUser
                    {
                        Name = "Arie",
                        StudentNumber = "002119034",
                        UserName = "arie@examcontrol.com"
                    },
                    new AppUser
                    {
                        Name = "Frank",
                        StudentNumber = "002119035",
                        UserName = "frank@examcontrol.com"
                    }
                };

                foreach (var user in userList)
                {
                    manager.Create(user, "22INF2A");
                    manager.AddToRole(user.Id, "Student");
                }

                return userList;
            }

            return Enumerable.Empty<AppUser>();
        }

        /// <summary>
        /// The CreateUsers
        /// </summary>
        /// <param name="context">The <see cref="AppDbContext"/></param>
        private static void CreateStaffUsers(AppDbContext context)
        {
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
                var subjects = new Subject[]
                {
                    new Subject("Engels"),
                    new Subject("RUP"),
                    new Subject("C#")
                };

                var r = new Random();

                foreach (var sub in subjects)
                {
                    var classroom = new Classroom(16, true, "ABC");
                    ctx.Classrooms.Add(classroom);

                    ctx.Subjects.Add(sub);

                    var exams = new Exam[]
                    {
                        new Exam(DateTime.Now.AddDays(7), sub, 15, classroom, true, true, new TimeSpan(1, 30, 0)),
                        new Exam(DateTime.Now.AddDays(7).AddHours(6), sub, 15, classroom, true, true, new TimeSpan(1, 30, 0)),
                        new Exam(DateTime.Now.AddDays(7).AddHours(3), sub, 15, classroom, true, true, new TimeSpan(1, 30, 0)),
                    };

                    ctx.Exams.Add(exams.ElementAt(r.Next() % 3));

                    //foreach (var s in students)
                    //{
                    //    var reg = new ExamRegistration(ex, s.Id, DateTime.Now);

                    //    ctx.ExamRegistrations.Add(reg);
                    //}
                }
            }
        }
    }
}
