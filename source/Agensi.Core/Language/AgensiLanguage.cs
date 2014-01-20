using Agensi.Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.Language
{
    public class AgensiLanguage
    {
        public AgensiLanguage(long languageId)
        {
            AgensiEnums.Language language;
            if (!Enum.TryParse<AgensiEnums.Language>(languageId.ToString(), out language))
                language = AgensiEnums.Language.Unknown;

            languageId = (long)language;
            Name = language.ToString();
        }

        public AgensiLanguage(AgensiEnums.Language language)
        {
            LanguageId = (long)language;
            Name = language.ToString();
        }

        public long LanguageId { get; private set; }

        public string Name { get; private set; }
    }
}
