using Agensi.Data.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.Repositories
{
    public class LanguageMasterRepository : ILanguageMasterRepository
    {
        private AgensiDBEntities context;

        public LanguageMasterRepository()
        {
            context = new AgensiDBEntities();
        }

        public LanguageMaster Find(int languageId)
        {
            return context.LanguageMasters.Find(languageId);
        }

        public LanguageMaster[] FindAll()
        {
            return context.LanguageMasters.ToArray<LanguageMaster>();
        }

        public void Insert(LanguageMaster user)
        {
            context.LanguageMasters.Add(user);
        }

        public void Update(LanguageMaster user)
        {
            context.LanguageMasters.Attach(user);
            context.Entry<LanguageMaster>(user).State = EntityState.Modified;
        }

        public void Delete(LanguageMaster user)
        {
            context.LanguageMasters.Attach(user);
            context.LanguageMasters.Remove(user);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}