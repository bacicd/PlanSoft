using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MvcAdminTemplate.Controllers
{
    [Authorize]
    public class OpenTicketController : Controller
    {
        //
        // GET: /OpenTicket/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult openTicket(string fname, string lname, string title,
                                        string companyname, string email, string phone,
                                        string address, string city, string state, string zip,
                                        string comment)
        {
            MailMessage mail = new MailMessage();

            mail.To.Add("dbacic@usi.edu");
            mail.To.Add("bdbrown4@eagles.usi.edu");
            //mail.To.Add("lfmacias@eagles.usi.edu");

            mail.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();

            mail.Subject = "Open Ticket from HResonance";
            mail.Body = "<div style=\"font: 15px Calibri, arial;\">";
            mail.Body += "<p>" + "First Name: " + fname + "</p>";
            mail.Body += "<p>" + "Last Name: " + lname + "</p>";
            mail.Body += "<p>" + "Title: " + title + "</p>";
            mail.Body += "<p>" + "Company: " + companyname + "</p>";
            mail.Body += "<p>" + "Email: " + email + "</p>";
            mail.Body += "<p>" + "Phone Number: " + phone + "</p>";
            mail.Body += "<p>" + "Address: " + address + "</p>";
            mail.Body += "<p>" + "City: " + city + "</p>";
            mail.Body += "<p>" + "State: " + state + "</p>";
            mail.Body += "<p>" + "ZIP: " + zip + "</p><br />";
            mail.Body += "<p>Issue:</p>";
            mail.Body += "<p>" + comment + "</p>";
            mail.Body += "</div>";
            smtpClient.Send(mail);

            return Json(new { message = "success!",
                view = RedirectToAction("Index", "Home")
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
