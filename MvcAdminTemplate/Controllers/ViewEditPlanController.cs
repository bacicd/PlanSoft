using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdminTemplate.Models;

namespace MvcAdminTemplate.Controllers
{
    public class ViewEditPlanController : Controller
    {
        //
        // GET: /ViewEditPlan/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadPlans()
        {
            return Json(new
            {
                aaData = PlansViewModel.PlansList.Select(x => new[] { x.PlanID, x.PlanName, x.CompensationManager, x.CompensationAdvisor, x.PlanAdmin, x.PlanStatus
    })
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Update(string PlanID, string NewPlanID, string NewPlanName, string NewCompMan, string NewCompAdv, string NewPlanAdmin, string newPlanStatus)
        {
            foreach (PlansViewModel i in PlansViewModel.PlansList)
            {
                if (i.PlanID == PlanID)
                {
                    i.PlanID = NewPlanID;
                    i.PlanName = NewPlanName;
                    i.CompensationManager = NewCompMan;
                    i.CompensationAdvisor = NewCompAdv;
                    i.PlanAdmin = NewPlanAdmin;
                    i.PlanStatus = newPlanStatus;

                    return Json(new
                    {
                        aaData = PlansViewModel.PlansList.Select(x => new[] { x.PlanID, x.PlanName, x.CompensationManager, x.CompensationAdvisor, x.PlanAdmin, x.PlanStatus })
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new
            {
                aaData = PlansViewModel.PlansList.Select(x => new[] { x.PlanID, x.PlanName, x.CompensationManager, x.CompensationAdvisor, x.PlanAdmin, x.PlanStatus })
            }, JsonRequestBehavior.AllowGet);
        }
    }
}