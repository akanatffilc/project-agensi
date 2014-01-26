using Agensi.Core.Core;
using Agensi.Core.DataLogic.Core;
using Agensi.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.User.Comment
{
    public class CommentManager
    {
        #region repository
        private Lazy<UserCommentDataLogic> UserCommentDataLogic = new Lazy<UserCommentDataLogic>(() => { return new UserCommentDataLogic(); });

        #endregion

        internal CommentManager(AgensiUser user)
        {
            _user = user;
        }
        private readonly AgensiUser _user;

        public void AddComment(string toUserId,string comment)
        {
            UserCommentDataLogic.Value.Add(new UserComment
            {
                FromUserId = _user.UserId,
                ToUserId = toUserId,
                Comment = comment,
                ViewFlag = (int)AgensiEnums.CommentViewFlug.Display,
                AddTime = DateTime.Now,
                UpdateTime = DateTime.Now
            });
        }

        public void UpdateViewFlag(long commentId,AgensiEnums.CommentViewFlug viewFlag)
        {
            UserCommentDataLogic.Value.UpdateViewFlag(commentId, (int)viewFlag);
        }

        private UserComment[] _fromComments;
        /// <summary>
        /// 対象ユーザが送ったコメント
        /// </summary>
        public UserComment[] FromComments
        {
            get
            {
                return _fromComments ??
                    (_fromComments = UserCommentDataLogic.Value.FindByFromUserId(_user.UserId));
            }
        }

        private UserComment[] _toComments;
        /// <summary>
        /// 対象ユーザへ送られたコメント
        /// </summary>
        public UserComment[] ToComments
        {
            get
            {
                return _toComments ??
                    (_toComments = UserCommentDataLogic.Value.FindByToUserId(_user.UserId));
            }
        }
    }
}
