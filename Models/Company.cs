using System.ComponentModel.DataAnnotations;

namespace FullStackApi.Models;

public class Company
{
  [Key]
  public int Id { get; set; }

  public string? Name { get; set; }

  public string? Address { get; set; }

  public string? Assigments { get; set; }

  public int OrganizationNumber {get; set;}
  
  public string? Image { get; set; }

  public string? ContactName { get; set; }

  public string? ContactEmail { get; set; }

}