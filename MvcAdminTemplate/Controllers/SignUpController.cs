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
										string address, string city, string state, string zip,
                                        string Test, string Survey, string Recommend, string Implement,
                                        string Discuss)
		{
			MailMessage mail = new MailMessage();

            mail.To.Add("dbacic@usi.edu");
            mail.To.Add("bdbrown4@eagles.usi.edu");
            //mail.To.Add("lfmacias@eagles.usi.edu");

            mail.IsBodyHtml = true;

			SmtpClient smtpClient = new SmtpClient();

			mail.Subject = "Sign Up from HResonance";
			mail.Body = "<div style=\"font: 15px Calibri, arial;\">";
			mail.Body += "<p>" + "First Name: "+ fname + "</p>";
			mail.Body += "<p>" + "Last Name: " + lname + "</p>";
			mail.Body += "<p>" + "Title: " + title + "</p>";
			mail.Body += "<p>" + "Company: " + companyname + "</p>";
			mail.Body += "<p>" + "Email: " + email + "</p>";
			mail.Body += "<p>" + "Phone Number: " + phone + "</p>";
			mail.Body += "<p>" + "Address: " + address + "</p>";
			mail.Body += "<p>" + "City: " + city + "</p>";
			mail.Body += "<p>" + "State: " + state + "</p>";
			mail.Body += "<p>" + "ZIP: " + zip + "</p></br>";
            if (Test != "" || Survey != "" || Recommend != "" || Implement != "" || Discuss != "")
            {
                mail.Body += "<p>Below is a list of what I am willing to help with!</p>";
                mail.Body += "<ul>";
                if (Test != "")
                {
                    mail.Body += "<li>" + Test + "</li>";
                }
                if (Survey != "")
                {
                    mail.Body += "<li>" + Survey + "</li>";
                }
                if (Recommend != "")
                {
                    mail.Body += "<li>" + Recommend + "</li>";
                }
                if (Implement != "")
                {
                    mail.Body += "<li>" + Implement + "</li>";
                }
                if (Discuss != "")
                {
                    mail.Body += "<li>" + Discuss + "</li>";
                }
                mail.Body += "</ul>";
            }
            mail.Body += "</div>";
            smtpClient.Send(mail);

			return Json(new { message = "success!" }, JsonRequestBehavior.AllowGet);
		}

	}
}
