using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Breakfast.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        public ActionResult LogIn()
        {
            return View();
        }
    }
}