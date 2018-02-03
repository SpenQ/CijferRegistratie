namespace CijferRegistratie.Models.MVC
{
    using System;
    using System.Security.Claims;
    using System.Web.Mvc;
    using CijferRegistratie.Models.Auth;

    /// <summary>
    /// Defines the <see cref="AppViewPage{TModel}" />
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class AppViewPage<TModel> : WebViewPage<TModel>
    {
        /// <summary>
        /// Gets the CurrentUser
        /// </summary>
        protected AppUserPrincipal CurrentUser
        {
            get
            {
                return new AppUserPrincipal(User as ClaimsPrincipal);
            }
        }

        /// <summary>
        /// The Execute
        /// </summary>
        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Defines the <see cref="AppViewPage" />
    /// </summary>
    public abstract class AppViewPage : AppViewPage<dynamic>
    {
    }
}
