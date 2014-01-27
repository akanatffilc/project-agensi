using Agensi.Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.Category
{
    public static class GenreManager
    {
        private static Genre[] _allGenre;
        public static Genre[] AllGenre
        {
            get
            {
                if (_allGenre != null)
                    return _allGenre;

                _allGenre = Enum.GetValues(typeof(AgensiEnums.Genre))
                .Cast<AgensiEnums.Genre>()
                .Where(x => x != AgensiEnums.Genre.Unknown)
                .Select(x => new Genre(x)).ToArray();

                return _allGenre;
            }

        }


        public static Genre[] DistinctClass(this IEnumerable<Genre> source)
        {
            var list = new List<Genre>();
            foreach (var genre in source)
            {
                if (list.Select(x => x.GenreId).Contains(genre.GenreId))
                    continue;
                else
                    list.Add(genre);
            }
            return list.ToArray();
        }

        public static Genre[] ConvertToGenre(long genreSource)
        {
            if (genreSource == (long)AgensiEnums.Genre.Unknown)
                return new Genre[1] { new Genre(AgensiEnums.Genre.Unknown) };

            return AllGenre
                .Where(x => (genreSource & x.GenreId) == x.GenreId)
                .ToArray();
        }
    }
}
