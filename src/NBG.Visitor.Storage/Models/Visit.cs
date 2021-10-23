using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Storage.Models
{
    [Table("visit")]
    public class Visit
    {
        [Column("id")]
        [Required]
        [Key]
        public int Id {  get; set; }

        [Column("visit_start")]
        public DateTime? VisitStart {  get; set; }

        [Column("visit_end")]
        public DateTime? VisitEnd {  get; set; }

        [Column("visitor_id")]
        [Required]
        public Visitor? Visitor {  get; set; }

        [Column("contact_person_name")]
        public ContactPerson? ContactPerson {  get; set; }

        [Column("company_label")]
        public Company? Company {  get; set; }

        [Column("status")]
        [Required]
        public VisitStatus Status {  get; set; }
    }
}
