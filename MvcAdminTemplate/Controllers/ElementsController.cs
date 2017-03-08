using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdminTemplate.Models;

namespace MvcAdminTemplate.Controllers
{
    public class ElementsController : Controller
    {
        //
        // GET: /Elements/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadElements()
        {
            return Json(new
            {
                aaData = ElementsView.ElementsList.Select(x => new[] { x.ElementId, x.ElementName, x.DateSet.ToString(), x.CreatedBy})
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(string EleID)
        {
            foreach (ElementsView i in ElementsView.ElementsList)
            {
                if (i.ElementId == EleID)
                {
                    ElementsView.ElementsList.Remove(i);
                    return Json(new
                    {
                        aaData = ElementsView.ElementsList.Select(x => new[] { x.ElementId, x.ElementName, x.DateSet.ToString(), x.CreatedBy })
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new
            {
                aaData = ElementsView.ElementsList.Select(x => new[] { x.ElementId, x.ElementName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(string EleID, string newID, string newName)
        {
            foreach (ElementsView i in ElementsView.ElementsList)
            {
                if (i.ElementId == EleID)
                {
                    i.ElementId = newID;
                    i.ElementName = newName;
                    i.DateSet = DateTime.Today;

                    return Json(new
                    {
                        aaData = ElementsView.ElementsList.Select(x => new[] { x.ElementId, x.ElementName, x.DateSet.ToString(), x.CreatedBy })
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new
            {
                aaData = ElementsView.ElementsList.Select(x => new[] { x.ElementId, x.ElementName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(string EleID, string EleName, string Creator)
        {
            ElementsView.ElementsList.Add(new ElementsView { ElementId = EleID, ElementName = EleName, DateSet = DateTime.Today, CreatedBy = Creator });

            return Json(new
            {
                aaData = ElementsView.ElementsList.Select(x => new[] { x.ElementId, x.ElementName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }
    }
}


