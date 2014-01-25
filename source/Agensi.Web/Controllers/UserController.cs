using Agensi.Web.Core.Context;
using Agensi.Web.Core.Controllers;
using Agensi.Web.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agensi.Web.Controllers
{
    public class UserController : AgensiController
    {
        //
        // GET: /User/
        public ActionResult Index(string viewUserId = null)
        {
            if (viewUserId == null)
                viewUserId = LoginUser.UserId;

            var model = new UserIndexModel(LoginUser, viewUserId);

            return View(model);
        }
	}
}