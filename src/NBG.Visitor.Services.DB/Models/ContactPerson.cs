using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Services.DB.Models
{
    [Table("ContactPerson")]
    class ContactPerson
    {
        [Column]
        [Required]
        [Key]
        public string Name {  get; set; }

        [ForeignKey("ContactPersonName")]
        public List<Visit> Visits {  get; set; }
    }
}
