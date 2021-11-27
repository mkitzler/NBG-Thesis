using NBG.Visitor.Storage.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NBG.Visitor.Domain
{
    public interface IVisitService
    {
        Task<VisitorDto> ReadVisitorIfExists(string firstName, string lastName, string phoneNumber);
        Task AddVisit(DateTime start, ContactPersonDto contactPerson, CompanyDto company, string firstName, string lastName, string phoneNumber, string email = null);
        Task<List<VisitDto>> ReadAllVisits();
        Task RemoveVisit(VisitDto visit);
        Task UpdateVisit(VisitDto visit);
    }
}
