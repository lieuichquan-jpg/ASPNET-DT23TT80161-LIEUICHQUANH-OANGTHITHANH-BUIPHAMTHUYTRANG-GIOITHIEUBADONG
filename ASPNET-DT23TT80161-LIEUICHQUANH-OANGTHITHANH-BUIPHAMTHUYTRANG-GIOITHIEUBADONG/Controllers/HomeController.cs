using ASPNET_DT23TT80161_LIEUICHQUANH_OANGTHITHANH_BUIPHAMTHUYTRANG_GIOITHIEUBADONG.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPNET_DT23TT80161_LIEUICHQUANH_OANGTHITHANH_BUIPHAMTHUYTRANG_GIOITHIEUBADONG.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
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
    }
}
