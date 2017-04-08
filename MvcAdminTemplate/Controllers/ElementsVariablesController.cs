using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdminTemplate.Models;

namespace MvcAdminTemplate.Controllers
{
    [Authorize]
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
            var elementvarContext = new DBModelEntities();
            IList<ElementVariable> elementvars = elementvarContext.ElementVariables.ToList();
            return Json(new
            {
                aaData = elementvars.Select(x => new[] { x.ECode.ToString(), x.Element.Name, x.Code.ToString(), x.Name, x.CID.ToString(), x.CreatedOn.ToString().Substring(0, 9), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(string EleCode)
        {
            var elementvarContext = new DBModelEntities();
            IList<ElementVariable> elementvars = elementvarContext.ElementVariables.ToList();
            ElementVariable element = db.ElementVariables.Find(Convert.ToInt32(EleCode));

            db.ElementVariables.Remove(element);
            db.SaveChanges();
            //foreach (ElementsVariablesViewModel i in ElementsVariablesViewModel.ElementsVariablesList)
            //{
            //    if (i.ElementCode == EleCode)
            //    {
            //        ElementsVariablesViewModel.ElementsVariablesList.Remove(i);
            //        return Json(new
            //        {
            //            aaData = ElementsVariablesViewModel.ElementsVariablesList.Select(x => new[] { x.ElementCode, x.ElementName, x.VariableCode, x.VariableName, x.VariableCID, x.DateSet.ToString(), x.CreatedBy })
            //        }, JsonRequestBehavior.AllowGet);
            //    }
            //}

            return Json(new
            {
                aaData = elementvars.Select(x => new[] { x.Code.ToString(), x.Name, x.CID.ToString(), x.ECode.ToString(), x.CreatedOn.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(string varCode, string newVarName, string newVarCID)
        {
            var elementvarContext = new DBModelEntities();
            IList<ElementVariable> elementvars = elementvarContext.ElementVariables.ToList();
            ElementVariable elementVar = db.ElementVariables.Find(Convert.ToInt32(varCode));

            //2. change element name in disconnected mode (out of ctx scope)
            elementVar.CID = Convert.ToInt32(newVarCID);
            elementVar.Name = newVarName;

            db.SaveChanges();
            //foreach (ElementsVariablesViewModel i in ElementsVariablesViewModel.ElementsVariablesList)
            //{
            //    if (i.ElementCode == varCode)
            //    {
            //        i.ElementCode = newEleCode;
            //        i.ElementName = newEleName;
            //        i.VariableCID = newVarCID;
            //        i.VariableCode = newVarCode;
            //        i.VariableName = newVarName;
            //        i.DateSet = DateTime.Today;

            //        return Json(new
            //        {
            //            aaData = ElementsVariablesViewModel.ElementsVariablesList.Select(x => new[] { x.ElementCode, x.ElementName, x.VariableCode, x.VariableName, x.VariableCID, x.DateSet.ToString(), x.CreatedBy })
            //        }, JsonRequestBehavior.AllowGet);
            //    }
            //}

            return Json(new
            {
                aaData = elementvars.Select(x => new[] { x.Code.ToString(), x.Name, x.CID.ToString() })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(string EleCode, string EleName, string varCode, string varName, string varCID, string Creator)
        {
            var elementvarContext = new DBModelEntities();
            IList<ElementVariable> elementvars = elementvarContext.ElementVariables.ToList();
            //ElementsVariablesViewModel.ElementsVariablesList.Add(new ElementsVariablesViewModel { ElementCode = EleCode, ElementName = EleName, VariableCID = varCID, VariableCode = varCode, VariableName = varName, DateSet = DateTime.Today, CreatedBy = Creator });
            elementvars.Add(new ElementVariable { ECode = Convert.ToInt32(EleCode), CID = Convert.ToDecimal(varCID), Name = varName, CreatedOn = DateTime.Today, CreatedBy = Creator });

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
                aaData = elementvars.Select(x => new[] { x.Code.ToString(), EleName, x.Name, x.CID.ToString(), x.CreatedOn.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DropDownElementCodes(string code)
        {
            var elementContext = new DBModelEntities();
            IList<Element> elements = elementContext.Elements.ToList();
            return Json(new
            {
                code = elements.Select(x => new[] { x.Code.ToString() })
            }, JsonRequestBehavior.AllowGet);
            //return Json(new
            //{
            //    attribute = AttributesViewModel.AttributesList.Select(x => new[] { x.AttributeName })
            //}, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DropDownElementNames(string name)
        {
            var elementContext = new DBModelEntities();
            IList<Element> elements = elementContext.Elements.ToList();

            return Json(new
            {
                name = elements.Select(x => new[] { x.Name })
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
