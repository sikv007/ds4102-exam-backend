#nullable disable

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FullStackApi.Models;

namespace FullStackApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeveloperController : ControllerBase
{

  private readonly FullStackApiContext _context;
  private readonly IWebHostEnvironment _hosting;

  public DeveloperController(FullStackApiContext context, IWebHostEnvironment hosting)
  {
    _context = context;
    _hosting = hosting;
  }

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    List<Developer> developers = await _context.Developers.ToListAsync();
    if (developers == null) return BadRequest();
    return Ok(developers);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> Get(int id)
  {
    Developer developer = await _context.Developers.FindAsync(id);
    if (developer == null) return BadRequest();
    return Ok(developer);
  }

  [HttpPost]
  public async Task<IActionResult> Post(Developer newDeveloper)
  {
    _context.Developers.Add(newDeveloper);
    await _context.SaveChangesAsync();
    Developer developer = await _context.Developers.FindAsync(newDeveloper.Id);
    if (developer == null) return BadRequest();
    return Ok(developer);
  }

  [HttpPost]
  [Route("[action]")]
  public IActionResult PostImage(IFormFile file)
  {
    string webRootPath = _hosting.WebRootPath;
    string absolutePath = Path.Combine($"{webRootPath}/src/img/developer/{file.FileName}");

    using (var fileStream = new FileStream(absolutePath, FileMode.Create))
    {
      file.CopyTo(fileStream);
    }
    return Ok();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    Developer developer = await _context.Developers.FindAsync(id);
    if (developer == null) return BadRequest();
    _context.Developers.Remove(developer);
    await _context.SaveChangesAsync();
    return NoContent();
  }

  [HttpPut]
  public async Task<IActionResult> Put(Developer editedDeveloper)
  {
    _context.Entry(editedDeveloper).State = EntityState.Modified;
    await _context.SaveChangesAsync();
    return NoContent();
  }

}