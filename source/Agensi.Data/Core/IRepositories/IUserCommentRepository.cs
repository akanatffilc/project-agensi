using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.IRepositories
{
    public interface IUserCommentRepository
    {
        UserComment[] FindByFromUserId(string userId);

        UserComment[] FindByToUserId(string userId);

        void Add(UserComment userComment);

        void UpdateViewFlag(long commentId, int viewFlag);

        void Delete(long commentId);

        void Save();
    }
}
