using Microsoft.AspNetCore.Mvc;
using BE;
using BLL;

namespace Matabweb.Controllers
{
    public class NobatController : Controller
    {
        Nobat_BLL bll = new Nobat_BLL();
        Random random = new Random();

        public IActionResult Index(int id,int numk, bool IsRegister, int pageid)
        {
            int cusid = id - (numk*2);
            if (IsRegister == true)
            {
                ViewBag.PageID = pageid;
                ViewBag.CustomerID = cusid;
                return View(bll.ReadByCustomerID(cusid, pageid));
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public IActionResult Detail(int id, bool Condtaion, int customerid)
        {
            ViewBag.con = Condtaion;
            ViewBag.customerId = customerid;
            return View("Detail", bll.ReadByID(id));
        }

        public IActionResult Create(int customerid, bool IsAdd = false)
        {
            ViewBag.Customerid = customerid;
            ViewBag.IsAdd = IsAdd;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Nobat n, int customerid)
        {
            int ra = random.Next(1000,5000);
            if(ra%2 != 0)
            {
                ra++;
            }
            int numk = customerid + ra;
            int ram = ra / 2;
            n.CustomerID = customerid;
            n.Condition = false;
            if (bll.Create(n) == true)
            {
                return RedirectToAction("Index", "Nobat", new { id = numk, numk = ram, IsRegister = true });
            }
            else
            {
                return RedirectToAction("Create", "Nobat", new { IsAdd = true });
            }
        }

        public ActionResult Delete(int id, int customerid)
        {
            int ra = random.Next(1000, 5000);
            if (ra % 2 != 0)
            {
                ra++;
            }
            int numk = customerid + ra;
            int ram = ra / 2;
            if (bll.Delete(id) == true)
            {
                return RedirectToAction("Index", "Nobat", new { id = numk, numk = ram, IsRegister = true });
            }
            else
            {
                return View();
            }
        }

        public IActionResult Edit(int id, int customerid, bool IsAdd = false)
        {
            ViewBag.id = id;
            ViewBag.IsAdd = IsAdd;
            ViewBag.customerid = customerid;
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Edit(int Id, Nobat n, int customerid)
        {
            if (bll.Edit(Id, n) == true)
            {
                return RedirectToAction("Detail", "Nobat", new { id = Id, Condtaion = false, customerid = customerid });
            }
            else
            {
                return RedirectToAction("Edit", "Nobat", new { id = Id, customerid = customerid, IsAdd = true });
            }
        }
    }
}
