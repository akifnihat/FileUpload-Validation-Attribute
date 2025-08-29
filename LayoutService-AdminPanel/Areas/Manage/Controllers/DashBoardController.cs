using Microsoft.AspNetCore.Mvc;

namespace LayoutService_AdminPanel.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
