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
        public enum Language : long
        {
            Unknown = 0x0000000000000000,
            Japanese = 0x0000000000000001,
            English = 0x0000000000000002,
            Chinese = 0x0000000000000004,
        }

        [Flags]
        public enum Genre : long
        {
            Unknown = 0x0000000000000000,
            IT = 0x0000000000000001,
            Food = 0x0000000000000002,
        }

        [Flags]
        public enum MediaCategory : long
        {
            Unknown = 0x0000000000000000,
            Text = 0x0000000000000001,
            Video = 0x0000000000000002,
        }

        public enum CommentViewFlug
        {
            NonDisplay = 0,
            Display = 1,
        }
    }
}
