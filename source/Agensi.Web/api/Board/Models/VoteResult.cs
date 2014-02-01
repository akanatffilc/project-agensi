using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agensi.Web.api.Board.Models
{
    public class VoteResult
    {
        public bool IsSuccess { get; set; }

        public bool IsVote { get; set; }
    }

    public class VoteDownResult
    {
        public bool IsSuccess { get; set; }

        public bool IsVoteDown { get; set; }
    }
}