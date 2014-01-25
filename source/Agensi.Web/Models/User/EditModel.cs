using Agensi.Core.User;
using Agensi.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agensi.Web.Models.User
{
    public class EditModel : AgensiModel
    {
        public EditModel(AgensiUser loginUser)
            :base(loginUser)
        {
        }
    }
}