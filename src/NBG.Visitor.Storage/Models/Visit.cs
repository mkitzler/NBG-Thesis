using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBG.Visitor.Storage.Models
{
    [Table("visit")]
    public class Visit
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? Id { get; set; }
#nullable enable
        [Column("planned_visit_start")]
        public DateTime? PlannedVisitStart { get; set; }

        [Column("visit_start")]
        public DateTime? VisitStart { get; set; }

        [Column("visit_end")]
        public DateTime? VisitEnd { get; set; }

        [Column("visitor_id")]
        [Required]
        public Visitor? Visitor { get; set; }
#nullable disable

        [Column("contact_person")]
        public string ContactPerson { get; set; }

        [Column("company_label")]
        public string CompanyLabel { get; set; }

        [Column("status")]
        [Required]
        public VisitStatus Status { get; set; }

        [Column("uuid")]
        public Guid Guid { get; set; }


    }
}
