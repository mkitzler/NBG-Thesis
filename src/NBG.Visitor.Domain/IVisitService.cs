using NBG.Visitor.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NBG.Visitor.Domain
{
    public interface IVisitService
    {
        Task<VisitorDto> ReadVisitorIfExists(string firstName, string lastName, string phoneNumber);
        Task AddVisit(DateTime start, string contactPerson, string company, string firstName, string lastName, string phoneNumber, string email = null);
        Task<List<VisitDto>> ReadAllVisits();
        Task RemoveVisit(int Id);
        Task UpdateVisit(int Id, DateTime start, DateTime end, VisitStatusDto status, string contactPerson, string company, string firstName, string lastName, string phoneNumber, string email = null);
    }
}
