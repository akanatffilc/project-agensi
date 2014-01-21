using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.Language
{
    public static class AgensiLanguageManager
    {
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
    }
}
