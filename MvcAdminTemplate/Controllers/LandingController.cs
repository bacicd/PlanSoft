using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAdminTemplate.Controllers
{
    public class LandingController : Controller
    {
        //
        // GET: /Landing/

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                //send them to the AuthenticatedIndex page instead of the index page
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}
