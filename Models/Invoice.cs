using System.ComponentModel.DataAnnotations;

namespace FullStackApi.Models;

public class Invoice
{
  [Key]
  public int Id { get; set; }

  public string? Title { get; set; }

  public string? Company { get; set; }

  public string? Product { get; set; }

  public int DaysDue { get; set; }

  public int Total { get; set; }

  public Boolean Sent { get; set; }

}