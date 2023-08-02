using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AgendaMvcProject.Domain.Models; 
[Table("Contact")]
public class Contact
{   
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("contact_id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("telephone")]
    public int Telephone { get; set; }
    [Column("description")]
    public string Description { get; set; }
    [Column("email")]
    public string Email { get; set; }
}