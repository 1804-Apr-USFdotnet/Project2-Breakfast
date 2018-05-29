using Breakfast.Models;
using Breakfast.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web;
using System.Web.Mvc;

namespace Breakfast.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public ActionResult LogIn()
        {
            return View(new Account());
        }

        [HttpPost]
        public ActionResult LogIn(Account model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.Clear();
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View("LogIn");
            }

            var user = userManager.Find(model.login.Username, model.login.Password);

            if (user != null)
            {
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                GetAuthenticationManager().SignIn(new AuthenticationProperties { IsPersistent = true }, identity);

                Session["zipcode"] = user.zipcode;
                Session["address"] = user.address;
                Session["workaddress"] = user.workAddress;

                return RedirectToAction("index", "home");
            }

            // if login fails
            ModelState.Clear();
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View("LogIn");
        }

        public ActionResult LogOut()
        {
            GetAuthenticationManager().SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("index", "home");
        }

        [HttpPost]
        public ActionResult Register(Account model)
        {
            if (!ModelState.IsValid)
            {
                model.register.Username = string.Empty;
                model.register.Password = string.Empty;
                model.register.Zipcode = string.Empty;
                return View("LogIn");
            }

            var user = new AppUser
            {
                UserName = model.register.Username,
                zipcode = model.register.Zipcode,
                address = model.register.Address,
                workAddress = model.register.WorkAddress
            };

            var result = userManager.Create(user, model.register.Password);

            if (result.Succeeded)
            {
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                GetAuthenticationManager().SignIn(identity);
                //initialize default settings using rest service
                new SettingsModel().InitializeSettings(user.UserName, user.address, user.workAddress);
                return RedirectToAction("index", "home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            model.register.Username = string.Empty;
            model.register.Password = string.Empty;
            model.register.Zipcode = string.Empty;
            return View("LogIn");
        }

        public AuthController()
            : this(Startup.UserManagerFactory.Invoke())
        {
        }

        public AuthController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public AuthController(bool? x, bool? y)
        {
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