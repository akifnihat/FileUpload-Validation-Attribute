using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBack.Data;
using TaskBack.DTOs;
using TaskBack.Models;
using TaskBack.Helpers;

namespace TaskBack.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SlidersController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;
    private readonly IImageFileHelper _fileHelper;

    public SlidersController(ApplicationDbContext db, IMapper mapper, IImageFileHelper fileHelper)
    {
        _db = db;
        _mapper = mapper;
        _fileHelper = fileHelper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SliderReadDto>>> GetAll()
    {
        var sliders = await _db.Sliders.AsNoTracking().OrderBy(s => s.DisplayOrder).ToListAsync();
        return Ok(_mapper.Map<IEnumerable<SliderReadDto>>(sliders));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<SliderReadDto>> Get(int id)
    {
        var slider = await _db.Sliders.FindAsync(id);
        if (slider is null) return NotFound();
        return Ok(_mapper.Map<SliderReadDto>(slider));
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<ActionResult<SliderReadDto>> Create([FromForm] SliderCreateDto dto, CancellationToken ct)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);

        var entity = _mapper.Map<Slider>(dto);
        entity.CreatedAt = DateTime.UtcNow;

        // Save file and set FileUrl
        entity.FileUrl = await _fileHelper.SaveImageAsync(dto.Image, ct);

        _db.Sliders.Add(entity);
        await _db.SaveChangesAsync(ct);

        var readDto = _mapper.Map<SliderReadDto>(entity);
        return CreatedAtAction(nameof(Get), new { id = entity.Id }, readDto);
    }

    [HttpPut("{id:int}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Update(int id, [FromForm] SliderUpdateDto dto, CancellationToken ct)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);

        var entity = await _db.Sliders.FindAsync(id, ct);
        if (entity is null) return NotFound();

        _mapper.Map(dto, entity);

        if (dto.Image is not null)
        {
            // replace image
            var newPath = await _fileHelper.SaveImageAsync(dto.Image, ct);
            await _fileHelper.DeleteImageAsync(entity.FileUrl, ct);
            entity.FileUrl = newPath;
        }

        await _db.SaveChangesAsync(ct);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        var entity = await _db.Sliders.FindAsync(id, ct);
        if (entity is null) return NotFound();

        _db.Sliders.Remove(entity);
        await _db.SaveChangesAsync(ct);

        // delete image after DB success
        await _fileHelper.DeleteImageAsync(entity.FileUrl, ct);

        return NoContent();
    }
}
