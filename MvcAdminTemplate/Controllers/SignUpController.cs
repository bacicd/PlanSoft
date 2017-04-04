using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MvcAdminTemplate.Controllers
{
    public class SignUpController : Controller
    {
        //
        // GET: /SignUp/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult emailSignUp(string fname, string lname, string title,
                                        string companyname, string email, string phone,
                                        string address, string city, string state, string zip)
        {
            MailMessage mail = new MailMessage();

            mail.To.Add("dbacic@usi.edu");

            mail.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();

            mail.Subject = "Sign Up from HResonance";
            mail.Body = "<div style=\"font: 15px Calibri, arial;\">";
            mail.Body += "<p>" + fname + "</p>";
            mail.Body += "<p>" + lname + "</p>";
            mail.Body += "<p>" + title + "</p>";
            mail.Body += "<p>" + companyname + "</p>";
            mail.Body += "<p>" + email + "</p>";
            mail.Body += "<p>" + phone + "</p>";
            mail.Body += "<p>" + address + "</p>";
            mail.Body += "<p>" + city + "</p>";
            mail.Body += "<p>" + state + "</p>";
            mail.Body += "<p>" + zip + "</p>";
            smtpClient.Send(mail);

            return View();
        }

    }
}
