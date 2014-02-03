using Agensi.Core.DataLogic.Core;
using Agensi.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.User.Comment
{
    public class AgensiUserComment
    {
        private Lazy<UserCommentDataLogic> UserCommentDataLogic = new Lazy<UserCommentDataLogic>(() => { return new UserCommentDataLogic(); });

        internal AgensiUserComment(UserComment userComment)
        {
            _userComment = userComment;
        }

        private readonly UserComment _userComment;

        public UserComment UserComment { get { return _userComment; } }

        private AgensiUser _fromUser;
        public AgensiUser FromUser
        {
            get
            {
                return _fromUser ??
                    (_fromUser = AgensiUser.Create(_userComment.FromUserId));
            }
        }
    }
}
