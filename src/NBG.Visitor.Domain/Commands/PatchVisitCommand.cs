using NBG.Visitor.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Domain.Commands
{
    public class PatchVisitCommand
    {
        public DateTime? VisitStart { get; set; } = null;
        public DateTime? VisitEnd { get; set; } = null;
        public VisitStatusDto? Status { get; set; } = null;
        public string ContactPerson { get; set; } = null;
        public string CompanyLabel { get; set; } = null;
        public string FirstName { get; set; } = null;
        public string LastName { get; set; } = null;
        public string PhoneNumber { get; set; } = null;
        public string Email { get; set; } = null;
    }
}
