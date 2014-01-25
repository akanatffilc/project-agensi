using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.Util
{
    public static class StringUtil
    {
        /// <summary>
        /// nullかdefault値ならstring.Emptyを返す。それ以外ならToString()で返す。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ValueOrStringEmpty<T>(T source)
        {
            // ReSharper disable once CompareNonConstrainedGenericWithNull
            if (source != null && !source.Equals(default(T)))
                return source.ToString();
            return string.Empty;
        }


        /// <summary>
        /// 文字列のハッシュ(SHA1)を計算して16進数文字列にする
        /// </summary>
        public static string ComputeSHA1(string inputString, Encoding enc)
        {
            var jsonData = enc.GetBytes(inputString);
            var sha1 = new SHA1CryptoServiceProvider();
            var hashValue = sha1.ComputeHash(jsonData);

            var hashedText = new StringBuilder();
            hashValue.ToList().ForEach(x => hashedText.AppendFormat("{0:X2}", x));
            var hashedString = hashedText.ToString();
            return hashedString;
        }


        /// <summary>
        /// MD5ハッシュ値を計算する
        /// </summary>
        /// <param name="value"></param>
        /// <param name="enc"></param>
        /// <returns></returns>
        public static string ComputeMD5Hash(string value, Encoding enc)
        {
            //文字列をバイト型配列に変換する
            var data = enc.GetBytes(value);
            //ハッシュ値を計算
            var bs = MD5.Create().ComputeHash(data);
            //byte型配列を16進数の文字列に変換
            return BitConverter.ToString(bs).ToLower().Replace("-", "");
        }
    }
}
