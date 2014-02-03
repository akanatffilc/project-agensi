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

        /// <summary>
        /// N-gram方式で文字列の比較を行い、重複箇所の割合を求める
        /// </summary>
        /// <param name="strA"></param>
        /// <param name="strB"></param>
        /// <returns></returns>
        public static float Compare(string strA, string strB)
        {
            //デフォルトはBigram
            return Compare(2, strA, strB);
        }
        public static float Compare(int n, string strA, string strB)
        {
            // strAのN-gramリストを作成する
            var blist = new HashSet<string>();
            for (int i = 0; i < strA.Length - (n - 1); i++)
            {
                string ngitem = strA.Substring(i, n);
                if (!blist.Contains(ngitem)) { blist.Add(ngitem); }
            }
            //blist.Sort();

            // strBのN-gramリストとの一致を見る
            int found = 0;
            for (int i = 0; i < strB.Length - (n - 1); i++)
            {
                string ngitem = strB.Substring(i, n);
                if (blist.Contains(ngitem)) { found++; }
            }

            // 重複箇所の割合を返す
            return (float)found / blist.Count;
        }
    }
}
