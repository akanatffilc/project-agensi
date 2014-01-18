using Agensi.Core.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agensi.Web.Models.Board
{
    public class QueryModel
    {
        public AgensiQuery AgensiQuery { get; private set; }

        public QueryModel(long queryId)
        {
            AgensiQuery = new AgensiQuery(queryId);
        }
    }
}