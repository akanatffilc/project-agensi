using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.IRepositories
{
    public interface IUserStateRepository
    {
        UserState Find(string userId);

        void Add(UserState userProfile);

        void Update(UserState userProfile);

        void Delete(string userId);

        int Save();
    }
}
