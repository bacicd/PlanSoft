using MvcAdminTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAdminTemplate.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult firstNameLastName(string fname, string lname)
        {
            var accountContext = new DBModelEntities();
            IList<Account> accountlist = accountContext.Accounts.ToList();

            var userNameList = accountlist.Select(x => x.Username);

            foreach (string userName in userNameList)
            {
                var fnameList = accountlist.Where(x => x.Username.Equals(userName)).Select(x => x.First);
                var lnameList = accountlist.Where(x => x.Username.Equals(userName)).Select(x => x.Last);
                foreach (string obj in fnameList)
                {
                    if (userName.Equals(User.Identity.Name))
                    {
                        fname = obj;
                    }
                }
                foreach (string obj in lnameList)
                {
                    if (userName.Equals(User.Identity.Name))
                    {
                        lname = obj;
                    }
                }
            }
            
            return Json(new
            {
                fname,lname
            }, JsonRequestBehavior.AllowGet);
        }
    }
}