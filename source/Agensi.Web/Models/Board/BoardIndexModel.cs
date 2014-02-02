using Agensi.Core.Board;
using Agensi.Core.DataLogic.Core;
using Agensi.Core.User;
using Agensi.Data.Core;
using Agensi.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agensi.Web.Models.Board
{
    public class BoardIndexModel : AgensiModel
    {
        public BoardIndexModel(AgensiUser loginUser)
            : base(loginUser)
        {
            var manager = loginUser.CreateBoardManager();
            AgensiQueries = manager.FindQueryAll();
        }

        public AgensiQuery[] AgensiQueries { get; private set; }
    }
}