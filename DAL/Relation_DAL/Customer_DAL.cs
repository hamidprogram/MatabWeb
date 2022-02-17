using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL.Relation_DAL
{
    public class Customer_DAL
    {
        DB db = new DB();
        public bool Create(Customer c)
        {
            if (IsOrNo(c) == false)
            {
                db.customers.Add(c);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsOrNo(Customer c)
        {
            return db.customers.Any(i => i.PhoneNumber == c.PhoneNumber);
        }

        public bool IsOrNo2(Customer c)
        {
            return db.customers.Any(i => i.Name == c.Name && i.PhoneNumber == c.PhoneNumber);
        }

        public Customer ReadByID(int id)
        {
            return db.customers.Where(i => i.ID == id).Single();
        }

        public bool Edit(int id, Customer c)
        {
            if (IsOrNo2(c) == false)
            {
                Customer us = new Customer();
                us = ReadByID(id);
                us.Name = c.Name;
                us.PhoneNumber = c.PhoneNumber;
                us.Password = c.Password;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            Customer u = ReadByID(id);
            db.customers.Remove(u);
            db.SaveChanges();
            return true;
        }

        public int GetTotal()
        {
            return db.customers.Count();
        }

        public List<Customer> ReadAll(int c)
        {
            int t = c * 10;
            var lst = db.customers.ToList().Skip(t).Take(10);
            return lst.ToList();
        }

        public bool Register(Customer u)
        {
            if (db.customers.Any(i => i.PhoneNumber == u.PhoneNumber && i.Password == u.Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Customer FindID(Customer c)
        {
            return db.customers.Where(i => i.Password == c.Password && i.PhoneNumber == c.PhoneNumber).Single();
        }
    }
}
