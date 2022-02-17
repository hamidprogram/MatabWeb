using Microsoft.AspNetCore.Mvc;
using BE;
using BLL;

namespace Matabweb.Controllers.Components
{
    public class LastBlogsIndexViewComponent : ViewComponent
    {
        Blog_BLL bll = new Blog_BLL();
        public IViewComponentResult Invoke()
        {
            return View("_LastBlogsIndex", bll.LastBlogs());
        }
    }
}
