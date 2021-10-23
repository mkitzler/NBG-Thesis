using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Services.DB.Models
{
    [Table("Visitor")]
    class Visitor
    {
        public int Id {  get; set; }
        public string FirstName {  get; set; }
        public string LastName {  get; set; }
        public string PhoneNumber {  get; set; }
        public string Email {  get; set; }

        [ForeignKey("VisitorId")]
        public List<Visit> Visits {  get; set; }
    }
}
