using Breakfast.Models;
using Breakfast.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
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
            return View(new Account());
        }

        [HttpPost]
        public ActionResult LogIn(Account model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = userManager.Find(model.login.Email, model.login.Password);

            if (user != null)
            {
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                GetAuthenticationManager().SignIn(new AuthenticationProperties { IsPersistent = true }, identity);

                Session["username"] = user.Email;
                Session["zipcode"] = user.zipcode;
                Session["address"] = user.address;
                Session["workaddress"] = user.workAddress;

                return RedirectToAction("index", "home");
            }

            // if login fails
            return View();
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
                return View();
            }

            var user = new AppUser
            {
                UserName = model.register.Email,
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
                new SettingsModel().IntializeSettings(User.Identity.Name);
                return RedirectToAction("index", "home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

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