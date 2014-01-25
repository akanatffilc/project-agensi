using Agensi.Core.Logics.Core;
using Agensi.Core.User;
using Agensi.Data.Core;
using Agensi.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agensi.Web.Models.Home
{
    public class HomeModel :AgensiModel
    {
        public LanguageMaster Language { get; private set; }

        public HomeModel(AgensiUser loginUser)
            :base(loginUser)
        {
            Language = new LanguageMasterLogic().Find(1);
        }
    }
}