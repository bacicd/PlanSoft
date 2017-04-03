using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdminTemplate.Models;

namespace MvcAdminTemplate.Controllers
{
    [Authorize]
    public class AddPlanController : Controller
    {
        //
        // GET: /AddPlan/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getLayoutStr()
        {
            string str = "  TASK: TASK1\n SUBTASK: SUBTASK1\n ATTRIBUTE: Payment Occurrence\n ATTRIBUTE: Payment Amount\n SUBTASK: SUBTASK2\n ATTRIBUTE: Bonus Amount\n ATTRIBUTE: Bonus Metric\n ATTRIBUTE: Bonuses\n TASK: TASK2\n SUBTASK: SUBATSK3\n ATTRIBUTE: Compensation Benefits\n ATTRIBUTE: Commercial\n TASK: TASK3\n SUBTASK: SUBATSK4\n ATTRIBUTE: ATTRIBNAME\n ATTRIBUTE: ALSO AN ATTRIB NAME\n ";

            //var attributeContext = new DBModelEntities();
            //IList<Models.Attribute> attributelist = attributeContext.Attributes.ToList();
            return Json(new
            {
                layoutStr = str
                //attribute = attributelist.Select(x => new[] { x.Name })
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
