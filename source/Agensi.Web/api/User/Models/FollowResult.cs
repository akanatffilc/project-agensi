using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agensi.Web.api.User.Models
{
    public class FollowResult
    {
        public FollowResult()
        {
            Result = false;
        }

        public bool Result { get; set; }

        public bool FollowResult { get; set; }
    }
}