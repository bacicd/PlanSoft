﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdminTemplate.Models;


namespace MvcAdminTemplate.Controllers
{
    public class AttributesVariablesController : Controller
    {
        //
        // GET: /AttributesVariables/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoadAttributes()
        {
            return Json(new
            {
                aaData = AttributesVariables.AttributesVariablesList.Select(x => new[] { x.AttributeCode, x.AttributeName, x.VariableCode, x.VariableName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(string AttribCode)
        {
            foreach (AttributesVariables i in AttributesVariables.AttributesVariablesList)
            {
                if (i.AttributeCode == AttribCode)
                {
                    AttributesVariables.AttributesVariablesList.Remove(i);
                    return Json(new
                    {
                        aaData = AttributesVariables.AttributesVariablesList.Select(x => new[] { x.AttributeCode, x.AttributeName, x.VariableCode, x.VariableName, x.DateSet.ToString(), x.CreatedBy })
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new
            {
                aaData = AttributesVariables.AttributesVariablesList.Select(x => new[] { x.AttributeCode, x.AttributeName, x.VariableCode, x.VariableName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(string varCode, string NewAttribCode, string NewAttribName, string NewVarName, string NewVarCode)
        {
            foreach (AttributesVariables i in AttributesVariables.AttributesVariablesList)
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
                        aaData = AttributesVariables.AttributesVariablesList.Select(x => new[] { x.AttributeCode, x.AttributeName, x.VariableCode, x.VariableName, x.DateSet.ToString(), x.CreatedBy })
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new
            {
                aaData = AttributesVariables.AttributesVariablesList.Select(x => new[] { x.AttributeCode, x.AttributeName, x.VariableCode, x.VariableName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(string AttribCode, string AttribName, string varCode, string varName, string Creator)
        {
            AttributesVariables.AttributesVariablesList.Add(new AttributesVariables { AttributeCode = AttribCode, AttributeName = AttribName, VariableCode = varCode, VariableName = varName, DateSet = DateTime.Today, CreatedBy = Creator });

            return Json(new
            {
                aaData = AttributesVariables.AttributesVariablesList.Select(x => new[] { x.AttributeCode, x.AttributeName, x.VariableCode, x.VariableName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
