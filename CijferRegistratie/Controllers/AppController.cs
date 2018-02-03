using CijferRegistratie.Models.Auth;
using System.Web.Mvc;

namespace CijferRegistratie.Controllers
{
    public class AppController : Controller
    {
        public AppUser CurrentUser
        {
            get
            {
                return new AppUser();
            }
        }
    }
}