using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL.Relation_DAL;

namespace BLL
{
    public class Customer_BLL
    {
        Customer_DAL db = new Customer_DAL();
        public bool Create(Customer c)
        {
                return db.Create(c);
        }

        public bool IsOrNo(Customer c)
        {
            return db.IsOrNo(c);
        }

        public Customer ReadByID(int id)
        {
            return db.ReadByID(id);
        }

        public bool Edit(int id, Customer c)
        {
                return db.Edit(id,c);
        }

        public bool Delete(int id)
        {
            return db.Delete(id);
        }

        public int GetTotal()
        {
            return db.GetTotal();
        }

        public List<Customer> ReadAll(int c)
        {
            return db.ReadAll(c);
        }

        public bool Register(Customer u)
        {
                return db.Register(u);
        }

        public Customer FindID(Customer c)
        {
            return db.FindID(c);
        }
    }
}
