using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Validation;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MvcAdminTemplate.Models;
using System.Web.Security;

namespace MvcAdminTemplate.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private DBModelEntities db = new DBModelEntities();
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.Account userr, string returnURL)
        {
            if (IsValid(userr.Username, userr.Password))
            {
                FormsAuthentication.SetAuthCookie(userr.Username, false);
                return RedirectToLocal(returnURL);
            }
            
            else
            {
                // If we got this far, something failed, redisplay form
                ModelState.AddModelError(String.Empty, "The user name or password provided is incorrect.");
                return View(userr);
            }      
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        // ADD CHECK FOR IF USERNAME IS TAKEN

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(Models.Account user)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if (db.Accounts.Where(u => u.Username == user.Username).Any())
                    {
                        ModelState.AddModelError("Username", "Username is already taken");
                        return View();
                    }

                    else
                    {
                        using (DBModelEntities db = new MvcAdminTemplate.Models.DBModelEntities())
                        {
                            // Hashes using SimpleCrypto Lib
                            // Will be changed to Argon2 in the future
                            var crypto = new SimpleCrypto.PBKDF2();
                            var hashedPass = crypto.Compute(user.Password); // Hashes user password
                            var newUser = db.Accounts.Create();
                            newUser.Username = user.Username;
                            newUser.Password = hashedPass;
                            newUser.PasswordSalt = crypto.Salt;
                            newUser.OrgID = 10; // hardcoded for now (should be user.Organization)
                            newUser.First = user.First;
                            newUser.Last = user.Last;
                            newUser.Role = "User";
                            newUser.CreatedOn = DateTime.Now;
                            db.Accounts.Add(newUser);
                            db.SaveChanges();
                            return RedirectToAction("Register", "Account");
                        }
                    }
                }

                else
                {
                    ModelState.AddModelError("", "Data is incorrect");
                }
            }

            catch(DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach(var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }

                throw;
            }
            return View();
        }

        //
        // GET: /Account/Reset
        [AllowAnonymous]
        public ActionResult Reset()
        {
            return View();
        }

        //
        // POST: /Account/Reset
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Reset(string username, string password1, string password2)
        {
            DBModelEntities db = new MvcAdminTemplate.Models.DBModelEntities();
            var user = db.Accounts.FirstOrDefault(u => u.Username == username);
            if (user != null && password1 == password2)
            {
                var crypto = new SimpleCrypto.PBKDF2();
                var hashedPass = crypto.Compute(password1); // Hashes user password
                user.Password = hashedPass;
                user.PasswordSalt = crypto.Salt;
                db.SaveChanges();
                return RedirectToAction("Reset", "Account");
            }

            else
            {
                ModelState.AddModelError("", "Data is incorrect");
                return View();
            }
        }

        //
        // GET: /Account/Role
        [AllowAnonymous]
        public ActionResult Role()
        {
            return View();
        }

        //
        // POST: /Account/Role
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Role(string username, string role)
        {
            DBModelEntities db = new MvcAdminTemplate.Models.DBModelEntities();
            var user = db.Accounts.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {

                user.Role = role;
                db.SaveChanges();
                return RedirectToAction("Role", "Account");
            }

            else
            {
                ModelState.AddModelError("", "Data is incorrect");
                return View();
            }
        }

        //
        // GET: /Account/Delete
        [AllowAnonymous]
        public ActionResult Delete()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Delete(string username)
        {
            DBModelEntities db = new MvcAdminTemplate.Models.DBModelEntities();
            var user = db.Accounts.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                db.Accounts.Remove(user);
                db.SaveChanges();
                return RedirectToAction("Delete", "Account");
            }

            else
            {
                ModelState.AddModelError("", "User does not exist");
                return View();
            }
        }

        // Logs out and redirects to Home Page
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Landing");
        }

        private bool IsValid(string username, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            bool IsValid = false;

            using (DBModelEntities db = new MvcAdminTemplate.Models.DBModelEntities())
            {
                var user = db.Accounts.FirstOrDefault(u => u.Username == username);
                if(user != null)
                {
                    if(user.Password == crypto.Compute(password, user.PasswordSalt))
                    {
                        IsValid = true;
                    }
                }
            }
            return IsValid;
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        
        public ActionResult accountInfo()
        {
            var accountContext = new DBModelEntities();
            IList<Account> accountList = accountContext.Accounts.ToList();
            Account accountModel = db.Accounts.Find(User.Identity.Name);
            return PartialView("_LoginPartial",accountModel);
        }   
      }
}
