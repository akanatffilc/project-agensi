using Agensi.Core.User;
using Agensi.Core.User.Comment;
using Agensi.Data.Core;
using Agensi.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agensi.Web.Models.User
{
    public class UserIndexModel : AgensiModel
    {
        public UserIndexModel(AgensiUser loginUser,string viewUserId)
            :base(loginUser)
        {
            ViewUser = AgensiUser.Create(viewUserId);
        }

        public AgensiUser ViewUser { get; private set; }

        public bool IsMypage { get { return LoginUser.UserId == ViewUser.UserId; } }

        private AgensiUserComment[] _userComments;
        public AgensiUserComment[] UserComments
        {
            get
            {
                if (_userComments != null)
                    return _userComments;

                var manager = ViewUser.CreateCommentManager();
                _userComments = manager.ToComments;

                return _userComments;
            }
        }

    }
}