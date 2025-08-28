using Microsoft.AspNetCore.Hosting;

namespace TaskBack.Helpers;

public interface IImageFileHelper
{
    Task<string> SaveImageAsync(IFormFile file, CancellationToken ct = default);
    Task DeleteImageAsync(string relativePath, CancellationToken ct = default);
}

public class ImageFileHelper : IImageFileHelper
{
    private readonly string _imagesRoot;

    public ImageFileHelper(IWebHostEnvironment env)
    {
        _imagesRoot = Path.Combine(env.WebRootPath ?? Path.Combine(env.ContentRootPath, "wwwroot"), "images", "sliders");
        Directory.CreateDirectory(_imagesRoot);
    }

    public async Task<string> SaveImageAsync(IFormFile file, CancellationToken ct = default)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("File is empty", nameof(file));

        var ext = Path.GetExtension(file.FileName);
        var allowed = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
        if (!allowed.Contains(ext.ToLowerInvariant()))
            throw new InvalidOperationException("Unsupported image type.");

        var fileName = $"slider_{Guid.NewGuid():N}{ext}";
        var fullPath = Path.Combine(_imagesRoot, fileName);
        await using var stream = new FileStream(fullPath, FileMode.Create);
        await file.CopyToAsync(stream, ct);

        // return relative path e.g. /images/sliders/slider_xxx.jpg
        return Path.Combine("/images/sliders", fileName).Replace("\\", "/");
    }

    public Task DeleteImageAsync(string relativePath, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(relativePath)) return Task.CompletedTask;
        var safeRel = relativePath.Replace('/', Path.DirectorySeparatorChar).TrimStart(Path.DirectorySeparatorChar);
        var fullPath = Path.Combine(Path.GetDirectoryName(_imagesRoot)!, safeRel);
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }
        return Task.CompletedTask;
    }
}
