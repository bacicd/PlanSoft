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
        private DBModelEntities db = new DBModelEntities();
        //
        // GET: /ElementsVariables/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadElements()
        {
            ElementVariable.ElementsVarList = db.ElementVariables.ToList();
            return Json(new
            {
                aaData = ElementVariable.ElementsVarList.Select(x => new[] { x.ECode.ToString(), x.Element.Name, x.Code.ToString(), x.Name, x.CID.ToString(), x.CreatedOn.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(string EleCode)
        {
            foreach (ElementsVariablesViewModel i in ElementsVariablesViewModel.ElementsVariablesList)
            {
                if (i.ElementCode == EleCode)
                {
                    ElementsVariablesViewModel.ElementsVariablesList.Remove(i);
                    return Json(new
                    {
                        aaData = ElementsVariablesViewModel.ElementsVariablesList.Select(x => new[] { x.ElementCode, x.ElementName, x.VariableCode, x.VariableName, x.VariableCID, x.DateSet.ToString(), x.CreatedBy })
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new
            {
                aaData = ElementsVariablesViewModel.ElementsVariablesList.Select(x => new[] { x.ElementCode, x.ElementName, x.VariableCode, x.VariableName, x.VariableCID, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(string varCode, string newEleCode, string newEleName, string newVarCID, string newVarName, string newVarCode)
        {
            foreach (ElementsVariablesViewModel i in ElementsVariablesViewModel.ElementsVariablesList)
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
                        aaData = ElementsVariablesViewModel.ElementsVariablesList.Select(x => new[] { x.ElementCode, x.ElementName, x.VariableCode, x.VariableName, x.VariableCID, x.DateSet.ToString(), x.CreatedBy })
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new
            {
                aaData = ElementsVariablesViewModel.ElementsVariablesList.Select(x => new[] { x.ElementCode, x.ElementName, x.VariableCode, x.VariableName, x.VariableCID, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(string EleCode, string EleName, string varCode, string varName, string varCID, string Creator)
        {
            //ElementsVariablesViewModel.ElementsVariablesList.Add(new ElementsVariablesViewModel { ElementCode = EleCode, ElementName = EleName, VariableCID = varCID, VariableCode = varCode, VariableName = varName, DateSet = DateTime.Today, CreatedBy = Creator });
            ElementVariable.ElementsVarList.Add(new ElementVariable { ECode = Convert.ToInt32(EleCode), CID = Convert.ToDecimal(varCID), Name = varName, CreatedOn = DateTime.Today, CreatedBy = Creator });

            ElementVariable addElementVar = new ElementVariable();
            addElementVar.ECode = Convert.ToInt32(EleCode);
            addElementVar.CID = Convert.ToDecimal(varCID);
            addElementVar.Name = varName;
            addElementVar.CreatedOn = DateTime.Today;
            addElementVar.CreatedBy = Creator;
            db.ElementVariables.Add(addElementVar);
            db.SaveChanges();

            return Json(new
            {
                aaData = ElementVariable.ElementsVarList.Select(x => new[] { x.Code.ToString(), EleName, x.Name, x.CID.ToString(), x.CreatedOn.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DropDownElementCodes(string code)
        {
            return Json(new
            {
                code = Element.ElementsList.Select(x => new[] { x.Code.ToString() })
            }, JsonRequestBehavior.AllowGet);
            //return Json(new
            //{
            //    attribute = AttributesViewModel.AttributesList.Select(x => new[] { x.AttributeName })
            //}, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DropDownElementNames(string name)
        {
            return Json(new
            {
                name = Element.ElementsList.Select(x => new[] { x.Name })
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
