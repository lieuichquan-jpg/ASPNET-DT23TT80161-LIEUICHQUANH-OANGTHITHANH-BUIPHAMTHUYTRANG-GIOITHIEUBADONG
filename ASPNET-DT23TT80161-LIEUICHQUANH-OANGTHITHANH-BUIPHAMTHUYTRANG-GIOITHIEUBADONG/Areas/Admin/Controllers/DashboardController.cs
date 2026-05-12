using BaDongTourism.Data;
using Microsoft.AspNetCore.Mvc;

namespace BaDongTourism.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminUser") == null)
            {
                return RedirectToAction("Login", "Account", new { area = "Admin" });
            }

            ViewBag.TotalPosts = _context.Posts.Count();
            ViewBag.TotalCategories = _context.Categories.Count();
            ViewBag.TotalContacts = _context.Contacts.Count();

            return View();
        }
    }
}