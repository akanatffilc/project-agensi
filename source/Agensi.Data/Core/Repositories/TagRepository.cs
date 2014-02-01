using Agensi.Data.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.Repositories
{
    public class TagRepository : ITagRepository
    {
        private AgensiDBEntities context;

        public TagRepository()
        {
            context = new AgensiDBEntities();
        }


        public Tag Find(string tagName)
        {
            return context.Tags.Find(tagName);
        }

        public void UpdateCountUp(string tagName)
        {
            var row = context.Tags.Find(tagName);
            if (row == null)
                context.Tags.Add(new Tag
                {
                    TagName = tagName,
                    Count = 1,
                    AddTime = DateTime.Now,
                    UpdateTime = DateTime.Now
                });
            else
            {
                row.Count++;
                row.UpdateTime = DateTime.Now;
            }
        }

        public void UpdateCountDown(string tagName)
        {
            var row = context.Tags.Find(tagName);
            if (row == null) return;

            if (row.Count > 1)
            {
                row.Count--;
                row.UpdateTime = DateTime.Now;
            }
            else
                context.Tags.Remove(row);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

    }
}
