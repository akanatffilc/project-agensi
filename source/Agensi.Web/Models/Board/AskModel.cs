using Agensi.Core.Category;
using Agensi.Core.Language;
using Agensi.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agensi.Web.Models.Board
{
    public class AskModel
    {
        public AskModel() { }

        public Query AskQuery { get { return new Query(); } }

        public AgensiLanguage[] Languages { get { return AgensiLanguage.AllCreate(); } }

        public MediaCategory[] MediaCategories { get { return MediaCategory.AllCreate(); } }

        public Genre[] Genres { get { return Genre.AllCreate(); } }
    }
}