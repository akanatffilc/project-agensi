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
    public class UserStateDataLogic
    {
        private IUserStateRepository _repository;

        public UserStateDataLogic() : this(new UserStateRepository()) { }

        public UserStateDataLogic(IUserStateRepository repository)
        {
            _repository = repository;
        }

        public UserState Find(string userId)
        {
            return _repository.Find(userId);
        }

        public void Add(UserState userState)
        {
            _repository.Add(userState);
            _repository.Save();
        }

        public void Delete(string userId)
        {
            _repository.Delete(userId);
            _repository.Save();
        }

        public void Update(UserState userState)
        {
            _repository.Update(userState);
            _repository.Save();
        }
    }
}
