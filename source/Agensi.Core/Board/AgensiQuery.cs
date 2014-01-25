using Agensi.Core.Category;
using Agensi.Core.DataLogic.Core;
using Agensi.Core.Language;
using Agensi.Core.User;
using Agensi.Data.Core;
using Agensi.Data.Core.IRepositories;
using Agensi.Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.Board
{
    public class AgensiQuery
    {
        public static AgensiQuery Create(long queryId)
        {
            return new AgensiQuery(queryId);
        }

        #region Constructor
        public AgensiQuery(long queryId)
        {
            Query = QueryDataLogic.Value.Find(queryId);
        }
        #endregion 

        private Lazy<QueryDataLogic> QueryDataLogic = new Lazy<QueryDataLogic>(() => { return new QueryDataLogic(); });
        private Lazy<QueryVoteDataLogic> QueryVoteDataLogic = new Lazy<QueryVoteDataLogic>(() => { return new QueryVoteDataLogic(); });
        private Lazy<QueryVoteDownDataLogic> QueryVoteDownDataLogic = new Lazy<QueryVoteDownDataLogic>(() => { return new QueryVoteDownDataLogic(); });
        private Lazy<AnswerDataLogic> AnswerDataLogic = new Lazy<AnswerDataLogic>(() => { return new AnswerDataLogic(); });


        private readonly Query Query;

        private AgensiAnswer[] _answers;
        public AgensiAnswer[] Answers {
            get
            {
                return _answers ??
                    (_answers = AnswerDataLogic.Value.FindByQueryId(Query.QueryId).ToArray()
                .Select(x => AgensiAnswer.Create(x.AnswerId)).ToArray());
            }
        }

        public long QueryId { get { return Query.QueryId; } }

        private AgensiUser _ownerUser;
        public AgensiUser OwnerUser { get { return _ownerUser ?? (_ownerUser = AgensiUser.Create(Query.OwnerUserId)); } }

        public string Title { get { return Query.Title; } }
        private Genre _genre;
        public Genre Genre { get { return _genre ?? (_genre = new Genre(Query.Genre)); } }
        private MediaCategory _mediaCategory;
        public MediaCategory MediaCategory { get { return _mediaCategory ?? (_mediaCategory = new MediaCategory(Query.MediaCategory)); } }
        private AgensiLanguage _agensiLanguage;
        public AgensiLanguage Language { get { return _agensiLanguage ?? (_agensiLanguage = new AgensiLanguage(Query.LanguageId)); } }
        private AgensiLanguage _toAgensiLanguage;
        public AgensiLanguage ToLanguage { get { return _toAgensiLanguage ?? (_toAgensiLanguage = new AgensiLanguage(Query.ToLanguage)); } }
        public string Text { get { return Query.Text; } }
        public DateTime QueryDate { get { return Query.QueryDate; } }

        private QueryVote[] _votes;
        public QueryVote[] Votes { get { return _votes ?? (_votes = QueryVoteDataLogic.Value.FindByQueryId(Query.QueryId)); } }

        private QueryVoteDown[] _voteDowns;
        public QueryVoteDown[] VoteDowns { get { return _voteDowns ?? (_voteDowns = QueryVoteDownDataLogic.Value.FindByQueryId(Query.QueryId)); } }
    }
}
