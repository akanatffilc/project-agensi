using Agensi.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agensi.Web.Models.User
{
    public class UserIndexModel
    {
        public UserIndexModel(AgensiUser loginUser,string viewUserId)
        {
            LoginUser = loginUser;
            ViewUser = AgensiUser.Create(viewUserId);
        }

        public AgensiUser LoginUser { get; private set; }

        public AgensiUser ViewUser { get; private set; }


    }
}