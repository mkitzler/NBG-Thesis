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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? Id {  get; set; }

        #nullable enable
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
        #nullable disable

        [Column("status")]
        [Required]
        public VisitStatus Status {  get; set; }

        [Column("uuid")]
        public Guid Guid { get; set; }
    }
}
