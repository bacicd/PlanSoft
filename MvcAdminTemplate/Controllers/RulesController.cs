﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAdminTemplate.Models;

namespace MvcAdminTemplate.Controllers
{
    public class RulesController : Controller
    {
        //
        // GET: /Rules/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadRuleNames()
        {
            return Json(new
            {
                aaData = Rules.RulesList.Select(x => new[] { x.RuleName})
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadRules()
        {
            return Json(new
            {
                aaData = Rules.RulesList.Select(x => new[] { x.RuleCode, x.RuleName, x.MarkedField, x.RuleStatus, x.DateAdded.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(string RCode)
        {
            foreach (Rules i in Rules.RulesList)
            {
                if (i.RuleCode == RCode)
                {
                    Rules.RulesList.Remove(i);
                    return Json(new
                    {
                        aaData = Rules.RulesList.Select(x => new[] { x.RuleCode, x.RuleName, x.RuleStatus, x.DateAdded.ToString(), x.CreatedBy })
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new
            {
                aaData = Rules.RulesList.Select(x => new[] { x.RuleCode, x.RuleName, x.RuleStatus, x.DateAdded.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(string RCode, string newCode, string newName)
        {
            foreach (Rules i in Rules.RulesList)
            {
                if (i.RuleCode == RCode)
                {
                    i.RuleCode = newCode;
                    i.RuleName = newName;
                    i.DateAdded = DateTime.Today;

                    return Json(new
                    {
                        aaData = Rules.RulesList.Select(x => new[] { x.RuleCode, x.RuleName, x.RuleStatus, x.DateAdded.ToString(), x.CreatedBy })
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new
            {
                aaData = Rules.RulesList.Select(x => new[] { x.RuleCode, x.RuleName, x.RuleStatus, x.DateAdded.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(string RCode, string RName, string RStatus, string Creator)
        {
            Rules.RulesList.Add(new Rules { RuleCode = RCode, RuleName = RName, RuleStatus = RStatus, DateAdded = DateTime.Today, CreatedBy = Creator });

            return Json(new
            {
                aaData = Rules.RulesList.Select(x => new[] { x.RuleCode, x.RuleName, x.RuleStatus, x.DateAdded.ToString(), x.CreatedBy })
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
