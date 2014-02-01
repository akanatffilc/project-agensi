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
            _query = QueryDataLogic.Value.Find(queryId);
        }

        public AgensiQuery(Query query)
        {
            _query = query;
        }
        #endregion 

        private Lazy<QueryDataLogic> QueryDataLogic = new Lazy<QueryDataLogic>(() => { return new QueryDataLogic(); });
        private Lazy<QueryVoteDataLogic> QueryVoteDataLogic = new Lazy<QueryVoteDataLogic>(() => { return new QueryVoteDataLogic(); });
        private Lazy<QueryVoteDownDataLogic> QueryVoteDownDataLogic = new Lazy<QueryVoteDownDataLogic>(() => { return new QueryVoteDownDataLogic(); });
        private Lazy<AnswerDataLogic> AnswerDataLogic = new Lazy<AnswerDataLogic>(() => { return new AnswerDataLogic(); });
        private Lazy<QueryViewDataLogic> QueryViewDataLogic = new Lazy<QueryViewDataLogic>(() => { return new QueryViewDataLogic(); });
        private Lazy<QueryTagDataLogic> QueryTagDataLogic = new Lazy<QueryTagDataLogic>(() => { return new QueryTagDataLogic(); });

        private readonly Query _query;

        public bool IsExists
        {
            get
            {
                return _query != null;
            }
        }

        private AgensiAnswer[] _answers;
        public AgensiAnswer[] Answers {
            get
            {
                return _answers ??
                    (_answers = AnswerDataLogic.Value.FindByQueryId(_query.QueryId).ToArray()
                .Select(x => AgensiAnswer.Create(x.AnswerId)).ToArray());
            }
        }

        public long QueryId { get { return _query.QueryId; } }

        private AgensiUser _ownerUser;
        public AgensiUser OwnerUser { get { return _ownerUser ?? (_ownerUser = AgensiUser.Create(_query.OwnerUserId)); } }

        public string Title { get { return _query.Title; } }

        private MediaCategory _mediaCategory;
        public MediaCategory MediaCategory { get { return _mediaCategory ?? (_mediaCategory = new MediaCategory(_query.MediaCategory)); } }
        private AgensiLanguage _agensiLanguage;
        public AgensiLanguage Language { get { return _agensiLanguage ?? (_agensiLanguage = new AgensiLanguage(_query.LanguageId)); } }
        private AgensiLanguage _toAgensiLanguage;
        public AgensiLanguage ToLanguage { get { return _toAgensiLanguage ?? (_toAgensiLanguage = new AgensiLanguage(_query.ToLanguage)); } }
        public string Text { get { return _query.Text; } }
        public DateTime QueryDate { get { return _query.QueryDate; } }

        private QueryVote[] _votes;
        public QueryVote[] Votes { get { return _votes ?? (_votes = QueryVoteDataLogic.Value.FindByQueryId(_query.QueryId)); } }

        private QueryView[] _queryViews;
        private QueryView[] QueryViews
        {
            get
            {
                if (_queryViews != null)
                    return _queryViews;

                _queryViews = QueryViewDataLogic.Value.FindByQueryId(QueryId);

                return _queryViews;
            }
        }

        public long Views { get { return QueryViews.Count(); } }

        private QueryTag[] _queryTags;
        public QueryTag[] QueryTags
        {
            get
            {
                return _queryTags ??
                    (_queryTags = QueryTagDataLogic.Value.FindByQueryId(QueryId));
            }
        }


        #region Methods

        public bool IsVoted(string userId)
        {
            return Votes.Any(x => x.UserId == userId);
        }

        #endregion
    }
}
