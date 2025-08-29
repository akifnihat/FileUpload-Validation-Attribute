using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LayoutService_AdminPanel.Models.Common;
using Microsoft.AspNetCore.Http;
using LayoutService_AdminPanel.Validation;

namespace LayoutService_AdminPanel.Models
{
    public class Book:BaseEntity
    {
        public string? Title { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public decimal DiscountPercentage { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsNew { get; set; }
        public bool InStock { get; set; }
        [Required]
        public string? MainImageUrl { get; set; }
        [Required]
        public string? HoverImageUrl { get; set; }
        public List<BookImage> BookImages { get; set; }
        public List<BookTag> BookTags { get; set; }

        // Not mapped upload fields for create/update
        [NotMapped]
        [FileValidation(new[] {"image/jpeg","image/png","image/webp"}, maxMB: 3)]
        public IFormFile MainImage { get; set; }

        [NotMapped]
        [FileValidation(new[] {"image/jpeg","image/png","image/webp"}, maxMB: 3)]
        public IFormFile HoverImage { get; set; }

        [NotMapped]
        [FileValidation(new[] {"image/jpeg","image/png","image/webp"}, maxMB: 3)]
        public List<IFormFile> ImageFiles { get; set; }
    }
}
