using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAdminTemplate.Controllers
{
    [Authorize]
    public class StatisticsController : Controller
    {
        //
        // GET: /Statistics/
        public ActionResult Index()
        {
            return View();
        }
	}
}