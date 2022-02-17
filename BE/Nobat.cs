using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nobat
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public string Deate { get; set; }
        public string Time { get; set; }
        public bool Condition { get; set; }
    }
}
