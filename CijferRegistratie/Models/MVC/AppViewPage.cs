using CijferRegistratie.Models.Auth;
using System;
using System.Security.Claims;
using System.Web.Mvc;

namespace CijferRegistratie.Models.MVC
{
    public class AppViewPage<TModel> : WebViewPage<TModel>
    {
        protected AppUser CurrentUser
        {
            get
            {
                return new AppUser(User as ClaimsPrincipal);
            }
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class AppViewPage : AppViewPage<dynamic>
    {
    }
}