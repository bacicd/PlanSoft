﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAdminTemplate.Controllers
{
    [Authorize]
    public class FormsController : Controller
    {
        //
        // GET: /Forms/
        public ActionResult Index()
        {
            return View();
        }
	}
}