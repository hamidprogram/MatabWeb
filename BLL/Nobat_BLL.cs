using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL.Relation_DAL;

namespace BLL
{
    public class Nobat_BLL
    {
        Nobat_DAL db = new Nobat_DAL();

        public bool Create(Nobat n)
        {
            return db.Create(n);
        }

        public Nobat ReadByID(int id)
        {
            return db.ReadByID(id);
        }

        public int GetTotal()
        {
            return db.GetTotal();
        }

        public List<Nobat> ReadAll(int c)
        {
            return db.ReadAll(c);
        }

        public bool Delete(int id)
        {
            return db.Delete(id);
        }

        public bool Edit(int id, Nobat u)
        {
            return db.Edit(id, u);
        }

        public List<Nobat> ReadByCustomerID(int CustomerID, int c)
        {
            return db.ReadByCustomerID(CustomerID, c);
        }

        public int GetTotalCustomer(int CustomerID)
        {
            return db.GetTotalCustomer(CustomerID);
        }

        public List<string> deate()
        {
            return db.deate();
        }

        public void EditCon(int id, Nobat u)
        {
            db.EditCon(id, u);
        }
    }
}
