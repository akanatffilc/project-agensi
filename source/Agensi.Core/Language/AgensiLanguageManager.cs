using Agensi.Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.Language
{
    public static class AgensiLanguageManager
    {
        private static AgensiLanguage[] _allLanguage;
        /// <summary>
        /// 全てのLanguage(言語)クラスをあらかじめstaticで定義
        /// </summary>
        public static AgensiLanguage[] AllLanguage
        {
            get
            {
                if (_allLanguage != null)
                    return _allLanguage;

                _allLanguage = Enum.GetValues(typeof(AgensiEnums.Language))
                .Cast<AgensiEnums.Language>()
                .Where(x => x != AgensiEnums.Language.Unknown)
                .Select(x => new AgensiLanguage(x)).ToArray();

                return _allLanguage;
            }
        }


        public static AgensiLanguage[] DistinctClass(this IEnumerable<AgensiLanguage> source)
        {
            var list = new List<AgensiLanguage>();
            foreach (var language in source)
            {
                if (list.Select(x => x.LanguageId).Contains(language.LanguageId))
                    continue;
                else
                    list.Add(language);
            }
            return list.ToArray();
        }

        public static AgensiLanguage[] ConvertToLanguage(long languageSource)
        {
            if (languageSource == (long)AgensiEnums.Language.Unknown)
                return new AgensiLanguage[1] { new AgensiLanguage(AgensiEnums.Language.Unknown) };

            return AllLanguage
                .Where(x => (languageSource & x.LanguageId) == x.LanguageId)
                .ToArray();
        }
    }
}
