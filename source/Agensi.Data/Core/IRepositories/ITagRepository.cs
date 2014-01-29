using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.IRepositories
{
    public interface ITagRepository
    {
        Tag Find(string tagName);

        void UpdateCountUp(string tagName);

        void UpdateCountDown(string tagName);

        void Save();
    }
}
