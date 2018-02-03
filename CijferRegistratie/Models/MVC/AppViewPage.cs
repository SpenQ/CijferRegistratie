using CijferRegistratie.Models.Auth;
using System;
using System.Security.Claims;
using System.Web.Mvc;

namespace CijferRegistratie.Models.MVC
{
    public class AppViewPage<TModel> : WebViewPage<TModel>
    {
        protected AppUserPrincipal CurrentUser
        {
            get
            {
                return new AppUserPrincipal(User as ClaimsPrincipal);
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