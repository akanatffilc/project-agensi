using Agensi.Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agensi.Web.api.Board.Models
{
    public class VoteResult
    {
        public bool IsSuccess { get; set; }

        public AgensiEnums.VoteStatus VoteStatus { get; set; }
    }
}