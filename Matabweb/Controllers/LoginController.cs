using Microsoft.AspNetCore.Mvc;
using BE;
using BLL;

namespace Matabweb.Controllers
{
    public class LoginController : Controller
    {
        Customer_BLL bll = new Customer_BLL();
        Random random = new Random();
        public IActionResult Login(bool IsAdd = false)
        {
            ViewBag.Result = IsAdd;
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(Customer u)
        {
            if (bll.Register(u) == true)
            {
                var a = bll.FindID(u);
                int ra = random.Next(1000, 5000);
                if (ra % 2 != 0)
                {
                    ra++;
                }
                int numk = a.ID + ra;
                int ram = ra / 2;
                return RedirectToAction("Index", "Nobat", new { id = numk, numk = ram, IsRegister = true });
            }
            else
            {
                return RedirectToAction("Login", "Login", new { IsAdd = true });
            }
        }
        public IActionResult Singup(bool IsAdd = false)
        {
            ViewBag.Result = IsAdd;
            return View("singup");
        }

        [HttpPost]
        public ActionResult Singup(Customer u)
        {
            if (bll.Create(u) == true)
            {
                var a = bll.FindID(u);
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return RedirectToAction("Singup", "Login", new { IsAdd = true });
            }
        }

        public IActionResult Detail(int customerid)
        {
            ViewBag.customerId = customerid;
            return View("Detail", bll.ReadByID(customerid));
        }

        public ActionResult Delete(int id)
        {
            if (bll.Delete(id) == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Edit(int id, bool IsAdd = false)
        {
            ViewBag.IsAdd = IsAdd;
            return View("Edit", bll.ReadByID(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Customer c)
        {
            if (bll.Edit(id, c) == true)
            {
                return RedirectToAction("Detail", "Login", new { customerid = id });
            }
            else
            {
                return RedirectToAction("Edit", "Login", new { id = id, IsAdd = true });
            }
        }
    }
}
