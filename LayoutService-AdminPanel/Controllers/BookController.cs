using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LayoutService_AdminPanel.Data;
using LayoutService_AdminPanel.ViewModels;

namespace LayoutService_AdminPanel.Controllers
{
    public class BookController(PustokDbContext pustokDbContext) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Detail(int? id)
        {
            if (id is null) return NotFound();

            var book = pustokDbContext.Books
                .Include(b => b.BookImages)
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .FirstOrDefault(b => b.Id == id);

            if (book is null) return NotFound();

            BookDetailVm bookDetailVm = new()
            {
                Book = book,
                RelatedBooks = pustokDbContext.Books
                    .Where(b => b.GenreId == book.GenreId && b.Id != book.Id)
                    .Include(b => b.Author)
                    .Take(4)
                    .ToList()
            };

            return View(bookDetailVm);
        }
        public IActionResult BookModal(int? id)
        {
            if (id is null)
                return NotFound();
            var book = pustokDbContext.Books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .Include(b => b.BookImages)
                .Include(b => b.BookTags)
                .ThenInclude(bt => bt.Tag)
                .FirstOrDefault(b => b.Id == id);

            if (book is null)
                return NotFound();

            return PartialView("_BookModal", book);
        }
    }
}
