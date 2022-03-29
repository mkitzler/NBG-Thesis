using NBG.Visitor.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NBG.Visitor.Domain
{
    public interface IVisitService
    {
        #nullable enable
        Task<VisitorDto?> ReadVisitorIfExists(string firstName, string lastName, string phoneNumber);
        #nullable disable
        Task<VisitDto> AddVisit(DateTime? start, string firstName, string lastName, string phoneNumber, string email = null, string company = null, string contactPerson = null, VisitStatusDto status = VisitStatusDto.VISIT_ACTIVE);
        Task<List<VisitDto>> ReadAllVisits();
        Task<VisitDto> ReadActiveVisits();
        Task RemoveVisit(int Id);
        Task<VisitDto> UpdateVisit(int Id, DateTime? start, DateTime? end, VisitStatusDto status, string contactPerson, string company, string firstName, string lastName, string phoneNumber, string email = null);
        Task<VisitDto> UpdateVisit(int Id, PatchVisitCommand changes);
        Task<RegisterFormDataCommand> ReadRegisterFormDataByGuid(Guid guid);
        Task<VisitDto> ReadVisitByGuid(Guid guid);
        Task RemoveOldVisits();
    }
}
