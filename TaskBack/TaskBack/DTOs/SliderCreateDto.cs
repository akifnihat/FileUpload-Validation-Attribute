using Microsoft.AspNetCore.Http;

namespace TaskBack.DTOs;

public class SliderCreateDto
{
    public string Title { get; set; } = default!;
    public IFormFile Image { get; set; } = default!; // uploaded image file
    public string? LinkUrl { get; set; }
    public string? Description { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; } = true;
}
