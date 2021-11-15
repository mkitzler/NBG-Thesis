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

        Task AddVisit(DateTime start, ContactPerson contactPerson, Company company, string firstName, string lastName, string phoneNumber, string email = null);
    }
}
