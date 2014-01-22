using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.User
{
    public class AgensiUser
    {
        public static AgensiUser Create(string userId)
        {
            return new AgensiUser(userId);
        }

        protected AgensiUser(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; private set; }

        public long MainLanguageId { get { throw new NotImplementedException(); } }

        public long LikeLanguage { get { throw new NotImplementedException(); } }
    }
}
