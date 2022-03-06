using NBG.Visitor.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Domain.Commands
{
    public class UpdateVisitCommand
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public VisitStatusDto Status { get; set; }
        public string ContactPerson { get; set; }
        public string Company { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; } = null;
    }
}
