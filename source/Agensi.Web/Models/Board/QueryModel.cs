using Agensi.Core.Board;
using Agensi.Core.Language;
using Agensi.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agensi.Web.Models.Board
{
    public class ThreadModel
    {
        public AgensiUser LoginUser { get; private set; }

        public AgensiQuery AgensiQuery { get; private set; }

        public ThreadModel(AgensiUser user,long queryId)
        {
            LoginUser = user;
            AgensiQuery = new AgensiQuery(queryId);
        }

        public AgensiLanguage[] Languages { get { return AgensiLanguage.AllCreate(); } }
    }
}