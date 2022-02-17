using Microsoft.AspNetCore.Mvc;
using BE;
using BLL;

namespace Matabweb.Controllers
{
    public class BlogsController : Controller
    {
        Blog_BLL bll = new Blog_BLL();
        public IActionResult Blogs(int pageid)
        {
            ViewBag.PageID = pageid;
            return View("Blogs",bll.ReadAll(pageid));
        }

        public IActionResult SingleBlog(int id)
        {
            return View("SingleBlog",bll.ReadByID(id));
        }
    }
}
