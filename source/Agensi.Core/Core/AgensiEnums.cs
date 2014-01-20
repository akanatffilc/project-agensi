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
        public enum Language
        {
            Unknown = 1,
            Japanese = 2,
            English = 4,
            Chinese = 8,
        }

        public enum Genre
        {
            Unknown = 1,
            IT = 2,
            Food = 4,
        }

        public enum MediaCategory
        {
            Unknown = 1,
            Text = 2,
            Video = 3,
        }
    }
}
