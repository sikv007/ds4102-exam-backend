using System.ComponentModel.DataAnnotations;

namespace FullStackApi.Models;

public class Assignment
{
  [Key]
  public int Id { get; set; }

  public string? Title { get; set; }

  public string? Description { get; set; }

  public string? Company { get; set; }

  public string? Team { get; set; }

  public string? StartDate { get; set; }

  public string? EndDate { get; set; }

  public Boolean Completed { get; set; }

}