using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using B03.EE.BlanckeK.Web.Models;

namespace B03.EE.BlanckeK.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
