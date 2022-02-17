using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL.Relation_DAL
{
    public class Blog_DAL
    {
        DB db = new DB();
        public bool Create(Blog b)
        {
            db.blogs.Add(b);
            db.SaveChanges();
            return true;
        }
        public Blog ReadByID(int id)
        {
            return db.blogs.Where(i => i.ID == id).Single();
        }
        public bool Edit(int id, Blog b)
        {
            Blog blog = new Blog();
            blog = ReadByID(id);
            blog.NameBlgo = b.NameBlgo;
            blog.ShortExp = b.ShortExp;
            blog.Text = b.Text;
            blog.Photo = b.Photo;
            blog.Tags = b.Tags;
            blog.Deate = b.Deate;
            blog.Time = b.Time;
            db.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            Blog b = ReadByID(id);
            db.blogs.Remove(b);
            db.SaveChanges();
            return true;
        }
        public int GetTotal()
        {
            return db.blogs.Count();
        }
        public List<Blog> ReadAll(int c)
        {
            int t = c * 10;
            var list = db.blogs.ToList().Skip(t).Take(10);
            return list.ToList();
        }

        public List<Blog> LastBlogs()
        {
            return db.blogs.OrderByDescending(p => p.Deate).Take(3).ToList();
        }
    }
}
