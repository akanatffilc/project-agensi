using Agensi.Data.Core;
using Agensi.Data.Core.IRepositories;
using Agensi.Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.Logics.Core
{
    public class LanguageMasterLogic
    {
        private ILanguageMasterRepository _languageMasterRepository;

        public LanguageMasterLogic() : this(new LanguageMasterRepository()) { }

        public LanguageMasterLogic(ILanguageMasterRepository languageMasterRepository) 
        {
            _languageMasterRepository = languageMasterRepository;
        }

        public LanguageMaster Find(int languageId)
        {
            return _languageMasterRepository.Find(languageId);
        }

        public LanguageMaster[] FindAll()
        {
            return _languageMasterRepository.FindAll();
        }


        //public void Insert(LanguageMaster source)
        //{
        //    _languageMasterRepository.Insert(source);
        //    _languageMasterRepository.Save();
        //}

        //public void Update(LanguageMaster source)
        //{
        //    _languageMasterRepository.Update(source);
        //    _languageMasterRepository.Save();
        //}

        //public void Delete(LanguageMaster user)
        //{
        //    _languageMasterRepository.Delete(source);
        //    _languageMasterRepository.Save();
        //}
    }
}
