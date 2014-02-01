using Agensi.Core.User;
using Agensi.Web.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Agensi.Web.Core.Controllers
{
    public class AgensiApiController : ApiController
    {
        private AgensiHttpContextWrapper _agensiHttpContext;
        protected AgensiHttpContextWrapper AgensiHttpContext
        {
            get { return _agensiHttpContext ?? (_agensiHttpContext = AgensiHttpContextWrapper.Current); }
        }

        protected string UserName
        {
            get { return AgensiHttpContext.User.Identity.Name; }
        }

        protected AgensiUser LoginUser
        {
            get { return AgensiHttpContext.LoginUser; }
        }

        protected DateTime DatabaseTime
        {
            get { return DateTime.Now; }
        }

        protected bool IsAuthenticated
        {
            get { return AgensiHttpContext.User.Identity.IsAuthenticated; }
        }
    }
}
