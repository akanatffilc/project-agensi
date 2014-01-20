using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.Core
{
    public class AgensiEnums
    {
        [Flags]
        public enum LanguageCategory
        {
            Japanese = 1,
            English = 2,
            Chinese = 4,
        }

        public enum TopicCategory
        {
            IT = 1,
            Food = 2,
        }

        public enum MediaCategory
        {
            Text = 1,
            Video = 2,
        }
    }
}
