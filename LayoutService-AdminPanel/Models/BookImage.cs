using System.ComponentModel.DataAnnotations;
using LayoutService_AdminPanel.Models.Common;

namespace LayoutService_AdminPanel.Models
{
    public class BookImage:BaseEntity
    {
        [Required]
        public string ImageUrl { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
