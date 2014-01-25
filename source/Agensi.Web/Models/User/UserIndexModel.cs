using Agensi.Core.User;
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

    }
}