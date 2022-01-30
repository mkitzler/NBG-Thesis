using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Domain.Dtos
{
    public class VisitDto
    {
        public VisitDto() { }
        public VisitDto(VisitorDto visitor)
        {
            Visitor = visitor ?? new VisitorDto();
        }
        public int Id { get; set; }
        public DateTime? VisitStart { get; set; }
        public DateTime? VisitEnd { get; set; }
        public VisitorDto Visitor { get; set; }
        public string ContactPerson { get; set; }
        public string CompanyLabel { get; set; }
        public VisitStatusDto Status { get; set; }
        public Guid Guid { get; set; }
    }
}
