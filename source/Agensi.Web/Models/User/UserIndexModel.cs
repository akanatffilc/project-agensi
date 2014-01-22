using Agensi.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agensi.Web.Models.User
{
    public class UserIndexModel
    {
        public UserIndexModel(AgensiUser user)
        {
            AgensiUser = user;
        }

        public AgensiUser AgensiUser { get; private set; }
    }
}