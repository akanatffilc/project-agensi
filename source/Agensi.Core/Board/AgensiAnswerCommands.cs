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
    public class AgensiAnswerCommands
    {
        private static Lazy<AnswerVoteDataLogic> AnswerVoteDataLogic = new Lazy<AnswerVoteDataLogic>(() => { return new AnswerVoteDataLogic(); });
        private static Lazy<AnswerVoteDownDataLogic> AnswerVoteDownDataLogic = new Lazy<AnswerVoteDownDataLogic>(() => { return new AnswerVoteDownDataLogic(); });
        private static Lazy<AnswerDataLogic> AnswerDataLogic = new Lazy<AnswerDataLogic>(() => { return new AnswerDataLogic(); });


        internal AgensiAnswerCommands(AgensiUser user,AgensiAnswer answer)
        {
            _user = user;
            _answer = answer;
        }

        private readonly AgensiUser _user;
        public AgensiAnswer _answer { get; private set; }

        private AgensiEnums.VoteStatus? _voteStatus;
        private AgensiEnums.VoteStatus VoteStatus
        {
            get
            {
                if (_voteStatus != null)
                    return _voteStatus.Value;

                var row = _answer.Votes.FirstOrDefault(x => x.UserId == _user.UserId);
                if (row != null)
                    _voteStatus = (AgensiEnums.VoteStatus)row.VoteStatus;
                else
                    _voteStatus = AgensiEnums.VoteStatus.None;
                return _voteStatus.Value;
            }
            set { _voteStatus = value; }
        }

        public AgensiEnums.VoteStatus VoteUp()
        {
            switch (VoteStatus)
            {
                case AgensiEnums.VoteStatus.Down:
                    {
                        var row = AnswerVoteDataLogic.Value.Delete(_answer.AnswerId, _user.UserId);
                        if (row > 0)
                            VoteStatus = AgensiEnums.VoteStatus.None;
                        return VoteStatus;
                    }
                case AgensiEnums.VoteStatus.None:
                    {
                        var row = AnswerVoteDataLogic.Value.Add(new AnswerVote
                        {
                            AnswerId = _answer.AnswerId,
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
                        var row = AnswerVoteDataLogic.Value.Add(new AnswerVote
                        {
                            AnswerId = _answer.AnswerId,
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
                        var row = AnswerVoteDataLogic.Value.Delete(_answer.AnswerId, _user.UserId);
                        if (row > 0)
                            VoteStatus = AgensiEnums.VoteStatus.None;
                        return VoteStatus;
                    }
                default:
                    throw new InvalidOperationException("VoteStatus");
            }
        }

        public void AddChildAnswer(string text)
        {
            var childAnswer = new Answer{
                AnswerUserId = _user.UserId,
                ParentAnswerId = _answer.AnswerId,
                QueryId = _answer.QueryId,
                Text = text,
                LanguageId = _answer.Language.LanguageId,
                AnswerDate = DateTime.Now,
                UpdateTime = DateTime.Now
            };
            AnswerDataLogic.Value.Add(childAnswer);   
        }
    }
}
