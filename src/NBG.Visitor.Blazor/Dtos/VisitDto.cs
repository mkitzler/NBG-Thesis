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
            if(company  == null)
                Company = new CompanyDto();
            else
                Company = company;
            if (contactPerson == null)
                ContactPerson = new ContactPersonDto();
            else
                ContactPerson = contactPerson;
            if (contactPerson == null)
                Visitor = new VisitorDto();
            else
                Visitor = visitor;
        }
        public int Id { get; set; }
        public DateTime VisitStart { get; set; }
        public DateTime VisitEnd { get; set; }
        public VisitorDto Visitor { get; set; }
        public ContactPersonDto ContactPerson { get; set; }
        public CompanyDto Company { get; set; }
        public string Status { get; set; }
    }
}
