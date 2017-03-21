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
        private DBModelEntities db = new DBModelEntities();
        //
        // GET: /Attributes/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoadAttributes()
        {
            Attribute.AttributesList = db.Attributes.ToList();

            return Json(new
            {
                //aaData = AttributesViewModel.AttributesList.Select(x => new[] { x.ElementCode, x.ElementName, x.AttributeCode, x.AttributeName, x.DateSet.ToString(), x.CreatedBy })
                aaData = Attribute.AttributesList.Select(x => new[] { x.ElementCode, x.ElementName, x.AttributeCode, x.AttributeName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(string EleCode)
        {
            Attribute.AttributesList = db.Attributes.ToList();
            Attribute attribute = db.Attributes.Find(Convert.ToInt32(EleCode));

            db.Elements.Remove(attribute);
            db.SaveChanges();

            /*  foreach (AttributesViewModel i in AttributesViewModel.AttributesList)
              {
                  if (i.ElementCode == EleCode)
                  {
                      AttributesViewModel.AttributesList.Remove(i);
                      return Json(new
                      {
                          aaData = AttributesViewModel.AttributesList.Select(x => new[] { x.ElementCode, x.ElementName, x.AttributeCode, x.AttributeName, x.DateSet.ToString(), x.CreatedBy })
                      }, JsonRequestBehavior.AllowGet);
                  }
              }
           */
            return Json(new
            {
                //aaData = AttributesViewModel.AttributesList.Select(x => new[] { x.ElementCode, x.ElementName, x.AttributeCode, x.AttributeName, x.DateSet.ToString(), x.CreatedBy })
                aaData = Attribute.AttributesList.Select(x => new[] { x.ElementCode, x.ElementName, x.AttributeCode, x.AttributeName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(string EleCode, string NewEleCode, string NewEleName, string NewAttribCode, string NewAttribName)
        {
            Attribute.AttributesList = db.Attributes.ToList();
            Attribute attribute = db.Attributes.Find(Convert.ToInt32(EleCode));

            //2. change attribute name in disconnected mode (out of ctx scope)
            attribute.Code = Convert.ToInt32(NewAttribCode);
            attribute.Name = NewAttribName;

            db.SaveChanges();

            /*  foreach (AttributesViewModel i in AttributesViewModel.AttributesList)
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
                          aaData = AttributesViewModel.AttributesList.Select(x => new[] { x.ElementCode, x.ElementName, x.AttributeCode, x.AttributeName, x.DateSet.ToString(), x.CreatedBy })
                      }, JsonRequestBehavior.AllowGet);
                  }
              }
           */
            return Json(new
            {
                //aaData = AttributesViewModel.AttributesList.Select(x => new[] { x.ElementCode, x.ElementName, x.AttributeCode, x.AttributeName, x.DateSet.ToString(), x.CreatedBy })
                aaData = Attribute.AttributesList.Select(x => new[] { x.ElementCode, x.ElementName, x.AttributeCode, x.AttributeName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(string AttribCode, string AttribName, string Creator)
        {
            //AttributesViewModel.AttributesList.Add(new AttributesViewModel { ElementCode = EleCode, ElementName = EleName, AttributeCode = AttribCode, AttributeName = AttribName, DateSet = DateTime.Today, CreatedBy = Creator });

            Attribute.AttributesList.Add(new Attribute { Code = Convert.ToInt32(AttribCode), Name = AttribCode, CreatedOn = DateTime.Today, CreatedBy = Creator });

            Attribute addAttribute = new Attribute();
            addAttribute.Code = Convert.ToInt32(AttribCode);
            addAttribute.OrgID = 2;
            addAttribute.Name = AttribName;
            addAttribute.CreatedOn = DateTime.Today;
            addAttribute.CreatedBy = Creator;
            db.Elements.Add(addAttribute);
            db.SaveChanges();

            return Json(new
            {
                //aaData = AttributesViewModel.AttributesList.Select(x => new[] { x.ElementCode, x.ElementName, x.AttributeCode, x.AttributeName, x.DateSet.ToString(), x.CreatedBy })
                aaData = Attribute.AttributesList.Select(x => new[] { x.ElementCode, x.ElementName, x.AttributeCode, x.AttributeName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }
    }
}

