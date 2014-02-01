using Agensi.Core.Category;
using Agensi.Core.Core;
using Agensi.Core.DataLogic.Core;
using Agensi.Core.Language;
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

        public AgensiLanguage[] LikeLanguage
        {
            get
            {
                return Profile != null
                    ? AgensiLanguageManager.ConvertToLanguage(Profile.LikeLanguage)
                    : new AgensiLanguage[1] { new AgensiLanguage(AgensiEnums.Language.Unknown) };
            }
        }

        //public Genre[] LikeGenre 
        //{
        //    get
        //    {
        //        return Profile != null
        //            ? GenreManager.ConvertToGenre(Profile.LikeGenre)
        //            : new Genre[1] { new Genre(AgensiEnums.Genre.Unknown) };
        //    }
        //}

        public string Comment { get { return Profile != null ? Profile.Comment : ""; } }

        public byte[] ProfileImage
        {
            get
            {
                if(Profile != null && Profile.ProfileImage != null)
                     return Profile.ProfileImage;

                return Convert.FromBase64String(AgensiConsts.DefaultImage);
            }
        }
    }
}
