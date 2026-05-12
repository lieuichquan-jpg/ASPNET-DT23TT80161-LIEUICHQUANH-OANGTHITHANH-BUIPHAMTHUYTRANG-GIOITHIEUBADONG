using BaDongTourism.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaDongTourism.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var latestPosts = await _context.Posts
                .Include(p => p.Category)
                .OrderByDescending(p => p.CreatedAt)
                .Take(3)
                .ToListAsync();

            return View(latestPosts);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
