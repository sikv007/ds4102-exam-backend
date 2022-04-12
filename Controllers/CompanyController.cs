#nullable disable

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FullStackApi.Models;

namespace FullStackApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{

  private readonly FullStackApiContext _context;
  private readonly IWebHostEnvironment _hosting;

  public CompanyController(FullStackApiContext context, IWebHostEnvironment hosting)
  {
    _context = context;
    _hosting = hosting;
  }

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    List<Company> companies = await _context.Companies.ToListAsync();
    if (companies == null) return BadRequest();
    return Ok(companies);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> Get(int id)
  {
    Company company = await _context.Companies.FindAsync(id);
    if (company == null) return BadRequest();
    return Ok(company);
  }

  [HttpPost]
  public async Task<IActionResult> Post(Company newCompany)
  {
    _context.Companies.Add(newCompany);
    await _context.SaveChangesAsync();

    Company company = await _context.Companies.FindAsync(newCompany.Id);

    return Ok(company);
  }

  [HttpPost]
  [Route("[action]")]
  public IActionResult PostImage(IFormFile file)
  {
    string webRootPath = _hosting.WebRootPath;
    string absolutePath = Path.Combine($"{webRootPath}/src/img/company/{file.FileName}");

    using (var fileStream = new FileStream(absolutePath, FileMode.Create))
    {
      file.CopyTo(fileStream);
    }
    return Ok();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    Company company = await _context.Companies.FindAsync(id);
    _context.Companies.Remove(company);
    await _context.SaveChangesAsync();
    return NoContent();
  }

  [HttpPut]
  public async Task<IActionResult> Put(Company editedCompany)
  {
    _context.Entry(editedCompany).State = EntityState.Modified;
    await _context.SaveChangesAsync();
    return NoContent();
  }

}