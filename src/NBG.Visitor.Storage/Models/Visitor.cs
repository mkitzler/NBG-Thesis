using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Storage.Models
{
    [Table("visitor")]
    public class Visitor
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? Id {  get; set; }

        [Column("first_name")]
        [Required]
        public string FirstName {  get; set; }

        [Column("last_name")]
        [Required]
        public string LastName {  get; set; }

        [Column("phone_number")]
        [Required]
        public string PhoneNumber {  get; set; }

        [Column("email")]
        public string? Email {  get; set; }

        [ForeignKey("visitor_id")]
        public List<Visit> Visits { get; set; }
    }
}
