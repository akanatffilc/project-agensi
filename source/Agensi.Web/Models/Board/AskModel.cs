using Agensi.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agensi.Web.Models.Board
{
    public class AskModel
    {
        public AskModel() { }

        public Query AskQuery { get { return new Query(); } }
    }
}