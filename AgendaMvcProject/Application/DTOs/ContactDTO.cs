using System.ComponentModel.DataAnnotations;

namespace AgendaMvcProject.Application.DTOs;

public class ContactDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The Number is Required")]
    [MinLength(9)]
    [MaxLength(15)]
    public int Telephone { get; set; }
 
    [MaxLength(200)]
    public string? Description { get; set; }

    [MaxLength(100)]
    public string? Email { get; set; }

}
