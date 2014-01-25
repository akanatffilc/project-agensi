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
        
        #endregion

        public static AgensiUser Create(string userId)
        {
            return new AgensiUser(userId);
        }

        protected AgensiUser(string userId)
        {
            UserId = userId;
        }

        //TODO:キャッシュにした方がいい
        public string UserName
        {
            get
            {
                var result = AspNetUserDataLogic.Value.Find(UserId);
                return result.UserName;
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
    }
}
