using Agensi.Data.Core;
using Agensi.Data.Core.IRepositories;
using Agensi.Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.DataLogic.Core
{
    public class UserProfileDataLogic
    {
        private IUserProfileRepository _repository;

        public UserProfileDataLogic() : this(new UserProfileRepository()) { }

        public UserProfileDataLogic(IUserProfileRepository repository)
        {
            _repository = repository;
        }

        public UserProfile Find(string userId)
        {
            return _repository.Find(userId);
        }

        public void Add(UserProfile userProfile)
        {
            _repository.Add(userProfile);
            _repository.Save();
        }

        public void Delete(string userId)
        {
            _repository.Delete(userId);
            _repository.Save();
        }

        public void Update(UserProfile userProfile)
        {
            _repository.Update(userProfile);
            _repository.Save();
        }
    }
}
