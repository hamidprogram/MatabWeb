using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL.Relation_DAL
{
    public class Moshavere_DAL
    {
        DB db = new DB();
        public bool Create(Moshavere m)
        {
            db.moshaveres.Add(m);
            db.SaveChanges();
            return true;
        }
        public List<Moshavere> ReadAll(int c)
        {
            int t = c * 10;
            var list = db.moshaveres.ToList().Skip(t).Take(10);
            return list.ToList();
        }
        public Moshavere ReadByID(int id)
        {
            return db.moshaveres.Where(i => i.ID == id).Single();
        }
        public int GetTotal()
        {
            return db.blogs.Count();
        }
        public bool Edit(int id,Moshavere m)
        {
            Moshavere mo = new Moshavere();
            mo = ReadByID(id);
            mo.FullName = m.FullName;
            mo.PhoneNumber = m.PhoneNumber;
            mo.Subject = m.Subject;
            mo.Descreption = m.Descreption;
            mo.Condition = m.Condition;
            db.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            Moshavere m = ReadByID(id);
            db.moshaveres.Remove(m);
            db.SaveChanges();
            return true;
        }
    }
}
