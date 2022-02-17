using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL.Relation_DAL;

namespace BLL
{
    public class Blog_BLL
    {
        Blog_DAL db = new Blog_DAL();
        public bool Create(Blog b)
        {
            return db.Create(b);
        }
        public Blog ReadByID(int id)
        {
            return db.ReadByID(id);
        }
        public bool Edit(int id,Blog b)
        {
            return db.Edit(id,b);
        }
        public bool Delete(int id)
        {
            return db.Delete(id);
        }
        public int GetTotal()
        {
            return db.GetTotal();
        }
        public List<Blog> ReadAll(int c)
        {
            return db.ReadAll(c);
        }

        public List<Blog> LastBlogs()
        {
            return db.LastBlogs();
        }
    }
}
