using Agensi.Core.DataLogic.Core;
using Agensi.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.User
{
    public partial class AgensiUser
    {
        #region repository
        private Lazy<QueryDataLogic> QueryDataLogic = new Lazy<QueryDataLogic>(() => { return new QueryDataLogic(); });
        private Lazy<AnswerDataLogic> AnswerDataLogic = new Lazy<AnswerDataLogic>(() => { return new AnswerDataLogic(); });
        private Lazy<AspNetUserDataLogic> AspNetUserDataLogic = new Lazy<AspNetUserDataLogic>(() => { return new AspNetUserDataLogic(); });
        private Lazy<UserStateDataLogic> UserStateDataLogic = new Lazy<UserStateDataLogic>(() => { return new UserStateDataLogic(); });
        private Lazy<UserFollowDataLogic> UserFollowDataLogic = new Lazy<UserFollowDataLogic>(() => { return new UserFollowDataLogic(); });
        
        #endregion

        public static AgensiUser Create(string userId)
        {
            return new AgensiUser(userId);
        }

        protected AgensiUser(string userId)
        {
            UserId = userId;
        }


        private AspNetUser _agensiUserBase;
        private AspNetUser AgensiUserBase
        {
            get
            {
                return _agensiUserBase ??
                    (_agensiUserBase = AspNetUserDataLogic.Value.Find(UserId));
            }
        }

        public bool IsRegistered
        {
            get
            {
                return AgensiUserBase != null;
            }
        }

        private string UserName;
        //TODO:絶対キャッシュにした方がいい
        public string UserName
        {
            get
            {
                return AgensiUserBase.UserName;
            }
        }

        public string UserId { get; private set; }

        //TODO: キャッシュにした方がいい
        public int QueryNum 
        { 
            get 
            {
                var result = QueryDataLogic.Value.FindByOwnerId(UserId).Count();
                return result;
            } 
        }

        //TODO:キャッシュにした方がいい
        public int AnswerNum
        {
            get
            {
                var result = AnswerDataLogic.Value.FindByAnswerUid(UserId).Count();
                return result;
            }
        }

        private AgensiUser[] _followUsers;
        public AgensiUser[] FollowUsers
        {
            get
            {
                if (_followUsers != null)
                    return _followUsers;

                var result = UserFollowDataLogic.Value.FindByUserId(UserId);

                _followUsers = result.Any() 
                    ? result.Select(x => new AgensiUser(x.FollowUserId)).ToArray() 
                    : new AgensiUser[0];

                return _followUsers;
            }
        }

        private AgensiUser[] _followerUsers;
        public AgensiUser[] FollowerUsers
        {
            get
            {
                if (_followerUsers != null)
                    return _followerUsers;

                var result = UserFollowDataLogic.Value.FindByFollowUserId(UserId);

                _followerUsers = result.Any()
                    ? result.Select(x => new AgensiUser(x.UserId)).ToArray()
                    : new AgensiUser[0];

                return _followerUsers;
            }
        }

        /// <summary>
        /// 対象ユーザをFollowしているかどうかを取得する
        /// </summary>
        /// <param name="followUserId"></param>
        /// <returns></returns>
        public bool IsFollowUser(string followUserId)
        {
            return FollowUsers.Any(x => x.UserId == followUserId);
        }

    }
}
