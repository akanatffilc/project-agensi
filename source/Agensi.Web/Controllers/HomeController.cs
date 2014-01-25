using Agensi.Web.Core.Controllers;
using Agensi.Web.Models;
using Agensi.Web.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agensi.Web.Controllers
{
    public class HomeController : AgensiController
    {
        public ActionResult Index()
        {
            var a = HttpContext.GetOwinContext().Authentication.User.Claims;
            var model = new HomeModel(LoginUser);
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}