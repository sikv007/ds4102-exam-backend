using System.ComponentModel.DataAnnotations;

namespace FullStackApi.Models;

public class Developer
{
  [Key]
  public int Id { get; set; }

  public string? FirstName { get; set; }

  public string? LastName { get; set; }

  public int Phone {get; set;}

  public int DateOfBirth { get; set; }

  public string? JobTitle { get; set; }

  public string? Skills { get; set; }

}