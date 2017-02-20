using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdminTemplate.Models;

namespace MvcAdminTemplate.Controllers
{
    public class ElementsVariablesController : Controller
    {
        //
        // GET: /ElementsVariables/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadElements()
        {
            return Json(new
            {
                aaData = ElementsVariables.ElementsVariablesList.Select(x => new[] { x.ElementCode, x.ElementName, x.VariableCode, x.VariableName, x.VariableCID, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(string EleCode)
        {
            foreach (ElementsVariables i in ElementsVariables.ElementsVariablesList)
            {
                if (i.ElementCode == EleCode)
                {
                    ElementsVariables.ElementsVariablesList.Remove(i);
                    return Json(new
                    {
                        aaData = ElementsVariables.ElementsVariablesList.Select(x => new[] { x.ElementCode, x.ElementName, x.VariableCode, x.VariableName, x.VariableCID, x.DateSet.ToString(), x.CreatedBy })
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new
            {
                aaData = ElementsVariables.ElementsVariablesList.Select(x => new[] { x.ElementCode, x.ElementName, x.VariableCode, x.VariableName, x.VariableCID, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(string varCode, string newEleCode, string newEleName, string newVarCID, string newVarName, string newVarCode)
        {
            foreach (ElementsVariables i in ElementsVariables.ElementsVariablesList)
            {
                if (i.ElementCode == varCode)
                {
                    i.ElementCode = newEleCode;
                    i.ElementName = newEleName;
                    i.VariableCID = newVarCID;
                    i.VariableCode = newVarCode;
                    i.VariableName = newVarName;
                    i.DateSet = DateTime.Today;

                    return Json(new
                    {
                        aaData = ElementsVariables.ElementsVariablesList.Select(x => new[] { x.ElementCode, x.ElementName, x.VariableCode, x.VariableName, x.VariableCID, x.DateSet.ToString(), x.CreatedBy })
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new
            {
                aaData = ElementsVariables.ElementsVariablesList.Select(x => new[] { x.ElementCode, x.ElementName, x.VariableCode, x.VariableName, x.VariableCID, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(string EleCode, string EleName, string varCode, string varName, string varCID, string Creator)
        {
            ElementsVariables.ElementsVariablesList.Add(new ElementsVariables { ElementCode = EleCode, ElementName = EleName, VariableCID = varCID, VariableCode = varCode, VariableName = varName, DateSet = DateTime.Today, CreatedBy = Creator });

            return Json(new
            {
                aaData = ElementsVariables.ElementsVariablesList.Select(x => new[] { x.ElementCode, x.ElementName, x.VariableCode, x.VariableName, x.VariableCID, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
