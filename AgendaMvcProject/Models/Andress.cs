using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.Models;
[Table("Address")]
public class Andress
{   
    [Key]
    [Column("address_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


    [ForeignKey("contatc_id")]
    public int contact_id { get; set; }

    [Required]
    [Column("country")]
    public string country { get; set; }

    [Required]
     [Column("neighbourhood")]
    public string neighbourhood { get; set; }

    [Required]
    [Column("city")]
    public string city { get; set; }

    [Required]
    [Column("state")]
    public string state { get; set; }

    [Required]
    [Column("zipcode")]
    public int zipcode { get; set; }
    
    [Required]
    [Column ("number")]
    public int number { get; set;}


    [Column ("description")]
    public string description {get; set;}

}