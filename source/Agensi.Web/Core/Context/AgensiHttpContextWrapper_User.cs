using Agensi.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agensi.Web.Core.Context
{
    public partial class AgensiHttpContextWrapper
    {
        private AgensiUser _loginUser;
        public AgensiUser LoginUser
        {
            get
            {
                if (_loginUser != null)
                    return _loginUser;

                var userId = this._context.GetOwinContext().Authentication.User.Claims.First().Value;
                _loginUser = AgensiUser.Create(userId);
                return _loginUser;
            }
        }
    }
}