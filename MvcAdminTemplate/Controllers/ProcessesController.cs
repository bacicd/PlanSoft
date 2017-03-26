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

        public JsonResult getData(string data)
        {
            string processesData = data;
            return Json(true);
        }

        public JsonResult DropDownAttributes(string attribute)
        {
            var attributeContext = new DBModelEntities();
            IList<ElementVariable> attributelist = attributeContext.ElementVariables.ToList();
            return Json(new
            {
                attribute = attributelist.Select(x => new[] { x.Name })
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
