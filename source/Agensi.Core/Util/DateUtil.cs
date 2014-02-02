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
            if(now > fromToDate)
            {
                var timeSpan = now - fromToDate;
                return string.Format("{0}前", timeSpan);
            }
            else
            {
                var timeSpan = fromToDate - now;
                return string.Format("{0}後", timeSpan);
            }
        }
    }
}
