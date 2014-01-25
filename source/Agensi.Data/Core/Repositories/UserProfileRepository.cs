using Agensi.Data.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Agensi.Data.Core.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private AgensiDBEntities context;

        public UserProfileRepository()
        {
            context = new AgensiDBEntities();
        }


        public UserProfile Find(string userId)
        {
            return context.UserProfiles.Find(userId);
        }

        public void Add(UserProfile userProfile)
        {
            context.UserProfiles.Add(userProfile);
        }

        public void Update(UserProfile userProfile)
        {
            var row = context.UserProfiles.Find(userProfile.UserId);
            if (row == null)
            {
                userProfile.AddTime = DateTime.Now;
                userProfile.UpdateTime = DateTime.Now;
                Add(userProfile);
                return;
            }
                
            row.Comment = userProfile.Comment;
            row.LikeGenre = userProfile.LikeGenre;
            row.LikeLanguage = userProfile.LikeLanguage;
            row.ProfileImage = userProfile.ProfileImage;
            row.UpdateTime = DateTime.Now;
        }

        public void Delete(string userId)
        {
            var row = context.UserProfiles.Find(userId);
            context.UserProfiles.Remove(row);
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
