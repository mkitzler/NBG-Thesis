using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Storage.Models
{
    [Table("Visitor")]
    public class Visitor
    {
        [Column]
        [Required]
        [Key]
        public int Id {  get; set; }

        [Column]
        [Required]
        public string FirstName {  get; set; }

        [Column]
        [Required]
        public string LastName {  get; set; }

        [Column]
        [Required]
        public string PhoneNumber {  get; set; }

        [Column]
        public string Email {  get; set; }

        [ForeignKey("VisitorId")]
        public List<Visit> Visits {  get; set; }
    }
}
