using Agensi.Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.Category
{
    public static class MediaCategoryManager
    {
        private static MediaCategory[] _allMediaCategory;

        public static MediaCategory[] AllMediaCategory
        {
            get
            {
                if (_allMediaCategory != null)
                    return _allMediaCategory;

                _allMediaCategory = Enum.GetValues(typeof(AgensiEnums.MediaCategory))
                    .Cast<AgensiEnums.MediaCategory>()
                    .Where(x => x != AgensiEnums.MediaCategory.Unknown)
                    .Select(x => new MediaCategory(x)).ToArray();

                return _allMediaCategory;
            }
        }


        public static MediaCategory[] DistinctClass(this IEnumerable<MediaCategory> source)
        {
            var list = new List<MediaCategory>();
            foreach (var mediaCategory in source)
            {
                if (list.Select(x => x.MediaCategoryId).Contains(mediaCategory.MediaCategoryId))
                    continue;
                else
                    list.Add(mediaCategory);
            }
            return list.ToArray();
        }

        public static MediaCategory[] ConvertToMediaCateory(long mediaCateogrySource)
        {
            if (mediaCateogrySource == (long)AgensiEnums.MediaCategory.Unknown)
                return new MediaCategory[1] { new MediaCategory(AgensiEnums.MediaCategory.Unknown) };

            return AllMediaCategory
                .Where(x => (mediaCateogrySource & x.MediaCategoryId) == x.MediaCategoryId)
                .ToArray();
        }
    }
}
