using LayoutService_AdminPanel.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace LayoutService_AdminPanel.Models
{
    public class Tag:BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public List<BookTag> BookTags { get; set; }
    }
}
