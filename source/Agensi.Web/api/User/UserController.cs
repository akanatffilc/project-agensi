using Agensi.Core.User;
using Agensi.Web.api.User.Models;
using Agensi.Web.Core.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Agensi.Web.api.User
{
    public class UserController : AgensiApiController
    {
        [HttpPost]
        public FollowResult Follow(string toUserId)
        {
            var toUser = AgensiUser.Create(toUserId);
            if (!LoginUser.IsRegistered || !toUser.IsRegistered)
                return new FollowResult { IsSuccess = false};
            var manager = LoginUser.CreateFollowManager();

            if (!LoginUser.IsFollowUser(toUserId))
            {
                var resultNum = manager.AddFollowUser(toUserId);
                return new FollowResult
                {
                    IsSuccess = true,
                    IsFollow = resultNum > 0
                };
            }
            else
            {
                var resultNum = manager.DeleteFollowUser(toUserId);
                return new FollowResult
                {
                    IsSuccess = true,
                    IsFollow = resultNum <= 0
                };
            }
        }
    }
}
