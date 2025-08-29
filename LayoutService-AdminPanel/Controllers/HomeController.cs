using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LayoutService_AdminPanel.Data;
using LayoutService_AdminPanel.ViewModels;

namespace LayoutService_AdminPanel.Controllers
{
    public class HomeController(PustokDbContext pustokDbContext) : Controller
    {
        public IActionResult Index()
        {
            HomeVm homeVm = new()
            {
                Sliders = pustokDbContext.Sliders.ToList(),
                FeaturedBooks = pustokDbContext.Books
                .Include(b => b.Author)
                .Where(b => b.IsFeatured)
                .ToList(),
                NewBooks = pustokDbContext.Books
                .Include(b => b.Author)
                .Where(b => b.IsNew)
                .ToList(),
                DiscountBooks = pustokDbContext.Books
                .Include(b => b.Author)
                .Where(b => b.DiscountPercentage > 0)
                .ToList()
            };
            return View(homeVm);
        }
    }
}
