using NBG.Visitor.Storage.Dtos;
using NBG.Visitor.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Services.DB
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
