#nullable disable

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FullStackApi.Models;

namespace FullStackApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvoiceController : ControllerBase
{
  private readonly FullStackApiContext _context;

  public InvoiceController(FullStackApiContext context)
  {
    _context = context;
  }

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    List<Invoice> invoices = await _context.Invoices.ToListAsync();
    if (invoices == null) return BadRequest();
    return Ok(invoices);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> Get(int id)
  {
    Invoice invoice = await _context.Invoices.FindAsync(id);
    if (invoice == null) return BadRequest();
    return Ok(invoice);
  }

  [HttpPost]
  public async Task<IActionResult> Post(Invoice newInvoice)
  {
    if (newInvoice == null) return BadRequest();
    _context.Invoices.Add(newInvoice);
    await _context.SaveChangesAsync();

    Invoice invoice = await _context.Invoices.FindAsync(newInvoice.Id);
    return Ok(invoice);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    Invoice invoice = await _context.Invoices.FindAsync(id);
    if (invoice == null) return BadRequest();
    _context.Invoices.Remove(invoice);
    await _context.SaveChangesAsync();
    return NoContent();
  }

  [HttpPut]
  public async Task<IActionResult> Put(Invoice editedInvoice)
  {
    if (editedInvoice == null) return BadRequest();
    _context.Entry(editedInvoice).State = EntityState.Modified;
    await _context.SaveChangesAsync();
    return NoContent();
  }

}