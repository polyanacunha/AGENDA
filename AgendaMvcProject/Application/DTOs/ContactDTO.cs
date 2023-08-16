using System.ComponentModel.DataAnnotations;

namespace AgendaMvcProject.Application.DTOs;

public class ContactDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }
    [Required(ErrorMessage = "The Name is Required")]
    public int Telephone { get; set; }
    [Required(ErrorMessage = "The Number is Required")]
    [MinLength(9)]
    [MaxLength(15)]
    public string? Description { get; set; }
    public string? Email { get; set; }

}
