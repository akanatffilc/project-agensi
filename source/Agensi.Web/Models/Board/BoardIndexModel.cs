using Agensi.Core.Board;
using Agensi.Core.DataLogic.Core;
using Agensi.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agensi.Web.Models.Board
{
    public class BoardIndexModel
    {
        public BoardIndexModel()
        {
            AgensiQueries = new QueryDataLogic().FindAll();
        }

        public Query[] AgensiQueries { get; private set; }
    }
}