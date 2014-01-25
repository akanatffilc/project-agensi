using Agensi.Core.DataLogic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.User
{
    public class AgensiUser
    {
        #region repository
        private Lazy<QueryDataLogic> QueryDataLogic = new Lazy<QueryDataLogic>(() => { return new QueryDataLogic(); });
        private Lazy<AnswerDataLogic> AnswerDataLogic = new Lazy<AnswerDataLogic>(() => { return new AnswerDataLogic(); });

        #endregion

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

        public string ProfileComment { get { throw new NotImplementedException(); } }

        public string ProfileImage { get { throw new NotImplementedException(); } }

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
