using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdminTemplate.Models;

/*

    NEED TO FIX DATE FORMATTING
    FORCE SET CURRENT DATE/TIME

*/

namespace MvcAdminTemplate.Controllers
{
    public class TestElementController : Controller
    {
        private DBModelEntities db = new DBModelEntities();

        //
        // GET: /TestElement/

        public ActionResult Index()
        {
            var elements = db.Elements.Include(e => e.Organization);
            return View(elements.ToList());
        }

        //
        // GET: /TestElement/Details/5

        public ActionResult Details(int id = 0)
        {
            Element element = db.Elements.Find(id);
            if (element == null)
            {
                return HttpNotFound();
            }
            return View(element);
        }

        //
        // GET: /TestElement/Create

        public ActionResult Create()
        {
            ViewBag.OrgID = new SelectList(db.Organizations, "ID", "Name");
            return View();
        }

        //
        // POST: /TestElement/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Element element)
        {
            if (ModelState.IsValid)
            {
                db.Elements.Add(element);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrgID = new SelectList(db.Organizations, "ID", "Name", element.OrgID);
            return View(element);
        }

        //
        // GET: /TestElement/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Element element = db.Elements.Find(id);
            if (element == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrgID = new SelectList(db.Organizations, "ID", "Name", element.OrgID);
            return View(element);
        }

        //
        // POST: /TestElement/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Element element)
        {
            if (ModelState.IsValid)
            {
                db.Entry(element).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrgID = new SelectList(db.Organizations, "ID", "Name", element.OrgID);
            return View(element);
        }

        //
        // GET: /TestElement/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Element element = db.Elements.Find(id);
            if (element == null)
            {
                return HttpNotFound();
            }
            return View(element);
        }

        //
        // POST: /TestElement/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Element element = db.Elements.Find(id);
            db.Elements.Remove(element);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}