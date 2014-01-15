using Agensi.Core.Logics.Core;
using Agensi.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agensi.Web.Models.Home
{
    public class HomeModel
    {
        public LanguageMaster Language { get; private set; }

        public HomeModel()
        {
            Language = new LanguageMasterLogic().Find(1);
        }
    }
}