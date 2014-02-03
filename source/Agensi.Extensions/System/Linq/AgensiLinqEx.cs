using Agensi.Extensions.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class AgensiLinqEx
    {
        /// <summary>
        /// ページング対象シーケンスの最大要素数
        /// </summary>
        const int PaginateMaxElementCount = 1000;

        /// <summary>
        /// シーケンスをページングして返す
        /// </summary>
        /// <param name="source">対象となるシーケンス</param>
        /// <param name="pageSize">1ページに表示する要素数</param>
        /// <param name="currentPage">現在のページ数</param>
        /// <returns>ページングされたシーケンス</returns>
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source, int pageSize, int currentPage)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var enumerable = source as T[] ?? source.ToArray();
            if (enumerable.Count() > PaginateMaxElementCount)
                throw new ArgumentException(string.Format("ページング対象のシーケンスの要素数が{0}件を超えています。", PaginateMaxElementCount));

            return enumerable.Skip(pageSize * (currentPage - 1)).Take(pageSize);
        }

        /// <summary>
        /// WeightedSampleの復元抽選最大回数
        /// </summary>
        private const int WeightedSampleMaxLoopCount = 1000;

        /// <summary>
        /// シーケンスからweightSelectorで指定された重み付けで復元抽選を実施するためのWeightedSampleSeedを返す。
        /// </summary>
        public static WeightedSampleSeed<T> ToWeightedSampleSeed<T>(this IEnumerable<T> source, Func<T, int> weightSelector)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (weightSelector == null) throw new ArgumentNullException("weightSelector");

            return new WeightedSampleSeed<T>(source, weightSelector);
        }

        /// <summary>
        /// シーケンスからweightSelectorで指定された重み付けで復元抽選を実施し、当選した要素を返す。
        /// </summary>
        public static IEnumerable<T> WeightedSample<T>(WeightedSampleSeed<T> weightedSampleSeed)
        {
            if (weightedSampleSeed == null) throw new ArgumentNullException("weightedSampleSeed");

            return WeightedSampleCore(weightedSampleSeed);
        }

        /// <summary>
        /// シーケンスからweightSelectorで指定された重み付けで復元抽選を実施し、当選した要素を返す。
        /// </summary>
        public static IEnumerable<T> WeightedSample<T>(this IEnumerable<T> source, Func<T, int> weightSelector)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (weightSelector == null) throw new ArgumentNullException("weightSelector");

            return WeightedSampleCore(source, weightSelector);
        }

        static IEnumerable<T> WeightedSampleCore<T>(IEnumerable<T> source, Func<T, int> weightSelector)
        {
            var weightedSampleSeed = new WeightedSampleSeed<T>(source, weightSelector);
            return WeightedSampleCore(weightedSampleSeed);
        }

        static IEnumerable<T> WeightedSampleCore<T>(WeightedSampleSeed<T> weightedSampleSeed)
        {
            if (weightedSampleSeed.ItemCount == 0)
                yield break;

            var loopCounter = 0;
            while (true)
            {
                if (++loopCounter > WeightedSampleMaxLoopCount)
                    throw new InvalidOperationException(string.Format("[WeightedSample] 抽選回数が{0}回を超えています。", WeightedSampleMaxLoopCount));

                yield return weightedSampleSeed.Sample();
            }
        }
    }
}
