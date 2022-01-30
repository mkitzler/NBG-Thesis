using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NBG.Visitor.Services.DB.Mapping;
using NBG.Visitor.Domain.Dtos;
using NBG.Visitor.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBG.Visitor.Domain;

namespace NBG.Visitor.Services.DB
{
    public class VisitService : IVisitService
    {
        private readonly IDbContextFactory<VisitContext> _contextFactory;
        private readonly IMapper mapper = AutoMapperConfiguration.Configure().CreateMapper();

        public VisitService(IDbContextFactory<VisitContext> dbContextFactory) 
        {
            _contextFactory = dbContextFactory;
        }

        public async Task<VisitorDto> ReadVisitorIfExists(string firstName, string lastName, string phoneNumber)
        {
            using var context = _contextFactory.CreateDbContext();
            return mapper.Map<VisitorDto>(await context.Visitors.FirstOrDefaultAsync(x => x.FirstName == firstName && x.LastName == lastName && x.PhoneNumber == phoneNumber).ConfigureAwait(false));
        }

        public async Task<List<VisitDto>> ReadAllVisits()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.ReadAllVisits()
            .Include(v => v.Visitor)
            .Select(v => mapper.Map<VisitDto>(v))
            .ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Adds a visit entry to the Database.
        /// </summary>
        /// <remarks>
        /// Will also create a new visitor if not already in Database.
        /// </remarks>
        /// <param name="start"></param>
        /// <param name="contactPerson"></param>
        /// <param name="company"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="email"></param>
        /// <param name="status"></param>
        /// <returns>The created Visit.</returns>
        public async Task<VisitDto> AddVisit(DateTime? start, string firstName, string lastName, string phoneNumber, string email = null, string company = null, string contactPerson = null, VisitStatusDto status = VisitStatusDto.VISIT_ACTIVE)
        {
            using var context = _contextFactory.CreateDbContext();
            var visitor = new Storage.Models.Visitor() { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, Email = email };
            Visit ret = await context.AddVisit(new Visit() { VisitStart = start, Visitor = visitor, ContactPerson = contactPerson, CompanyLabel = company, Status = mapper.Map<VisitStatus>(status) }).ConfigureAwait(false);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return mapper.Map<VisitDto>(ret);
        }

        public async Task UpdateVisit(int Id, DateTime? start, DateTime? end, VisitStatusDto status, string contactPerson, string company, string firstName, string lastName, string phoneNumber, string email = null)
        {
            using var context = _contextFactory.CreateDbContext();
            var visit = context.Visits.Include(v => v.Visitor).First(visit => visit.Id == Id);

            visit.CompanyLabel = company;
            visit.ContactPerson = contactPerson;
            visit.VisitStart = start;
            visit.VisitEnd = end;
            visit.Status = mapper.Map<VisitStatus>(status);
            visit.Visitor.FirstName = firstName;
            visit.Visitor.LastName = lastName;
            visit.Visitor.PhoneNumber = phoneNumber;
            visit.Visitor.Email = email;
            await context.SaveChangesAsync().ConfigureAwait(false);
        } //UpdateVisitor?

        public async Task RemoveVisit(int Id)
        {
            using var context = _contextFactory.CreateDbContext();
            await context.RemoveVisit(context.Visits.Find(Id)).ConfigureAwait(false);
        }
    }
}
