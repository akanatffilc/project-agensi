using Agensi.Core.DataLogic.Core;
using Agensi.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.User.Profile
{
    public class ProfileManager
    {
        internal ProfileManager(AgensiUser user)
        {
            User = user;
        }
        
        private Lazy<UserProfileDataLogic> UserProfileDataLogic = new Lazy<UserProfileDataLogic>(() => { return new UserProfileDataLogic(); });
        private Lazy<AspNetUserDataLogic> AspNetUserDataLogic = new Lazy<AspNetUserDataLogic>(() => { return new AspNetUserDataLogic(); });

        public AgensiUser User { get; private set; }

        public void UpdateProfile(UserProfile userProfile,string name)
        {
            UserProfileDataLogic.Value.Update(userProfile);
            AspNetUserDataLogic.Value.UpdateName(userProfile.UserId, name);
        }



    }
}
