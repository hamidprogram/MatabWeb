using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL.Relation_DAL;

namespace BLL
{
    public class Users_BLL
    {
        User_DAL db = new User_DAL();
        public bool Create(User u)
        {
            return db.Create(u);
        }

        public List<User> ReadAll()
        {
            return db.ReadAll();
        }

        public User ReadByID(int id)
        {
            return db.ReadByID(id);
        }

        public bool Delete(int id)
        {
            return db.Delete(id);
        }

        public bool Edit(int id, User u)
        {
            return db.Edit(id,u);
        }

        public int GetTotal()
        {
            return db.GetTotal();
        }

        public bool Register(User u)
        {
            return db.Register(u);
        }
    }
}
