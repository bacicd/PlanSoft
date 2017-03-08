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
                aaData = ElementsViewModel.ElementsList.Select(x => new[] { x.ElementId, x.ElementName, x.DateSet.ToString(), x.CreatedBy})
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(string EleID)
        {
            foreach (ElementsViewModel i in ElementsViewModel.ElementsList)
            {
                if (i.ElementId == EleID)
                {
                    ElementsViewModel.ElementsList.Remove(i);
                    return Json(new
                    {
                        aaData = ElementsViewModel.ElementsList.Select(x => new[] { x.ElementId, x.ElementName, x.DateSet.ToString(), x.CreatedBy })
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new
            {
                aaData = ElementsViewModel.ElementsList.Select(x => new[] { x.ElementId, x.ElementName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(string EleID, string newID, string newName)
        {
            foreach (ElementsViewModel i in ElementsViewModel.ElementsList)
            {
                if (i.ElementId == EleID)
                {
                    i.ElementId = newID;
                    i.ElementName = newName;
                    i.DateSet = DateTime.Today;

                    return Json(new
                    {
                        aaData = ElementsViewModel.ElementsList.Select(x => new[] { x.ElementId, x.ElementName, x.DateSet.ToString(), x.CreatedBy })
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new
            {
                aaData = ElementsViewModel.ElementsList.Select(x => new[] { x.ElementId, x.ElementName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(string EleID, string EleName, string Creator)
        {
            ElementsViewModel.ElementsList.Add(new ElementsViewModel { ElementId = EleID, ElementName = EleName, DateSet = DateTime.Today, CreatedBy = Creator });

            return Json(new
            {
                aaData = ElementsViewModel.ElementsList.Select(x => new[] { x.ElementId, x.ElementName, x.DateSet.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }
    }
}


