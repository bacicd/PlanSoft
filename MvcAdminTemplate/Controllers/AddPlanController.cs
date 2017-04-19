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
        private DBModelEntities db = new DBModelEntities();

        //
        // GET: /AddPlan/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult DropDownAttributeVars(string attribute)
        {
            var attributeContext = new DBModelEntities();
            IList<Models.Attribute> attribList = attributeContext.Attributes.ToList();

            IList<Models.AttributeVariable> attribVarList = attributeContext.AttributeVariables.ToList();
            return Json(new
            {
                attribute = attribList.Select(x => new { x.Name, x.Code, x.Input }),
                attributeVar = attribVarList.Select(x => new { x.Name, x.ACode })
                
            }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult saveToDB(string data)
        {
            var db = new DBModelEntities();
            IList<Models.Process> procList = db.Processes.ToList();
            IList<Models.Attribute> attribList = db.Attributes.ToList();
            IList<Models.AttributeVariable> attribVarList = db.AttributeVariables.ToList();



            string herp = data;
            string[] arr = herp.Split('|');

            for(int i = 1; i < arr.Length; i++)
            {
                Plan plan = new Plan();

                //If free text variable
                if(arr[i].Contains(":"))
                {
                    string model = arr[i].Substring(0, arr[i].IndexOf(":"));
                    Models.Attribute textAttrib = attribList.Single(x => x.Name == model);
                    Models.Process textProc = procList.Single(x => x.ACode == textAttrib.Code);

                    plan.ProcessID = textProc.ID;
                    plan.PlanName = "TestPlan";
                    plan.Selected = arr[i];

                    db.Plans.Add(plan);
                    db.SaveChanges();
                }
                else
                {
                    //Find attribVar where name == data[i]
                    //AttributeVariable attribVar = attribVarList.Single(x => x.Name == "FreeText");
                    //try { 
                    AttributeVariable attribVar = attribVarList.Single(x => x.Name == arr[i]);
                    //}
                    //catch
                    //{
                    
                    //}
                    //Find attrib containing attribVar
                    Models.Attribute attrib = attribList.Single(x => x.AttributeVariables.Contains(attribVar));

                    //Find process with where acode == attrib.acode
                    Models.Process proc = procList.Single(x => x.ACode == attrib.Code);


                    plan.ProcessID = proc.ID;
                    plan.PlanName = "TestPlan";
                    plan.Selected = arr[i];

                    db.Plans.Add(plan);
                    db.SaveChanges();
                }
            }




            return Json(true);
        }

        public JsonResult getLayoutStr()
        {
            string str = "  TASK: TASK1\n SUBTASK: SUBTASK1\n ATTRIBUTE: Payment Occurrence\n ATTRIBUTE: Payment Amount\n SUBTASK: SUBTASK2\n ATTRIBUTE: Bonus Amount\n ATTRIBUTE: Bonus Metric\n ATTRIBUTE: Bonuses\n TASK: TASK2\n SUBTASK: SUBATSK3\n ATTRIBUTE: Compensation Benefits\n ATTRIBUTE: Commercial\n TASK: TASK3\n SUBTASK: SUBATSK4\n ATTRIBUTE: ATTRIBNAME\n ATTRIBUTE: ALSO AN ATTRIB NAME\n ";

            var procContext = new DBModelEntities();
            IList<Models.Process> procList = procContext.Processes.ToList();
            //IList<Attribute> attribute = procContext.Attributes.ToList();


            string[,] arr = new string[procList.Count, 3];

            for (int i = 0; i < procList.Count; i++)
            {
                int aCode = procList[i].ACode;
                string tabName = procList[i].TabName;
                string subName = procList[i].SubName;

                Models.Attribute attrib = db.Attributes.Find(aCode);

                string attribName = attrib.Name;



                arr[i, 2] = attribName;
                arr[i, 1] = subName;
                arr[i, 0] = tabName;




            }

            string str2 = "";

            //For each attrib
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                //Edge case handling (default processes)
                if (arr.Length == 3)
                {
                    str2 += "  TASK: " + arr[i, 0] + " \n SUBTASK: " + arr[i, 1] + "\n ATTRIBUTE: " + arr[i, 2];
                    break;
                }
                //If string empty, need task, subtask, attrib
                if (str2 == "")
                {
                    str2 += "  TASK: " + arr[i, 0] + " \n SUBTASK: " + arr[i, 1] + "\n ATTRIBUTE: " + arr[i, 2];
                    continue;
                }
                //if tab and subtab same, only add attribute
                else if (arr[i - 1, 0] == arr[i, 0] && arr[i - 1, 1] == arr[i, 1])
                {
                    str2 += "\n ATTRIBUTE: " + arr[i, 2];
                }
                //If just tab matching, add subtab and attrib
                else if (arr[i - 1, 0] == arr[i, 0])
                {
                    str2 += " \n SUBTASK: " + arr[i, 1] + "\n ATTRIBUTE: " + arr[i, 2];
                }
                //otherwise add all to string
                else
                {
                    str2 += "  TASK: " + arr[i, 0] + " \n SUBTASK: " + arr[i, 1] + "\n ATTRIBUTE: " + arr[i, 2];
                }

            }
            str2 += "\n";





            //var attributeContext = new DBModelEntities();
            //IList<Models.Attribute> attributelist = attributeContext.Attributes.ToList();
            return Json(new
            {
                layoutStr = str2
                //attribute = attributelist.Select(x => new[] { x.Name })
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
