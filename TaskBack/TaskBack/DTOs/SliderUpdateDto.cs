using Microsoft.AspNetCore.Http;

namespace TaskBack.DTOs;

public class SliderUpdateDto
{
    public string Title { get; set; } = default!;
    public IFormFile? Image { get; set; } // optional new image file
    public string? LinkUrl { get; set; }
    public string? Description { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; }
}
