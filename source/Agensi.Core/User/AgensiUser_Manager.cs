using Agensi.Core.User.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.User
{
    public partial class AgensiUser
    {
        private ProfileManager _profileManager;
        public ProfileManager CreateProfileManager()
        {
            return _profileManager ??
                (_profileManager = new ProfileManager(this));
        }
    }
}
