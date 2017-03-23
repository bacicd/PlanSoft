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
            AttributeVariable.AttributesVariablesList = db.AttributeVariables.ToList();
            return Json(new
            {
               aaData = AttributeVariable.AttributesVariablesList.Select(x => new[] { x.Attribute.Code.ToString(), x.Attribute.Name, x.Name, x.Code.ToString(), x.CreatedOn.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(string AttribCode)
        {
            //AttributeVariable.AttributesVariablesList = db.AttributeVariables.ToList();
            AttributeVariable attribute = db.AttributeVariables.Find(Convert.ToInt32(AttribCode));

            db.AttributeVariables.Remove(attribute);
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
                aaData = AttributeVariable.AttributesVariablesList.Select(x => new[] { x.Attribute.Code.ToString(), x.Attribute.Name, x.Code.ToString(), x.Name, x.CreatedOn.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(string varCode, string NewAttribCode, string NewAttribName, string NewVarName, string NewVarCode)
        {
            AttributeVariable.AttributesVariablesList = db.AttributeVariables.ToList();
            AttributeVariable attribVar = db.AttributeVariables.Find(Convert.ToInt32(varCode));

            //2. change element name in disconnected mode (out of ctx scope)
            //attribVar.Code = Convert.ToInt32(NewVarCode);
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
                aaData = AttributeVariable.AttributesVariablesList.Select(x => new[] { x.Attribute.Code.ToString(), x.Attribute.Name, x.Code.ToString(), x.Name, x.CreatedOn.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(string AttribCode, string AttribName, string varCode, string varName, string Creator)
        {
            //AttributesVariablesViewModel.AttributesVariablesList.Add(new AttributesVariablesViewModel { AttributeCode = AttribCode, AttributeName = AttribName, VariableCode = varCode, VariableName = varName, DateSet = DateTime.Today, CreatedBy = Creator });
            //AttributeVariable.AttributesVariablesList.Add(new AttributeVariable { ACode = Convert.ToInt32(AttribCode), Name = varName, CreatedOn = DateTime.Today, CreatedBy = Creator });

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
                aaData = AttributeVariable.AttributesVariablesList.Select(x => new[] { x.Attribute.Code.ToString(), x.Attribute.Name, x.Code.ToString(), x.Name, x.CreatedOn.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DropDownAttributeCodes(string code)
        {
            Models.Attribute.AttributesList = db.Attributes.ToList();
            return Json(new
            {
                code = Models.Attribute.AttributesList.Select(x => new[] { x.Code.ToString() })
            }, JsonRequestBehavior.AllowGet);
            //return Json(new
            //{
            //    attribute = AttributesViewModel.AttributesList.Select(x => new[] { x.AttributeName })
            //}, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DropDownAttributeNames(string name)
        {
            Models.Attribute.AttributesList = db.Attributes.ToList();
            return Json(new
            {
                name = Models.Attribute.AttributesList.Select(x => new[] { x.Name })
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
