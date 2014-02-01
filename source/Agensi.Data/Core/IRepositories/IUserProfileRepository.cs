using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.IRepositories
{
    public interface IUserProfileRepository
    {
        UserProfile Find(string userId);

        void Add(UserProfile userProfile);

        void Update(UserProfile userProfile);

        void Delete(string userId);

        int Save();
    }
}
