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
    public class AspNetUserDataLogic
    {
        private IAspNetUserRepository _repository;

        public AspNetUserDataLogic() : this(new AspNetUserRepository()) { }

        public AspNetUserDataLogic(IAspNetUserRepository repository)
        {
            _repository = repository;
        }

        public AspNetUser Find(string userId)
        {
            return _repository.Find(userId);
        }

        public void UpdateName(string userId,string name)
        {
            _repository.UpdateName(userId, name);
            _repository.Save();
        }

    }
}
