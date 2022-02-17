using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Microsoft.Data.SqlClient;
using System.Globalization;

namespace DAL.Relation_DAL
{
    public class Nobat_DAL
    {
        DB db = new DB();
        Customer_DAL cus = new Customer_DAL();
        public bool Create(Nobat n)
        {
            if (IsOrNo(n) == true)
            {
                return false;
            }
            else
            {
                db.nobats.Add(n);
                db.SaveChanges();
                return true;
            }
        }

        public bool IsOrNo(Nobat n)
        {
            return db.nobats.Any(i => i.Deate == n.Deate && i.Time == n.Time);
        }

        public Nobat ReadByID(int id)
        {
            return db.nobats.Where(i => i.ID == id).Single();
        }

        public int GetTotal()
        {
            return db.nobats.Count();
        }

        public List<Nobat> ReadAll(int c)
        {
            int t = c * 10;
            var lst = db.nobats.ToList().Skip(t).Take(10);
            return lst.ToList();
        }

        public bool Delete(int id)
        {
            Nobat b = ReadByID(id);
            db.nobats.Remove(b);
            db.SaveChanges();
            return true;
        }

        public bool Edit(int id, Nobat u)
        {
            if (IsOrNo(u) == true)
            {
                return false;
            }
            else
            {
                Nobat us = new Nobat();
                us = ReadByID(id);
                us.Deate = u.Deate;
                us.Time = u.Time;
                us.Condition = u.Condition;
                db.SaveChanges();
                return true;
            }
        }

        public int GetTotalCustomer(int CustomerID)
        {
            return db.nobats.Where(i => i.CustomerID == CustomerID).Count();
        }

        public List<Nobat> ReadByCustomerID(int CustomerID,int c)
        {
            int t = c * 10;
            var lst = db.nobats.Where(i => i.CustomerID == CustomerID).ToList().Skip(t).Take(10);
            return lst.ToList();
        }

        public List<string> deate()
        {
            List<string> deate = new List<string>();
            PersianCalendar pc = new PersianCalendar();
            int day = Convert.ToInt32(pc.GetDayOfMonth(DateTime.Now));
            int month = Convert.ToInt32(pc.GetMonth(DateTime.Now));
            int yer = Convert.ToInt32(pc.GetYear(DateTime.Now));
            string deat = yer.ToString() + "/" + month.ToString() + "/" + day.ToString();
            deate.Add(deat);
            for (int i = 1; i < 7; i++)
            {
                day++;
                if(day > 30)
                {
                    day = 1;
                    month++;
                    if(month > 12)
                    {
                        yer++;
                    }
                }
                string deat1 = yer.ToString() + "/" + month.ToString() + "/" + day.ToString();
                deate.Add(deat1);
            }
            return deate.ToList();
        }

        public void EditCon(int id,Nobat u)
        {
            Nobat us = new Nobat();
            us = ReadByID(id);
            us.Deate = u.Deate;
            us.Time = u.Time;
            us.Condition = u.Condition;
            db.SaveChanges();
        }
    }
}
