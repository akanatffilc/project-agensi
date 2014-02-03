using Agensi.Core.User;
using Agensi.Web.Models.Board;
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
            AskPartialModel = new AskPartialModel();
        }
        public AgensiUser LoginUser { get; private set; }

        public AskPartialModel AskPartialModel { get; private set; }
    }
}