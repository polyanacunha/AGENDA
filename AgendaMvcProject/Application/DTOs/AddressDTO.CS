using System.ComponentModel.DataAnnotations;

namespace AgendaMvcProject.Application.DTOs;

public class AddressDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The Country is Required")]
    [MinLength(9)]
    [MaxLength(15)]
    public string? Country { get; set; }
 
    [MaxLength(200)]
    public string? Neighbourhood { get; set; }

    [MaxLength(100)]
    public string? City { get; set; }

    [MaxLength(100)]
    public string? State { get; set; }

     [MaxLength(100)]
    public int ZipCode { get; set; }
    
    [MaxLength(100)]
    public int Number{ get; set; }

    [MaxLength(100)]
    public string? Description { get; set; }

}