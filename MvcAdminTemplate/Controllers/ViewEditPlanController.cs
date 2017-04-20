using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdminTemplate.Models;
using System.Dynamic;

namespace MvcAdminTemplate.Controllers
{
    [Authorize]
    public class ViewEditPlanController : Controller
    {
        //
        // GET: /ViewEditPlan/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoadPlans()
        {
            var Context = new DBModelEntities();
            IList<Plan> planList = Context.Plans.ToList();
            //IList<Models.Attribute> attribList = Context.Attributes.ToList();
            //var planNameList = planList.Select(x => x.PlanName).Distinct();
            //IList<Models.Process> procList = Context.Processes.ToList();
            //IList<Models.AttributeVariable> attribVarList = Context.AttributeVariables.ToList();
            //var selectedVar = planList.Select(x => x.Selected);
            //var attributeName = planList.Select(x => x.Process.Attribute.Name);
            ////metadictionary
            //Dictionary<int, Dictionary<string, string>> metaDict = new Dictionary<int, Dictionary<string, string>>();
            ////build object
            ////temp dictionary
            //Dictionary<string, string> dictionary = new Dictionary<string, string>();

            ////For distinct obj
            //for (int i = 0; i < planNameList.Count(); i++)
            //{
            //    string planName = planNameList.ElementAt(i);
            //    Plan plan = planList.Single(x => x.PlanName == planName);

            //    dictionary.Add("planName", planNameList.ElementAt(i).ToString());

            //    for (int j = 0; j < attributeName.Count(); j++)
            //    {
                    
            //        dictionary.Add(attributeName.ElementAt(j), selectedVar.ElementAt(j));
                    
            //    }

            //    //put it in a list or whatever
            //    metaDict.Add(i, dictionary);
            //}
            ////between here and datatables is magic I don't wanna touch
            return Json(new
            {
                aaData = planList.Select(x => new[] { x.PlanName, x.Selected })
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DefineHTMLTable()
        {
            var Context = new DBModelEntities();
            IList<Plan> planList = Context.Plans.ToList();

            var attributeNames = planList.Select(x => x.Process.Attribute.Name).Distinct();

            return Json(new { attributeNames = attributeNames }, JsonRequestBehavior.AllowGet);
        }


        //[HttpPost]
        //public ActionResult Update(string PlanID, string NewPlanID, string NewPlanName, string NewCompMan, string NewCompAdv, string NewPlanAdmin, string newPlanStatus)
        //{
        //    foreach (PlansViewModel i in PlansViewModel.PlansList)
        //    {
        //        if (i.PlanID == PlanID)
        //        {
        //            i.PlanID = NewPlanID;
        //            i.PlanName = NewPlanName;
        //            i.CompensationManager = NewCompMan;
        //            i.CompensationAdvisor = NewCompAdv;
        //            i.PlanAdmin = NewPlanAdmin;
        //            i.PlanStatus = newPlanStatus;

        //            return Json(new
        //            {
        //                aaData = PlansViewModel.PlansList.Select(x => new[] { x.PlanID, x.PlanName, x.CompensationManager, x.CompensationAdvisor, x.PlanAdmin, x.PlanStatus })
        //            }, JsonRequestBehavior.AllowGet);
        //        }
        //    }

        //    return Json(new
        //    {
        //        aaData = PlansViewModel.PlansList.Select(x => new[] { x.PlanID, x.PlanName, x.CompensationManager, x.CompensationAdvisor, x.PlanAdmin, x.PlanStatus })
        //    }, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public ActionResult View(string PlanID, string ViewPlanID, string ViewPlanName, string ViewCompMan, string ViewCompAdv, string ViewPlanAdmin, string ViewPlanStatus)
        //{
        //    foreach (PlansViewModel i in PlansViewModel.PlansList)
        //    {
        //        if (i.PlanID == PlanID)
        //        {
        //            i.PlanID = ViewPlanID;
        //            i.PlanName = ViewPlanName;
        //            i.CompensationManager = ViewCompMan;
        //            i.CompensationAdvisor = ViewCompAdv;
        //            i.PlanAdmin = ViewPlanAdmin;
        //            i.PlanStatus = ViewPlanStatus;

        //            return Json(new
        //            {
        //                aaData = PlansViewModel.PlansList.Select(x => new[] { x.PlanID, x.PlanName, x.CompensationManager, x.CompensationAdvisor, x.PlanAdmin, x.PlanStatus })
        //            }, JsonRequestBehavior.AllowGet);
        //        }
        //    }

        //    return Json(new
        //    {
        //        aaData = PlansViewModel.PlansList.Select(x => new[] { x.PlanID, x.PlanName, x.CompensationManager, x.CompensationAdvisor, x.PlanAdmin, x.PlanStatus })
        //    }, JsonRequestBehavior.AllowGet);
        //}


    }
}