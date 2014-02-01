using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.IRepositories
{
    public interface IAspNetUserRepository
    {
        AspNetUser Find(string userId);

        void UpdateName(string userId,string name);

        int Save();
    }
}
