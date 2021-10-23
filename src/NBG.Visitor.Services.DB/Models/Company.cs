using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Services.DB.Models
{
    [Table("Company")]
    class Company
    {
        [Column]
        [Required]
        [Key]
        public string CompanyLabel {  get; set; }

        [ForeignKey("CompanyLabel")]
        public List<Visit> Visits { get; set; }
    }
}
