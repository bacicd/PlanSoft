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
            //Models.Attribute.AttributesList = db.Attributes.ToList();
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
            Models.Attribute attribute = db.Attributes.Find(Convert.ToInt32(NewAttribCode));

            //2. change attribute name in disconnected mode (out of ctx scope)
            //attribute.Code = Convert.ToInt32(NewAttribCode);
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
        public ActionResult Add(string EleCode, string EleName, string AttribCode, string AttribName, string Creator)
        {
            //AttributesViewModel.AttributesList.Add(new AttributesViewModel { ElementCode = EleCode, ElementName = EleName, AttributeCode = AttribCode, AttributeName = AttribName, DateSet = DateTime.Today, CreatedBy = Creator });

            //Models.Attribute.AttributesList.Add(new Models.Attribute { ECode = Convert.ToInt32(EleCode), Code = Convert.ToInt32(AttribCode), Name = AttribName, CreatedOn = DateTime.Today, CreatedBy = Creator });

            Models.Attribute addAttribute = new Models.Attribute();
            addAttribute.Code = Convert.ToInt32(AttribCode);
            addAttribute.Name = AttribName;
            addAttribute.ECode = Convert.ToInt32(EleCode);
            //addAttribute.Element.Name = EleName;
            addAttribute.CreatedOn = DateTime.Today;
            addAttribute.CreatedBy = Creator;
            addAttribute.Field = "test";
            addAttribute.Flag = "test";
            addAttribute.Input = "test";
            addAttribute.Format = "test";
            db.Attributes.Add(addAttribute);
            db.SaveChanges();

            return Json(new
            {
                //aaData = AttributesViewModel.AttributesList.Select(x => new[] { x.ElementCode, x.ElementName, x.AttributeCode, x.AttributeName, x.DateSet.ToString(), x.CreatedBy })
                aaData = Models.Attribute.AttributesList.Select(x => new[] { x.Element.Code.ToString(), x.Element.Name, x.Code.ToString(), x.Name, x.CreatedOn.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DropDownElementCodes(string code)
        {
            Element.ElementsList = db.Elements.ToList();
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
            Element.ElementsList = db.Elements.ToList();
            return Json(new
            {
                name = Element.ElementsList.Select(x => new[] { x.Name })
            }, JsonRequestBehavior.AllowGet);
        }
    }
}

