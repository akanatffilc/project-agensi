using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.IRepositories
{
    public interface ILanguageMasterRepository
    {
        LanguageMaster Find(int languageId);

        LanguageMaster[] FindAll();

        int Save();
    }
}
