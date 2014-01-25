using Agensi.Core.DataLogic.Core;
using Agensi.Core.Util;
using Agensi.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.User
{
    public partial class AgensiUser
    {
        private Lazy<UserProfileDataLogic> UserProfileDataLogic = new Lazy<UserProfileDataLogic>(() => { return new UserProfileDataLogic(); });

        private UserProfile _profile;
        private UserProfile Profile
        {
            get
            {
                return _profile ??
                    (_profile = UserProfileDataLogic.Value.Find(UserId));
            }
        }

        public long LikeLanguage { get { return Profile != null ? Profile.LikeLanguage : 0; } }

        public long LikeGenre { get { return Profile != null ? Profile.LikeGenre : 0; } }

        public string Comment { get { return Profile != null ? Profile.Comment : ""; } }

        public byte[] ProfileImage { get { return Profile != null && Profile.ProfileImage != null ? Profile.ProfileImage : new byte[0]; } }
    }
}
