using Agensi.Core.User;
using Agensi.Web.api.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Agensi.Web.api.User
{
    public class UserController : ApiController
    {

        [HttpPost]
        public FollowResult Follow(string fromUserId,string toUserId)
        {
            var user = AgensiUser.Create(fromUserId);
            var toUser = AgensiUser.Create(toUserId);
            if (!user.IsRegistered || !toUser.IsRegistered)
                return new FollowResult();
            var manager = user.CreateFollowManager();

            var follow = manager.AddFollowUser(toUserId);

            var result = new FollowResult{
                Result =  follow > 0
            };

            return result;
        }


        [HttpPost]
        public FollowResult UnFollow(string fromUserId,string toUserId)
        {
            var user = AgensiUser.Create(fromUserId);
            var toUser = AgensiUser.Create(toUserId);
            if (!user.IsRegistered || !toUser.IsRegistered)
                return new FollowResult();

            var manager = user.CreateFollowManager();

            var unFollow = manager.DeleteFollowUser(toUserId);

            var result = new FollowResult
            {
                Result = true,
                FollowResult = unFollow > 0
            };

            return result;
        }
    }
}
