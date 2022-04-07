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

  public DeveloperController(FullStackApiContext context)
  {
    _context = context;
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
    return Ok();
  }

  [HttpPost]
  public async Task<IActionResult> Post(Developer newDeveloper)
  {
    _context.Developers.Add(newDeveloper);
    await _context.SaveChangesAsync();

    Developer developer = await _context.Developers.FindAsync(newDeveloper.Id);

    return Ok(developer);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    Developer developer = await _context.Developers.FindAsync(id);
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