using MvcAdminTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAdminTemplate.Controllers
{
    public class ProcessesController : Controller
    {
        //
        // GET: /Processes/

        public ActionResult Index()
        {
            return View();
        }


        public JsonResult DropDownAttributes(string attribute)
        {
            return Json(new
            {
                attribute = AttributesViewModel.AttributesList.Select(x => new[] { x.AttributeName })
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
