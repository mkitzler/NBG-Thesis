using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Blazor.Dtos
{
    public class VisitDto
    {
        public VisitDto(VisitorDto visitor, ContactPersonDto contactPerson, CompanyDto company)
        {
            Company = company  == null ? new CompanyDto() : company;
            ContactPerson = contactPerson == null ? new ContactPersonDto() : contactPerson;
            Visitor = contactPerson == null ? new VisitorDto() : visitor;
        }
        public int Id { get; set; }
        public DateTime? VisitStart { get; set; }
        public DateTime? VisitEnd { get; set; }
        public VisitorDto Visitor { get; set; }
        public ContactPersonDto ContactPerson { get; set; }
        public CompanyDto Company { get; set; }
        public string Status { get; set; }
    }
}
