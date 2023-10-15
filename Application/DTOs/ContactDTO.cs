using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class ContactDTO
{
    public int Id { get; set; }


    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }

 
    public int Telephone { get; set; }
 
    [MaxLength(200)]
    public string? Description { get; set; }

    [MaxLength(100)]
    public string? Email { get; set; }

}
