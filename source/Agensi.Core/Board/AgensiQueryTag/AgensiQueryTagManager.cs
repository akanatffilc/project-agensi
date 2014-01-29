using Agensi.Core.DataLogic.Core;
using Agensi.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.Board.AgensiQueryTag
{
    public class AgensiQueryTagManager
    {
        private static Lazy<QueryTagDataLogic> QueryTagDataLogic = new Lazy<QueryTagDataLogic>(() => { return new QueryTagDataLogic(); });
        private static Lazy<TagDataLogic> TagDataLogic = new Lazy<TagDataLogic>(() => { return new TagDataLogic(); });

        public static void AddQueryTag(long queryId,string tagName)
        {
            QueryTagDataLogic.Value.Add(new QueryTag{
                QueryId = queryId,
                TagName = tagName,
                AddTime = DateTime.Now
            });
            
            TagDataLogic.Value.UpdateCountUp(tagName);
        }

        public static void DeleteQueryTag(long queryId,string tagName)
        {
            QueryTagDataLogic.Value.Delete(queryId, tagName);
            TagDataLogic.Value.UpdateCountDown(tagName);
        }


    }
}
