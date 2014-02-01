using Agensi.Core.Core;
using Agensi.Core.DataLogic.Core;
using Agensi.Core.User;
using Agensi.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.Board
{
    public class AgensiQueryCommands
    {
        private Lazy<QueryVoteDataLogic> QueryVoteDataLogic = new Lazy<QueryVoteDataLogic>(() => { return new QueryVoteDataLogic(); });
        private Lazy<QueryVoteDownDataLogic> QueryVoteDownDataLogic = new Lazy<QueryVoteDownDataLogic>(() => { return new QueryVoteDownDataLogic(); });
        private Lazy<QueryViewDataLogic> QueryViewDataLogic = new Lazy<QueryViewDataLogic>(() => { return new QueryViewDataLogic(); });

        internal AgensiQueryCommands(AgensiUser user, AgensiQuery query)
        {
            _user = user;
            _query = query;
        }

        public AgensiQuery _query { get; private set; }

        private AgensiEnums.VoteStatus? _voteStatus;
        private AgensiEnums.VoteStatus VoteStatus {
            get
            {
                if (_voteStatus != null)
                    return _voteStatus.Value;

                var row = _query.Votes.FirstOrDefault(x => x.UserId == _user.UserId);
                if (row != null)
                    _voteStatus = (AgensiEnums.VoteStatus)row.VoteStatus;
                else
                    _voteStatus = AgensiEnums.VoteStatus.None;
                return _voteStatus.Value;
            }
            set { _voteStatus = value; }
        }

        private readonly AgensiUser _user;

        public AgensiEnums.VoteStatus VoteUp()
        {
            switch(VoteStatus)
            {
                case AgensiEnums.VoteStatus.Down:
                    {
                        var row = QueryVoteDataLogic.Value.Delete(_query.QueryId, _user.UserId);
                        if (row > 0)
                            VoteStatus = AgensiEnums.VoteStatus.None;
                        return VoteStatus;
                    }
                case AgensiEnums.VoteStatus.None:
                    {
                        var row = QueryVoteDataLogic.Value.Add(new QueryVote
                        {
                            QueryId = _query.QueryId,
                            UserId = _user.UserId,
                            VoteStatus = (int)AgensiEnums.VoteStatus.Up,
                            AddTime = DateTime.Now
                        });
                        if (row > 0)
                            VoteStatus = AgensiEnums.VoteStatus.Up;
                        return VoteStatus;
                    }
                case AgensiEnums.VoteStatus.Up:
                    return VoteStatus;
                default:
                    throw new InvalidOperationException("VoteStatus");
            }
            
        }

        public AgensiEnums.VoteStatus VoteDown()
        {
            switch (VoteStatus)
            {
                case AgensiEnums.VoteStatus.Down:
                    {
                        return VoteStatus;
                    }
                case AgensiEnums.VoteStatus.None:
                    {
                        var row = QueryVoteDataLogic.Value.Add(new QueryVote
                        {
                            QueryId = _query.QueryId,
                            UserId = _user.UserId,
                            VoteStatus = (int)AgensiEnums.VoteStatus.Down,
                            AddTime = DateTime.Now
                        });
                        if (row > 0)
                            VoteStatus = AgensiEnums.VoteStatus.Down;
                        return VoteStatus;
                    }
                case AgensiEnums.VoteStatus.Up:
                    {
                        var row = QueryVoteDataLogic.Value.Delete(_query.QueryId, _user.UserId);
                        if (row > 0)
                            VoteStatus = AgensiEnums.VoteStatus.None;
                        return VoteStatus;
                    }
                default:
                    throw new InvalidOperationException("VoteStatus");
            }
        }

        public void ViewCountUp()
        {
            QueryViewDataLogic.Value.Add(new QueryView
            {
                QueryId = _query.QueryId,
                UserId = _user.UserId,
                AddTime = DateTime.Now
            });
        }
    }

}
