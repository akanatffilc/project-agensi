using Agensi.Data.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.Repositories
{
    public class UserStateRepository : IUserStateRepository
    {
        private AgensiDBEntities context;

        public UserStateRepository()
        {
            context = new AgensiDBEntities();
        }


        public UserState Find(string userId)
        {
            return context.UserStates.Find(userId);
        }

        public void Add(UserState userProfile)
        {
            context.UserStates.Add(userProfile);
        }

        public void Update(UserState userProfile)
        {
            context.UserStates.Attach(userProfile);
            context.Entry<UserState>(userProfile).State = EntityState.Modified;
        }

        public void Delete(string userId)
        {
            var row = context.UserStates.Find(userId);
            context.UserStates.Remove(row);
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
