using Agensi.Data.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.Repositories
{
    public class UserCommentRepository : IUserCommentRepository
    {
        private AgensiDBEntities context;

        public UserCommentRepository()
        {
            context = new AgensiDBEntities();
        }

        public UserComment[] FindByFromUserId(string userId)
        {
            return context.UserComments.Where(x => x.FromUserId == userId).ToArray();
        }

        public UserComment[] FindByToUserId(string userId)
        {
            return context.UserComments.Where(x => x.ToUserId == userId).ToArray();
        }

        public void Add(UserComment userComment)
        {
            context.UserComments.Add(userComment);
        }

        public void UpdateViewFlag(long commentId, int viewFlag)
        {
            var row = context.UserComments.Find(commentId);
            if (row != null)
            {
                row.ViewFlag = viewFlag;
                row.UpdateTime = DateTime.Now;
            }
        }

        public void Delete(long commentId)
        {
            var row = context.UserComments.Find(commentId);
            if (row != null)
                context.UserComments.Remove(row);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

    }
}
