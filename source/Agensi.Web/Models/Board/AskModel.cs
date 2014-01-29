using Agensi.Core.Category;
using Agensi.Core.Language;
using Agensi.Core.User;
using Agensi.Data.Core;
using Agensi.Web.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agensi.Web.Models.Board
{
    public class AskModel : AgensiModel
    {
        public AskModel(AgensiUser loginUser)
            :base(loginUser) { }

        public Query AskQuery { get { return new Query(); } }
        public Tag[] Tag { get { return new Tag[0]; } }

        public AgensiLanguage[] AllLanguage { get { return AgensiLanguageManager.AllLanguage; } }

        public MediaCategory[] MediaCategories { get { return MediaCategoryManager.AllMediaCategory; } }
    }
}