#nullable disable

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FullStackApi.Models;

namespace FullStackApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssignmentController : ControllerBase
{

  private readonly FullStackApiContext _context;

  public AssignmentController(FullStackApiContext context )
  {
    _context = context;
  }

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    List<Assignment> assignments = await _context.Assignments.ToListAsync();
    if (assignments == null) return BadRequest();
    return Ok(assignments);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> Get(int id)
  {
    Assignment assignment = await _context.Assignments.FindAsync(id);
    if (assignment == null) return BadRequest();
    return Ok(assignment);
  }

  [HttpPost]
  public async Task<IActionResult> Post(Assignment newAssignment)
  {
    _context.Assignments.Add(newAssignment);
    await _context.SaveChangesAsync();

    Assignment assignment = await _context.Assignments.FindAsync(newAssignment.Id);

    return Ok(assignment);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    Assignment assignment = await _context.Assignments.FindAsync(id);
    _context.Assignments.Remove(assignment);
    await _context.SaveChangesAsync();
    return NoContent();
  }

  [HttpPut]
  public async Task<IActionResult> Put(Assignment editedAssignment)
  {
    _context.Entry(editedAssignment).State = EntityState.Modified;
    await _context.SaveChangesAsync();
    return NoContent();
  }

}