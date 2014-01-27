using Agensi.Core.Category;
using Agensi.Core.Language;
using Agensi.Core.User;
using Agensi.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agensi.Web.Models.User
{
    public class EditModel : AgensiModel
    {
        public EditModel(AgensiUser loginUser)
            :base(loginUser)
        {
            AllLanguage = AgensiLanguageManager.AllLanguage;
            AllGenre = GenreManager.AllGenre;
        }

        public AgensiLanguage[] AllLanguage { get; private set; }

        public Genre[] AllGenre { get; private set; }
    }
}