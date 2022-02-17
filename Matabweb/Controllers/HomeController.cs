using Matabweb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BE;
using BLL;

namespace Matabweb.Controllers
{
    public class HomeController : Controller
    {
        Moshavere_BLL bll = new Moshavere_BLL();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index(bool IsAdd = false)
        {
            if (IsAdd == true)
            {
                ViewBag.result = true;
                return View();

            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult Create(Moshavere moshavere)
        {
            moshavere.Condition = false;
            if (bll.Create(moshavere) == true)
            {
                return RedirectToAction("Index", "Home", new { IsAdd = true });
            }
            else
            {
                ViewBag.result = false;
                return View();
            }

            return View();
        }
    }
}