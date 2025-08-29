using System.ComponentModel.DataAnnotations;
using LayoutService_AdminPanel.Models.Common;

namespace LayoutService_AdminPanel.Models
{
    public class Author: BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
