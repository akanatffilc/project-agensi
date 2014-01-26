using Agensi.Data.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.Repositories
{
    public class UserFollowRepository : IUserFollowRepository
    {
        private AgensiDBEntities context;

        public UserFollowRepository()
        {
            context = new AgensiDBEntities();
        }


        public UserFollow[] FindByUserId(string userId)
        {
            return context.UserFollows.Where(x => x.UserId == userId).ToArray();
        }

        public UserFollow[] FindByFollowUserId(string userId)
        {
            return context.UserFollows.Where(x => x.FollowUserId == userId).ToArray();
        }

        public void Add(UserFollow follow)
        {
            context.UserFollows.Add(follow);
        }

        public void Delete(string userId, string followUserId)
        {
            var row = context.UserFollows.FirstOrDefault(x => x.UserId == userId && x.FollowUserId == followUserId);
            if (row != null)
                context.UserFollows.Remove(row);
        }

        public Task AddAsync(UserFollow follow)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(UserFollow follow)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public Task SaveAsync()
        {
            return context.SaveChangesAsync();
        }

    }
}
