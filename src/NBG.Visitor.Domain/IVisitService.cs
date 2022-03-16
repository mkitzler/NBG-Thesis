using NBG.Visitor.Domain.Commands;
using NBG.Visitor.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NBG.Visitor.Domain
{
    public interface IVisitService
    {
        Task<VisitorDto> ReadVisitorIfExists(string firstName, string lastName, string phoneNumber);
        Task<VisitDto> AddVisit(DateTime? start, string firstName, string lastName, string phoneNumber, string email = null, string company = null, string contactPerson = null, Guid? guid = null, VisitStatusDto status = VisitStatusDto.VISIT_ACTIVE);
        Task<List<VisitDto>> ReadAllVisits();
        Task<VisitDto> ReadActiveVisits();
        Task RemoveVisit(int Id);
        Task<VisitDto> UpdateVisit(int Id, DateTime? start, DateTime? end, VisitStatusDto status, string contactPerson, string company, string firstName, string lastName, string phoneNumber, string email = null);
        Task<VisitDto> UpdateVisit(int Id, PatchVisitCommand changes);
        Task<RegisterFormDataDto> ReadRegisterFormDataByGuid(Guid guid);
        Task<VisitDto> ReadVisitByGuid(Guid guid);
        Task RemoveOldVisits();
    }
}
