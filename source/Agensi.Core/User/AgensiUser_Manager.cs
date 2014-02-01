using Agensi.Core.Board;
using Agensi.Core.User.Comment;
using Agensi.Core.User.Follow;
using Agensi.Core.User.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.User
{
    public partial class AgensiUser
    {
        private ProfileManager _profileManager;
        public ProfileManager CreateProfileManager()
        {
            return _profileManager ??
                (_profileManager = new ProfileManager(this));
        }

        private FollowManager _followManager;
        public FollowManager CreateFollowManager()
        {
            return _followManager ??
                (_followManager = new FollowManager(this));
        }

        private CommentManager _commentManager;
        public CommentManager CreateCommentManager()
        {
            return _commentManager ??
                (_commentManager = new CommentManager(this));
        }

        private BoardManager _boardManager;
        public BoardManager CreateBoardManager()
        {
            return _boardManager ??
                (_boardManager = new BoardManager(this));
        }
    }
}
