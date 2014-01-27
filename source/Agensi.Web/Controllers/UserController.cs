using Agensi.Data.Core;
using Agensi.Web.Core.Context;
using Agensi.Web.Core.Controllers;
using Agensi.Web.Models.User;
using System;
using System.Collections.Generic;
using System.IO;
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

        public ActionResult Edit()
        {
            var model = new EditModel(LoginUser);
            return View(model);
        }

        /// <summary>
        /// TODO: JavaSciprtからlikeLanguage,likeGenreをまとめて送りたい
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="ProfileImage"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditConfirm([Bind(Exclude = "ProfileImage")] UserProfile profile,
            HttpPostedFileBase ProfileImage,
            string name)
        {
            if (ProfileImage != null)
            {
                using (var reader = new BinaryReader(ProfileImage.InputStream))
                {
                    profile.ProfileImage = reader.ReadBytes(ProfileImage.ContentLength);
                    //profile.fp_image_file = fp_image_data.FileName;
                }
            }
            profile.UserId = LoginUser.UserId;
            if (profile.Comment == null)
                profile.Comment = "";

            var manager = LoginUser.CreateProfileManager();
            manager.UpdateProfile(profile, name);

            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        public ActionResult AddFollowUser(string followUserId)
        {
            var manager = LoginUser.CreateFollowManager();
            manager.AddFollowUser(followUserId);

            return RedirectToAction("Index", "User", new { viewUserId = followUserId });
        }

        [HttpPost]
        public ActionResult DeleteFollowUser(string followUserId)
        {
            var manager = LoginUser.CreateFollowManager();
            manager.DeleteFollowUser(followUserId);

            return RedirectToAction("Index", "User", new { viewUserId = followUserId });
        }

        [HttpPost]
        public ActionResult AddComment(string toUserId,string comment)
        {
            var manager = LoginUser.CreateCommentManager();
            manager.AddComment(toUserId,comment);

            return RedirectToAction("Index", "User", new { viewUserId = toUserId });
        }
	}
}