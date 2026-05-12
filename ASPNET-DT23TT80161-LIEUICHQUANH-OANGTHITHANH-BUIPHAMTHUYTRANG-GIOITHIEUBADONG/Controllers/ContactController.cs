using BaDongTourism.Data;
using BaDongTourism.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaDongTourism.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.CreatedAt = DateTime.Now;
                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Gửi liên hệ thành công!";
                return RedirectToAction(nameof(Index));
            }

            return View(contact);
        }
    }
}
