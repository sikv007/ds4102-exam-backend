using System.ComponentModel.DataAnnotations;

namespace FullStackApi.Models;

public class Invoice
{
  [Key]
  public int Id { get; set; }

  public string? Title => $"Faktura #{Id.ToString().PadLeft(3, '0')}";

  public string? Company { get; set; }

  public string? Product { get; set; }

  public string? DateDue { get; set; }

  public int Total { get; set; }

}