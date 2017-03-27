using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using MvcAdminTemplate.Models;

namespace MvcAdminTemplate.Controllers
{
    [Authorize]
    public class ElementsController : Controller
    {
        private DBModelEntities db = new DBModelEntities();
        //
        // GET: /Elements/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadElements()
        {
            var elementContext = new DBModelEntities();
            IList<Element> elements = elementContext.Elements.ToList();
            return Json(new
            {
                //aaData = ElementsViewModel.ElementsList.Select(x => new[] { x.ElementId, x.ElementName, x.DateSet.ToString(), x.CreatedBy})
                aaData = elements.Select(x => new[] { x.Code.ToString(), x.Name, x.CreatedOn.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
            /*Element.ElementsList = db.Elements.ToList();

            return Json(new
            {
                //aaData = ElementsViewModel.ElementsList.Select(x => new[] { x.ElementId, x.ElementName, x.DateSet.ToString(), x.CreatedBy})
                aaData = Element.ElementsList.Select(x => new[] { x.Code.ToString(), x.Name, x.CreatedOn.ToString(), x.CreatedBy})
            }, JsonRequestBehavior.AllowGet);*/
        }

        [HttpPost]
        public ActionResult Delete(string EleID)
        {
            var elementContext = new DBModelEntities();
            IList<Element> elements = elementContext.Elements.ToList();
            Element element = db.Elements.Find(Convert.ToInt32(EleID));

            db.Elements.Remove(element);
            db.SaveChanges();

            //foreach(ElementsViewModel i in ElementsViewModel.ElementsList)
            //foreach (Element i in Element.ElementsList)
            //{
            //    if (i.Code.ToString() == EleID)
            //    {
            //        Element.ElementsList.Remove(i);
            //        return Json(new
            //        {
            //            //aaData = ElementsViewModel.ElementsList.Select(x => new[] { x.ElementId, x.ElementName, x.DateSet.ToString(), x.CreatedBy })
            //            aaData = Element.ElementsList.Select(x => new[] { x.Code.ToString(), x.Name, x.CreatedOn.ToString(), x.CreatedBy })
            //        }, JsonRequestBehavior.AllowGet);
            //    }
            //}

            return Json(new
            {
                //aaData = ElementsViewModel.ElementsList.Select(x => new[] { x.ElementId, x.ElementName, x.DateSet.ToString(), x.CreatedBy })
                aaData = elements.Select(x => new[] { x.Code.ToString(), x.Name, x.CreatedOn.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(string EleID, string newID, string newName)
        {
            var elementContext = new DBModelEntities();
            IList<Element> elements = elementContext.Elements.ToList();
            Element element = db.Elements.Find(Convert.ToInt32(EleID));

            //2. change element name in disconnected mode (out of ctx scope)
            element.Code = Convert.ToInt32(EleID);
            element.Name = newName;

            db.SaveChanges();
            //foreach (ElementsViewModel i in ElementsViewModel.ElementsList)
            //foreach (Element i in Element.ElementsList)
            //{
            //    if (i.Code.ToString() == EleID)
            //    {
            //        //i.ElementId = newID;
            //        string newElementID = i.Code.ToString();
            //        newElementID = newID;
            //        i.Name = newName;
            //        i.CreatedOn = DateTime.Today;
                    
            //        return Json(new
            //        {
            //            //aaData = ElementsViewModel.ElementsList.Select(x => new[] { x.ElementId, x.ElementName, x.DateSet.ToString(), x.CreatedBy })
            //            aaData = Element.ElementsList.Select(x => new[] { x.Code.ToString(), x.Name, x.CreatedOn.ToString(), x.CreatedBy })
            //        }, JsonRequestBehavior.AllowGet);
            //    }
            //}

            return Json(new
            {
                //aaData = ElementsViewModel.ElementsList.Select(x => new[] { x.ElementId, x.ElementName, x.DateSet.ToString(), x.CreatedBy })
                aaData = elements.Select(x => new[] { x.Code.ToString(), x.Name, x.CreatedOn.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(string EleID, string EleName, string Creator)
        {
            var elementContext = new DBModelEntities();
            IList<Element> elements = elementContext.Elements.ToList();
            //ElementsViewModel.ElementsList.Add(new ElementsViewModel { ElementId = EleID, ElementName = EleName, DateSet = DateTime.Today, CreatedBy = Creator });
            elements.Add(new Element { Code = Convert.ToInt32(EleID), Name = EleName, CreatedOn = DateTime.Today, CreatedBy = Creator });

            Element addElement = new Element();
            addElement.Code = Convert.ToInt32(EleID);
            addElement.OrgID = 2;
            addElement.Name = EleName;
            addElement.CreatedOn = DateTime.Today;
            addElement.CreatedBy = Creator;
            db.Elements.Add(addElement);
            db.SaveChanges();
            
            return Json(new
            {
                //aaData = ElementsViewModel.ElementsList.Select(x => new[] { x.ElementId, x.ElementName, x.DateSet.ToString(), x.CreatedBy })
                aaData = elements.Select(x => new[] { x.Code.ToString(), x.Name, x.CreatedOn.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }
    }
}


