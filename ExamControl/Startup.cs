﻿[assembly: Microsoft.Owin.OwinStartup(typeof(ExamControl.Startup))]
namespace ExamControl
{
    using System;
    using ExamControl.Models;
    using ExamControl.Models.Auth;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.Cookies;
    using Owin;

    /// <summary>
    /// Defines the <see cref="Startup" />
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Gets or sets the UserManagerFactory
        /// </summary>
        public static Func<UserManager<AppUser>> UserManagerFactory { get; private set; }

        /// <summary>
        /// The Configuration
        /// </summary>
        /// <param name="app">The <see cref="IAppBuilder"/></param>
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/auth/login")
            });

            // Configure the user manager
            UserManagerFactory = () =>
            {
                var usermanager = new UserManager<AppUser>(
                    new UserStore<AppUser>(new AppDbContext()));

                // Allow alphanumeric characters in username
                usermanager.UserValidator = new UserValidator<AppUser>(usermanager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };

                // use out custom claims provider
                usermanager.ClaimsIdentityFactory = new AppUserClaimsIdentityFactory();

                return usermanager;
            };
        }
    }
}
