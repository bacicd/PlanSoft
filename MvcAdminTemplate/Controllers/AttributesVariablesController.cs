using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdminTemplate.Models;


namespace MvcAdminTemplate.Controllers
{
    public class AttributesVariablesController : Controller
    {
        private DBModelEntities db = new DBModelEntities();
        //
        // GET: /AttributesVariables/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoadAttributes()
        {
            AttributeVariable.AttributesVariablesList = db.AttributesVariables.ToList();
            return Json(new
            {
               // aaData = AttributesVariablesViewModel.AttributesVariablesList.Select(x => new[] { x.AttributeCode, x.AttributeName, x.VariableCode, x.VariableName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(string AttribCode)
        {
            AttributeVariable.AttributesVariablesList = db.AttributesVariables.ToList();
            AttributeVariable attribute = db.AttributesVariables.Find(Convert.ToInt32(AttribCode));

            db.AttributesVariables.Remove(attribute);
            db.SaveChanges();

            /*   foreach (AttributesVariablesViewModel i in AttributesVariablesViewModel.AttributesVariablesList)
               {
                   if (i.AttributeCode == AttribCode)
                   {
                       AttributesVariablesViewModel.AttributesVariablesList.Remove(i);
                       return Json(new
                       {
                           aaData = AttributesVariablesViewModel.AttributesVariablesList.Select(x => new[] { x.AttributeCode, x.AttributeName, x.VariableCode, x.VariableName, x.DateSet.ToString(), x.CreatedBy })
                       }, JsonRequestBehavior.AllowGet);
                   }
               }
            */

            return Json(new
            {
                // aaData = AttributesVariablesViewModel.AttributesVariablesList.Select(x => new[] { x.AttributeCode, x.AttributeName, x.VariableCode, x.VariableName, x.DateSet.ToString(), x.CreatedBy })
                aaData = AttributeVariable.AttributesVariablesList.Select(x => new[] { x.AttributeCode, x.AttributeName, x.VariableCode, x.VariableName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(string varCode, string NewAttribCode, string NewAttribName, string NewVarName, string NewVarCode)
        {
            AttributeVariable.AttributesVariablesList = db.AttributesVariables.ToList();
            AttributeVariable attribVar = db.AttributesVariables.Find(Convert.ToInt32(varCode));

            //2. change element name in disconnected mode (out of ctx scope)
            attribVar.Code = Convert.ToInt32(NewVarCode);
            attribVar.Name = NewVarName;

            db.SaveChanges();

            /*   foreach (AttributesVariablesViewModel i in AttributesVariablesViewModel.AttributesVariablesList)
              {
                  if (i.AttributeCode == varCode)
                  {
                      i.AttributeCode = NewAttribCode;
                      i.AttributeName = NewAttribName;
                      i.VariableCode = NewVarCode;
                      i.VariableName = NewVarName;
                      i.DateSet = DateTime.Today;

                      return Json(new
                      {
                          aaData = AttributesVariablesViewModel.AttributesVariablesList.Select(x => new[] { x.AttributeCode, x.AttributeName, x.VariableCode, x.VariableName, x.DateSet.ToString(), x.CreatedBy })
                      }, JsonRequestBehavior.AllowGet);
                  }
              }
           */
            return Json(new
            {
                //aaData = AttributesVariablesViewModel.AttributesVariablesList.Select(x => new[] { x.AttributeCode, x.AttributeName, x.VariableCode, x.VariableName, x.DateSet.ToString(), x.CreatedBy })
                aaData = AttributeVariable.AttributesVariablesList.Select(x => new[] { x.AttributeCode, x.AttributeName, x.VariableCode, x.VariableName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(string AttribCode, string AttribName, string varCode, string varName, string Creator)
        {
            //AttributesVariablesViewModel.AttributesVariablesList.Add(new AttributesVariablesViewModel { AttributeCode = AttribCode, AttributeName = AttribName, VariableCode = varCode, VariableName = varName, DateSet = DateTime.Today, CreatedBy = Creator });
            AttributeVariable.AttributeVariablesList.Add(new AttributeVariable { ACode = Convert.ToInt32(AttribCode), Name = varName, CreatedOn = DateTime.Today, CreatedBy = Creator });

            AttributeVariable addAttributeVar = new AttributeVariable();
            addAttributeVar.ACode = Convert.ToInt32(AttribCode);
            addAttributeVar.Name = varName;
            addAttributeVar.CreatedOn = DateTime.Today;
            addAttributeVar.CreatedBy = Creator;
            db.AttributeVariables.Add(addAttributeVar);
            db.SaveChanges();

            return Json(new
            {
                //aaData = AttributesVariablesViewModel.AttributesVariablesList.Select(x => new[] { x.AttributeCode, x.AttributeName, x.VariableCode, x.VariableName, x.DateSet.ToString(), x.CreatedBy })
                aaData = AttributeVariable.AttributesVariablesList.Select(x => new[] { x.AttributeCode, x.AttributeName, x.VariableCode, x.VariableName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DropDownAttributeCodes(string code)
        {
            Attribute.AttributesList = db.Attributes.ToList();
            return Json(new
            {
                code = Attribute.AttributesList.Select(x => new[] { x.Code.ToString() })
            }, JsonRequestBehavior.AllowGet);
            //return Json(new
            //{
            //    attribute = AttributesViewModel.AttributesList.Select(x => new[] { x.AttributeName })
            //}, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DropDownAttributeNames(string name)
        {
            Attribute.AttributesList = db.Attributes.ToList();
            return Json(new
            {
                name = Attribute.AttributesList.Select(x => new[] { x.Name })
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
