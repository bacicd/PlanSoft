using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdminTemplate.Models;

namespace MvcAdminTemplate.Controllers
{
    public class AttributesController : Controller
    {
        //
        // GET: /Attributes/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoadAttributes()
        {
            return Json(new
            {
                aaData = AttributesView.AttributesList.Select(x => new[] { x.ElementCode, x.ElementName, x.AttributeCode, x.AttributeName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(string EleCode)
        {
            foreach (AttributesView i in AttributesView.AttributesList)
            {
                if (i.ElementCode == EleCode)
                {
                    AttributesView.AttributesList.Remove(i);
                    return Json(new
                    {
                        aaData = AttributesView.AttributesList.Select(x => new[] { x.ElementCode, x.ElementName, x.AttributeCode, x.AttributeName, x.DateSet.ToString(), x.CreatedBy })
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new
            {
                aaData = AttributesView.AttributesList.Select(x => new[] { x.ElementCode, x.ElementName, x.AttributeCode, x.AttributeName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(string EleCode, string NewEleCode, string NewEleName, string NewAttribCode, string NewAttribName)
        {
            foreach (AttributesView i in AttributesView.AttributesList)
            {
                if (i.ElementCode == EleCode)
                {
                    i.ElementCode = NewEleCode;
                    i.ElementName = NewEleName;
                    i.AttributeCode = NewAttribCode;
                    i.AttributeName = NewAttribName;
                    i.DateSet = DateTime.Today;

                    return Json(new
                    {
                        aaData = AttributesView.AttributesList.Select(x => new[] { x.ElementCode, x.ElementName, x.AttributeCode, x.AttributeName, x.DateSet.ToString(), x.CreatedBy })
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new
            {
                aaData = AttributesView.AttributesList.Select(x => new[] { x.ElementCode, x.ElementName, x.AttributeCode, x.AttributeName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(string EleCode, string EleName, string AttribCode, string AttribName, string Creator)
        {
            AttributesView.AttributesList.Add(new AttributesView { ElementCode = EleCode, ElementName = EleName, AttributeCode = AttribCode, AttributeName = AttribName, DateSet = DateTime.Today, CreatedBy = Creator });

            return Json(new
            {
                aaData = AttributesView.AttributesList.Select(x => new[] { x.ElementCode, x.ElementName, x.AttributeCode, x.AttributeName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }
    }
}

