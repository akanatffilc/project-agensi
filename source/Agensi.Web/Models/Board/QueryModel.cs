using Agensi.Core.Board;
using Agensi.Core.Language;
using Agensi.Core.User;
using Agensi.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agensi.Web.Models.Board
{
    public class ThreadModel: AgensiModel
    {
        public AgensiQuery AgensiQuery { get; private set; }

        public ThreadModel(AgensiUser loginUser,long queryId)
            : base(loginUser)
        {
            AgensiQuery = new AgensiQuery(queryId);
        }

        public AgensiLanguage[] Languages { get { return AgensiLanguageManager.AllLanguage; } }
        
    }
}