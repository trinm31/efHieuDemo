using System.ComponentModel.DataAnnotations;

namespace efHieuDemo.Models;

public class People
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }

    public int Age { get; set; }

    public string Description { get; set; }
}