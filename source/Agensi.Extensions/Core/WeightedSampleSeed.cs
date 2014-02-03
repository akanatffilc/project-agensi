using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Extensions.Core
{

    public class WeightedSampleSeed<T>
    {
        public int ItemCount { get; private set; }

        private readonly int _totalWeight;
        private readonly List<T> _items;
        private readonly List<int> _weightBounds;

        public WeightedSampleSeed(IEnumerable<T> source, Func<T, int> weightSelector)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (weightSelector == null)
                throw new ArgumentNullException("weightSelector");

            var enumerable = source as T[] ?? source.ToArray();
            if (!enumerable.Any())
                throw new ArgumentException("source is empty");

            var items = new List<T>();
            var weightBounds = new List<int>();
            var totalWeight = 0;

            foreach (var x in enumerable)
            {
                var weight = weightSelector(x);
                if (weight <= 0)
                    continue;

                checked
                {
                    totalWeight += weight;
                }

                items.Add(x);
                weightBounds.Add(totalWeight);

                _totalWeight = totalWeight;
                ItemCount = items.Count;
                _items = items;
                _weightBounds = weightBounds;
            }
        }

        public T Sample()
        {
            var draw = RandomProvider.Random.Next(1, _totalWeight + 1);
            var index = _weightBounds.BinarySearch(draw);

            if (index < 0)
                index = ~index;

            return _items[index];
        }
    }
}
