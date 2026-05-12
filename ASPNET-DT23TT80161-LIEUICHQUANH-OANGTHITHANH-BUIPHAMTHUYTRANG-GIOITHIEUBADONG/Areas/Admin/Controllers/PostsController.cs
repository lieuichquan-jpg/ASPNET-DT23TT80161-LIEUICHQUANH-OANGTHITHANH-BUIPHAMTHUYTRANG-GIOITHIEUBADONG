using BaDongTourism.Data;
using BaDongTourism.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BaDongTourism.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public PostsController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        private bool IsAdminLoggedIn()
        {
            return HttpContext.Session.GetString("AdminUser") != null;
        }

        public async Task<IActionResult> Index()
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("Login", "Account", new { area = "Admin" });
            }

            var posts = await _context.Posts
                .Include(p => p.Category)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            return View(posts);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("Login", "Account", new { area = "Admin" });
            }

            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        public IActionResult Create()
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("Login", "Account", new { area = "Admin" });
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Post post, IFormFile? imageFile)
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("Login", "Account", new { area = "Admin" });
            }

            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    post.ImageUrl = await UploadImage(imageFile);
                }

                post.CreatedAt = DateTime.Now;

                _context.Add(post);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Thêm bài viết thành công!";
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", post.CategoryId);
            return View(post);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("Login", "Account", new { area = "Admin" });
            }

            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", post.CategoryId);
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Post post, IFormFile? imageFile)
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("Login", "Account", new { area = "Admin" });
            }

            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var oldPost = await _context.Posts.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

                if (oldPost == null)
                {
                    return NotFound();
                }

                if (imageFile != null && imageFile.Length > 0)
                {
                    post.ImageUrl = await UploadImage(imageFile);
                }
                else
                {
                    post.ImageUrl = oldPost.ImageUrl;
                }

                post.CreatedAt = oldPost.CreatedAt;

                _context.Update(post);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Cập nhật bài viết thành công!";
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", post.CategoryId);
            return View(post);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("Login", "Account", new { area = "Admin" });
            }

            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!IsAdminLoggedIn())
            {
                return RedirectToAction("Login", "Account", new { area = "Admin" });
            }

            var post = await _context.Posts.FindAsync(id);

            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Xóa bài viết thành công!";
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<string> UploadImage(IFormFile imageFile)
        {
            string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string fileExtension = Path.GetExtension(imageFile.FileName);
            string fileName = Guid.NewGuid().ToString() + fileExtension;
            string filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return "/uploads/" + fileName;
        }
    }
}