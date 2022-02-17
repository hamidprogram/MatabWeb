using Microsoft.AspNetCore.Mvc;

namespace Matabweb.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/404")]
        public IActionResult Index()
        {
            return View("Error404");
        }
    }
}
