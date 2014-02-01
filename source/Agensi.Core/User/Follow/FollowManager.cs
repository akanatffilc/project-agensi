using Agensi.Core.DataLogic.Core;
using Agensi.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.User.Follow
{
    public class FollowManager
    {
        #region repository
        private Lazy<UserFollowDataLogic> UserFollowDataLogic = new Lazy<UserFollowDataLogic>(() => { return new UserFollowDataLogic(); });

        #endregion

        internal FollowManager(AgensiUser user)
        {
            _user = user;
        }
        private readonly AgensiUser _user;

        public int AddFollowUser(string followUserId)
        {
            return UserFollowDataLogic.Value.Add(new UserFollow
            {
                UserId = _user.UserId,
                FollowUserId = followUserId,
                AddTime = DateTime.Now
            });
        }

        public int DeleteFollowUser(string followUserId)
        {
            return UserFollowDataLogic.Value.Delete(_user.UserId, followUserId);
        }
    }
}
