using System.ComponentModel.DataAnnotations;

namespace efHieuDemo.Models;

public class People
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Ban can nhap vao ten")]
    public string Name { get; set; }

    public int Age { get; set; }

    public string Description { get; set; }
}