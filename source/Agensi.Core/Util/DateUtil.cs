using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.Util
{
    public class DateUtil
    {
        public static string FormatDate(DateTime now, DateTime fromToDate)
        {
            var timeDiffString = "";
            var timeDiff = now - fromToDate;
            var seconds = (int)timeDiff.TotalSeconds;
            if (seconds < 60)
            {
                timeDiffString = string.Format("{0}秒前", seconds);
            }
            else if (seconds < 60 * 60)
            {
                timeDiffString = string.Format("{0}分前", (int)Math.Ceiling(seconds / 60.0));
            }
            else if (seconds < 60 * 60 * 24 * 7)
            {
                timeDiffString = string.Format("{0}日前", (int)Math.Ceiling(seconds / (60.0 * 60.0 * 24)));
            }
            else
            {
                timeDiffString = string.Format(@"{0: M/d H\:mm}", fromToDate);
            }

            return timeDiffString;
        }
    }
}
