#nullable disable

using Microsoft.EntityFrameworkCore;

namespace FullStackApi.Models;

public class FullStackApiContext : DbContext
{
  public FullStackApiContext(DbContextOptions<FullStackApiContext> options) : base(options) { }

  public DbSet<FullStackApi.Models.Developer> Developers { get; set; }

}