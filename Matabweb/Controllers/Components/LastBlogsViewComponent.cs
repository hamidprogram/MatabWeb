using Microsoft.AspNetCore.Mvc;
using BE;
using BLL;

namespace Matabweb.Controllers.Components
{
    public class LastBlogsViewComponent : ViewComponent
    {
        Blog_BLL bll = new Blog_BLL();
        public IViewComponentResult Invoke()
        {
            return View("_LastBlogs",bll.LastBlogs());
        }
    }
}
