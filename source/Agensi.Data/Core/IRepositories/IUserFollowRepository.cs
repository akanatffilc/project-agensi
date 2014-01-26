using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.IRepositories
{
    public interface IUserFollowRepository
    {
        UserFollow[] FindByUserId(string userId);

        UserFollow[] FindByFollowUserId(string userId);

        void Add(UserFollow follow);

        void Delete(string userId,string followUserId);

        Task AddAsync(UserFollow follow);

        Task DeleteAsync(UserFollow follow);

        void Save();

        Task SaveAsync();
    }
}
