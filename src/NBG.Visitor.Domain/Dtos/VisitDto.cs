using System;

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
        public DateTime? PlannedVisitStart { get; set; }
        public DateTime? VisitStart { get; set; }
        public DateTime? VisitEnd { get; set; }
        public VisitorDto Visitor { get; set; }
        public string ContactPerson { get; set; }
        public string CompanyLabel { get; set; }
        public VisitStatusDto Status { get; set; }
        public Guid Guid { get; set; }
    }
}
