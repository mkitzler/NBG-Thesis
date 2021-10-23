using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Storage.Models
{
    [Table("Visit")]
    public class Visit
    {
        [Column]
        [Required]
        [Key]
        public int Id {  get; set; }

        [Column]
        public DateTime VisitStart {  get; set; }

        [Column]
        public DateTime VisitEnd {  get; set; }


        [Column]
        [Required]
        public int VisitorId {  get; set; }
        public Visitor Visitor {  get; set; }

        [Column]
        [Required]
        public string ContactPersonName { get; set; }
        public ContactPerson ContactPerson {  get; set; }

        [Column]
        [Required]
        public string CompanyLabel { get; set; }
        public Company Company {  get; set; }

        [Column]
        public VisitStatus Status {  get; set; }
    }
}
