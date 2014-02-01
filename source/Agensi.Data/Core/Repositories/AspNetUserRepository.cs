using Agensi.Data.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.Repositories
{
    public class AspNetUserRepository : IAspNetUserRepository
    {
        private AgensiDBEntities context;

        public AspNetUserRepository()
        {
            context = new AgensiDBEntities();
        }


        public AspNetUser Find(string userId)
        {
            return context.AspNetUsers.Find(userId);
        }

        public void UpdateName(string userId, string name)
        {
            var row = context.AspNetUsers.Find(userId);
            row.UserName = name;
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
