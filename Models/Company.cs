using System.ComponentModel.DataAnnotations;

namespace FullStackApi.Models;

public class Company
{
  [Key]
  public int Id { get; set; }

  public string? Name { get; set; }

  public string? Assigments { get; set; }

  public string? Logo { get; set; }

  public string? ContactName { get; set; }

  public string? contactEmail { get; set; }

}