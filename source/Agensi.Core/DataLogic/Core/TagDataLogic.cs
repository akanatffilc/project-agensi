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
    public class TagDataLogic
    {
        private ITagRepository _repository;

        internal TagDataLogic() : this(new TagRepository()) { }

        internal TagDataLogic(ITagRepository repository) 
        {
            _repository = repository;
        }

        public Tag Find(string tagName)
        {
            return _repository.Find(tagName);
        }

        public void UpdateCountUp(string tagName)
        {
            _repository.UpdateCountUp(tagName);
            _repository.Save();
        }

        public void UpdateCountDown(string tagName)
        {
            _repository.UpdateCountDown(tagName);
            _repository.Save();
        }
    }
}
