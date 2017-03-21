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
            Models.Attribute.AttributesList = db.Attributes.ToList();

            return Json(new
            {
                //aaData = AttributesViewModel.AttributesList.Select(x => new[] { x.ElementCode, x.ElementName, x.AttributeCode, x.AttributeName, x.DateSet.ToString(), x.CreatedBy })
                aaData = Models.Attribute.AttributesList.Select(x => new[] { x.Element.Code.ToString(), x.Element.Name, x.Code.ToString(), x.Name, x.CreatedOn.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(string EleCode)
        {
            Models.Attribute.AttributesList = db.Attributes.ToList();
            Models.Attribute attribute = db.Attributes.Find(Convert.ToInt32(EleCode));

            db.Attributes.Remove(attribute);
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
                aaData = Models.Attribute.AttributesList.Select(x => new[] { x.Element.Code.ToString(), x.Element.Name, x.Code.ToString(), x.Name, x.CreatedOn.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(string EleCode, string NewEleCode, string NewEleName, string NewAttribCode, string NewAttribName)
        {
            Models.Attribute.AttributesList = db.Attributes.ToList();
            Models.Attribute attribute = db.Attributes.Find(Convert.ToInt32(EleCode));

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
                aaData = Models.Attribute.AttributesList.Select(x => new[] { x.Element.Code.ToString(), x.Element.Name, x.Code.ToString(), x.Name, x.CreatedOn.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(string AttribCode, string AttribName, string Creator)
        {
            //AttributesViewModel.AttributesList.Add(new AttributesViewModel { ElementCode = EleCode, ElementName = EleName, AttributeCode = AttribCode, AttributeName = AttribName, DateSet = DateTime.Today, CreatedBy = Creator });

            Models.Attribute.AttributesList.Add(new Models.Attribute { Code = Convert.ToInt32(AttribCode), Name = AttribCode, CreatedOn = DateTime.Today, CreatedBy = Creator });

            Models.Attribute addAttribute = new Models.Attribute();
            addAttribute.Code = Convert.ToInt32(AttribCode);
            addAttribute.Name = AttribName;
            addAttribute.CreatedOn = DateTime.Today;
            addAttribute.CreatedBy = Creator;
            db.Attributes.Add(addAttribute);
            db.SaveChanges();

            return Json(new
            {
                //aaData = AttributesViewModel.AttributesList.Select(x => new[] { x.ElementCode, x.ElementName, x.AttributeCode, x.AttributeName, x.DateSet.ToString(), x.CreatedBy })
                aaData = Models.Attribute.AttributesList.Select(x => new[] { x.Element.Code.ToString(), x.Element.Name, x.Code.ToString(), x.Name, x.CreatedOn.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }
    }
}

