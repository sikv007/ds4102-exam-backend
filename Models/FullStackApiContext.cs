#nullable disable

using Microsoft.EntityFrameworkCore;

namespace FullStackApi.Models;

public class FullStackApiContext : DbContext
{
  public FullStackApiContext(DbContextOptions<FullStackApiContext> options) : base(options) { }

  public DbSet<FullStackApi.Models.Developer> Developers { get; set; }
  
  public DbSet<FullStackApi.Models.Company> Companies { get; set; }

  public DbSet<FullStackApi.Models.Assignment> Assignments { get; set; }

  public DbSet<FullStackApi.Models.Invoice> Invoices { get; set; }

}