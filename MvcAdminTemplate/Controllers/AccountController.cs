﻿using System;
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
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //TODO : Do something to authenticate the user
                return RedirectToLocal(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError(String.Empty, "The user name or password provided is incorrect.");
            return View(model);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

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
                    using(var db = new MvcAdminTemplate.Models.DBModelEntities())
                    {
                        // Hashes using SimpleCrypto Lib
                        // Will be changed to Argon2 in the future
                        var hash = new SimpleCrypto.PBKDF2();
                        var hashedPass = hash.Compute(user.Password); // Hashes user password
                        Account newUser = db.Accounts.Create();
                        newUser.Username = user.Username;
                        newUser.Password = hashedPass;
                        newUser.PasswordSalt = hash.Salt;
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

        // Logs out and redirects to Home Page
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private bool IsValid(string username, string password)
        {
            var hash = new SimpleCrypto.PBKDF2();
            bool IsValid = false;

            using (var db = new MvcAdminTemplate.Models.DBModelEntities())
            {
                var user = db.Accounts.FirstOrDefault(u => u.Username == username);
                if(user != null)
                {
                    if(user.Password == hash.Compute(password, user.PasswordSalt))
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
      
      }
}
