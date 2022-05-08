using System.ComponentModel.DataAnnotations;

namespace FullStackApi.Models;

public class Assignment
{
  [Key]
  public int Id { get; set; }

  public string? Title { get; set; }

  public string? Company { get; set; }

  public int Price { get; set; }

  public string? Team { get; set; }

}