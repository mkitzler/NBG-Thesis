using NBG.Visitor.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Domain.Commands
{
    public class AddVisitCommand
    {
        public DateTime? Start { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; } = null;
        public string Company { get; set; } = null;
        public string ContactPerson { get; set; } = null;
        public VisitStatusDto Status { get; set; } = VisitStatusDto.VISIT_ACTIVE;
    }
}
