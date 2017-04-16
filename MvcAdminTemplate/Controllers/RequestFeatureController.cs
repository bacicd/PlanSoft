using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MvcAdminTemplate.Controllers
{
    public class RequestFeatureController : Controller
    {
        //
        // GET: /RequestFeature/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult requestFeature(string comment)
        {
            MailMessage mail = new MailMessage();

            mail.To.Add("dbacic@usi.edu");
            mail.To.Add("bdbrown4@eagles.usi.edu");
            //mail.To.Add("lfmacias@eagles.usi.edu");

            mail.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();

            mail.Subject = "Requested Features from HResonance";
            mail.Body = "<div style=\"font: 15px Calibri, arial;\">";
            mail.Body += "<h3> Requested Features:</h3>";
            mail.Body += "<p>" + comment + "</p>";
            mail.Body += "</div>";
            smtpClient.Send(mail);

            return Json(new { message = "success!" }, JsonRequestBehavior.AllowGet);
        }

    }
}
