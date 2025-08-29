using LayoutService_AdminPanel.Models;

namespace LayoutService_AdminPanel.ViewModels
{
    public class HomeVm
    {
        public List<Slider> Sliders { get; set; }
        public List<Book> FeaturedBooks { get; set; }
        public List<Book> NewBooks { get; set; }
        public List<Book> DiscountBooks { get; set; }
    }
}
