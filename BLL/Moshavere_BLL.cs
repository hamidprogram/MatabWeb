using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL.Relation_DAL;

namespace BLL
{
    public class Moshavere_BLL
    {
        Moshavere_DAL dal = new Moshavere_DAL();
        public bool Create(Moshavere m)
        {
            return dal.Create(m);
        }
        public Moshavere ReadByID(int id)
        {
            return dal.ReadByID(id);
        }
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }
        public bool Edit(int id,Moshavere m)
        {
            return dal.Edit(id,m);
        }
        public int GetTotal()
        {
            return dal.GetTotal();
        }
        public List<Moshavere> ReadAll(int c)
        {
            return dal.ReadAll(c);
        }
    }
}
