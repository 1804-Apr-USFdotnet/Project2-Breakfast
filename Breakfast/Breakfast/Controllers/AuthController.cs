using Breakfast.Models;
using Breakfast.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Breakfast.Controllers
{
    //[AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Login model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = userManager.Find(model.Email, model.Password);

            if (user != null)
            {
                var identity =  userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                GetAuthenticationManager().SignIn(identity);
                return Redirect(model.ReturnUrl);
            }

            // if login fails
            return View();
        }

        public AuthController()
            : this(Startup.UserManagerFactory.Invoke())
        {
        }

        public AuthController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && userManager != null)
            {
                userManager.Dispose();
            }
            base.Dispose(disposing);
        }

        private IAuthenticationManager GetAuthenticationManager()
        {
            var ctx = Request.GetOwinContext();
            return ctx.Authentication;
        }
    }
}