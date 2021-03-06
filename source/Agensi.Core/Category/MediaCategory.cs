﻿using Agensi.Core.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.Category
{
    public class MediaCategory
    {

        public MediaCategory(int mediaCategoryId)
        {
            AgensiEnums.MediaCategory mediaCategory;
            if (!Enum.TryParse<AgensiEnums.MediaCategory>(mediaCategoryId.ToString(), out mediaCategory))
                mediaCategory = AgensiEnums.MediaCategory.Unknown;

            MediaCategoryId = (long)mediaCategory;
            Name = mediaCategory.ToString();
        }

        public MediaCategory(AgensiEnums.MediaCategory mediaCategory)
        {
            MediaCategoryId = (long)mediaCategory;
            Name = mediaCategory.ToString();
        }

        public long MediaCategoryId { get; private set; }

        public string Name { get; private set; }

    }
}
