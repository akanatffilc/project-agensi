using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agensi.Extensions.Core
{
    public static class RandomProvider
    {
        private static readonly ThreadLocal<Random> ThreadLocalRandom = new ThreadLocal<Random>(() =>
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var buffer = new byte[sizeof(int)];
                rng.GetBytes(buffer);
                var seed = BitConverter.ToInt32(buffer, 0);
                return new Random(seed);
            }
        });

        public static Random Random
        {
            get
            {
                return ThreadLocalRandom.Value;
            }
        }

        public static int RandomNumberOf1To100
        {
            get { return Random.Next(1, 101); }
        }

    }
}
