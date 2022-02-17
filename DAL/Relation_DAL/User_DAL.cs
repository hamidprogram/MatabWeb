using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL.Relation_DAL
{
    public class User_DAL
    {
        DB db = new DB();
        public bool Create(User u)
        {
            db.users.Add(u);
            db.SaveChanges();
            return true;
        }

        public List<User> ReadAll()
        {
            return db.users.ToList();
        }

        public User ReadByID(int id)
        {
            return db.users.Where(i => i.ID == id).Single();
        }

        public bool Delete(int id)
        {
            User u = ReadByID(id);
            db.users.Remove(u);
            db.SaveChanges();
            return true;
        }

        public bool Edit(int id,User u)
        {
            User us = new User();
            us = ReadByID(id);
            us.UserName = u.UserName;
            us.Password = u.Password;
            db.SaveChanges();
            return true;
        }

        public int GetTotal()
        {
            return db.users.Count();
        }

        public bool Register(User u)
        {
            if(db.users.Any(i=>i.UserName == u.UserName && i.Password == u.Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
