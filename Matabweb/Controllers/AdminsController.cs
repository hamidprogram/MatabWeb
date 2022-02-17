using Microsoft.AspNetCore.Mvc;
using BE;
using BLL;

namespace Matabweb.Controllers
{
    public class AdminsController : Controller
    {
        private IWebHostEnvironment env;
        public AdminsController(IWebHostEnvironment webHostEnvironment)
        {
            env = webHostEnvironment;
        }
        Blog_BLL bll = new Blog_BLL();
        Moshavere_BLL blm = new Moshavere_BLL();
        Users_BLL blu = new Users_BLL();
        Customer_BLL blc = new Customer_BLL();
        Nobat_BLL bln = new Nobat_BLL();

        //[Route("admins/index/{IsRegister}")]
        public IActionResult Index(bool IsRegister)
        {
            if (IsRegister == true)
            {
                ViewBag.Blogs = bll.GetTotal();
                ViewBag.Customers = blc.GetTotal();
                ViewBag.Nobats = bln.GetTotal();
                ViewBag.Moshaveres = blm.GetTotal();
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admins");
            }
        }

        public IActionResult Create()
        {
            return View("Blogs/Create");
        }

        [HttpPost]
        public ActionResult Create(Models.Blog blog)
        {
            UploadFile upf = new UploadFile(env);
            BE.Blog b = new Blog();
            b.NameBlgo = blog.NameBlgo;
            b.Text = blog.Text;
            b.ShortExp = blog.ShortExp;
            b.Photo = upf.Upload(blog.Photo);
            b.Tags = blog.Tags;
            b.Deate = DateTime.Now.ToString("yyyy/dd/MM");
            b.Time = DateTime.Now.ToString("H:mm");
            if (bll.Create(b) == true)
            {
                return RedirectToAction("Blogs", "Admins");
            }
            else
            {
                ViewBag.result = false;
                return View();
            }

            return View();
        }

        public ActionResult Blogs(int pageid)
        {
            ViewBag.PageID = pageid;
            return View("Blogs/Blogs", bll.ReadAll(pageid));
        }

        [Route("admins/detali/{id}")]
        public IActionResult Detali(int id)
        {
            return View("Blogs/Detail", bll.ReadByID(id));
        }

        public IActionResult Edit(int id)
        {
            return View("Blogs/Edit", bll.ReadByID(id));
        }

        [HttpPost]
        public ActionResult Edit(Models.Blog blog, int id)
        {
            Blog be = new Blog();
            UploadFile upf = new UploadFile(env);
            be.ID = blog.ID;
            be.NameBlgo = blog.NameBlgo;
            be.ShortExp = blog.ShortExp;
            be.Text = blog.Text;
            be.Photo = upf.Upload(blog.Photo);
            be.Tags = blog.Tags;
            be.Deate = DateTime.Now.ToString("yyyy/dd/MM" + "تاریخ ویرایش");
            be.Time = DateTime.Now.ToString("H:mm" + "زمان ویرایش");
            if (bll.Edit(id, be) == true)
            {
                int idd = id;
                return RedirectToAction("Detali", "Admins", new { id = idd });
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (bll.Delete(id) == true)
            {
                return RedirectToAction("Blogs", "Admins");
            }
            return View();
        }

        public IActionResult Moshaveres(int pageid)
        {
            ViewBag.PageID = pageid;
            return View("Moshaveres/Moshaveres", blm.ReadAll(pageid));
        }

        public IActionResult DetailM(int id)
        {
            Moshavere m = new Moshavere();
            m = blm.ReadByID(id);
            m.Condition = true;
            if (blm.Edit(id, m) == true)
            {
                return View("Moshaveres/Detail", m);
            }
            else
            {
                return View();
            }
        }
        public IActionResult DetailM2(int id)
        {
            return View("Moshaveres/Detail", blm.ReadByID(id));
        }

        public ActionResult DeleteM(int id)
        {
            if (blm.Delete(id) == true)
            {
                return RedirectToAction("Moshaveres", "Admins");
            }
            return View();
        }

        public IActionResult Users()
        {
            return View("Users/Users", blu.ReadAll());
        }

        public IActionResult DetailUsers(int id, bool IsAdd = false)
        {
            if (IsAdd == false)
            {
                return View("Users/Detali", blu.ReadByID(id));
            }
            else
            {
                ViewBag.Result = true;
                return View("Users/Detali", blu.ReadByID(id));
            }
        }

        public IActionResult CreateUsers()
        {
            return View("Users/Create");
        }

        [HttpPost]
        public ActionResult CreateUsers(User u)
        {
            if (blu.Create(u) == true)
            {
                return RedirectToAction("Users", "Admins");
            }
            else
            {
                return View();
            }
        }

        public ActionResult DeleteUsers(int id)
        {
            if (blu.GetTotal() > 1)
            {
                if (blu.Delete(id) == true)
                {
                    return RedirectToAction("Users", "Admins");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("DetailUsers", "Admins", new { IsAdd = true, id = id });
            }

        }

        public IActionResult EditUsers(int id)
        {
            return View("Users/Edit", blu.ReadByID(id));
        }

        [HttpPost]
        public ActionResult EditUsers(int id, User u)
        {
            if (blu.Edit(id, u) == true)
            {
                return RedirectToAction("Users", "Admins");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Login(bool IsAdd = false)
        {
            ViewBag.Result = IsAdd;
            return View("Register/Login");
        }

        [HttpPost]
        public ActionResult Login(User u)
        {
            if (blu.Register(u) == true)
            {
                return RedirectToAction("Index", "Admins", new { IsRegister = true });
            }
            else
            {
                return RedirectToAction("Login", "Admins", new { IsAdd = true });
            }
        }

        public IActionResult Customers(int pageid)
        {
            ViewBag.PageID = pageid;
            return View("Customers/Customers", blc.ReadAll(pageid));
        }

        public IActionResult DetailCustomer(int id)
        {
            return View("Customers/Details", blc.ReadByID(id));
        }

        public ActionResult DeleteCustomer(int id)
        {
            if (blc.Delete(id) == true)
            {
                return RedirectToAction("Customers", "Admins");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Nobats(int pageid)
        {
            ViewBag.PageID = pageid;
            return View("Nobats/Nobats", bln.ReadAll(pageid));
        }

        public IActionResult DetailNobat(int id)
        {
            return View("Nobats/Details", bln.ReadByID(id));
        }

        public ActionResult BackToNobat(int Id)
        {
            Nobat n = bln.ReadByID(Id);
            n.Condition = true;
            bln.EditCon(Id, n);
            return RedirectToAction("DetailNobat", "Admins", new { id = Id });
        }

        public ActionResult DeleteNobat(int id)
        {
            if (bln.Delete(id) == true)
            {
                return RedirectToAction("Nobats", "Admins");
            }
            else
            {
                return View();
            }
        }
    }
}
