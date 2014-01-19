using Agensi.Core.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agensi.Web.Models.Board
{
    public class ThreadModel
    {
        public AgensiQuery AgensiQuery { get; private set; }

        public ThreadModel(long queryId)
        {
            AgensiQuery = new AgensiQuery(queryId);
        }
    }
}