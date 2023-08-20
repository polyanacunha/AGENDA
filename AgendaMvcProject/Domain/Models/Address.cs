using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD:AgendaMvcProject/Domain/Models/Address.cs
namespace AgendaMvcProject.Domain.Models;
=======
namespace Application.Models;
>>>>>>> origin/Andress:AgendaMvcProject/Application/Models/Address.cs
[Table("Address")]
public class Address
{   
    [Key]
    [Column("address_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AddressId {get; set;}
    [Column("contact_id")]
    [ForeignKey("contact_id")]
    public int ContactId { get; set; }
    [Required]
    [Column("country")]
    public string Country { get; set; }
    [Required]
     [Column("neighbourhood")]
    public string Neighbourhood { get; set; }
    [Required]
    [Column("city")]
    public string City { get; set; }
    [Required]
    [Column("state")]
    public string State { get; set; }
    [Required]
    [Column("zipcode")]
    public int ZipCode { get; set; }
    [Required]
    [Column ("number")]
    public int Number { get; set;}
    [Column ("description")]
    public string Description {get; set;}
}