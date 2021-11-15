using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Storage.Models
{
    [Table("contact_person")]
    public class ContactPerson
    {
        [Column("name")]
        [Required]
        [Key]
        public string Name {  get; set; }

        [ForeignKey("contact_person_name")]
        public List<Visit> Visits {  get; set; }
    }
}
