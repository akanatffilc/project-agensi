using Agensi.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agensi.Web.Core.Models
{
    public class AgensiModel
    {
        public AgensiModel(AgensiUser loginUser)
        {
            LoginUser = loginUser;
        }
        public AgensiUser LoginUser { get; private set; }
    }
}