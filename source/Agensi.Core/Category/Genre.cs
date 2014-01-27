using Agensi.Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.Category
{
    public class Genre
    {

        public Genre(long genreId)
        {
            AgensiEnums.Genre genre;
            if (!Enum.TryParse<AgensiEnums.Genre>(genreId.ToString(), out genre))
                genre = AgensiEnums.Genre.Unknown;

            GenreId = (long)genre;
            Name = genre.ToString();
        }

        public Genre(AgensiEnums.Genre genre)
        {
            GenreId = (long)genre;
            Name = genre.ToString();
        }

        public long GenreId { get; private set; }

        public string Name { get; private set; }
    }
}
