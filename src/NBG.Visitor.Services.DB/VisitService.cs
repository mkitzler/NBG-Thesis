using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NBG.Visitor.Domain;
using NBG.Visitor.Domain.Commands;
using NBG.Visitor.Domain.Dtos;
using NBG.Visitor.Services.DB.Mapping;
using NBG.Visitor.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<VisitDto> UpdateVisit(int Id, DateTime? start, DateTime? end, VisitStatusDto status, string contactPerson, string company, string firstName, string lastName, string phoneNumber, string email = null)
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
            return mapper.Map<VisitDto>(visit);
        } //UpdateVisitor?

        public async Task<VisitDto> UpdateVisit(int Id, PatchVisitCommand changes)
        {
            using var context = _contextFactory.CreateDbContext();
            var visit = context.Visits.Include(v => v.Visitor).First(visit => visit.Id == Id);

            foreach (var p in visit.GetType().GetProperties())
            {
                object nextVal = changes.GetType().GetProperty(p.Name)?.GetValue(changes);
                if (nextVal != null)
                {
                    p.SetValue(visit, nextVal);
                }
            }
            foreach (var p in visit.Visitor.GetType().GetProperties())
            {
                object nextVal = changes.GetType().GetProperty(p.Name)?.GetValue(changes);
                if (nextVal != null)
                {
                    p.SetValue(visit.Visitor, nextVal);
                }
            }
            await context.SaveChangesAsync().ConfigureAwait(false);
            return mapper.Map<VisitDto>(visit);
        } //UpdateVisitor?

        public async Task RemoveVisit(int Id)
        {
            using var context = _contextFactory.CreateDbContext();
            await context.RemoveVisit(context.Visits.Find(Id)).ConfigureAwait(false);
        }

        public async Task<RegisterFormDataDto> ReadRegisterFormDataByGuid(Guid guid)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Visits.Where(x => x.Guid == guid).Include(v => v.Visitor).Select(v => new RegisterFormDataDto() { Company = v.CompanyLabel, ContactPerson = v.ContactPerson, Email = v.Visitor.Email, PhoneNumber = v.Visitor.PhoneNumber, FirstName = v.Visitor.FirstName, LastName = v.Visitor.LastName }).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<VisitDto> ReadVisitByGuid(Guid guid)
        {
            using var context = _contextFactory.CreateDbContext();
            return mapper.Map<VisitDto>(await context.Visits.Where(x => x.Guid == guid).Include(v => v.Visitor).FirstOrDefaultAsync());
        }

        public async Task<VisitDto> ReadActiveVisits()
        {
            using var context = _contextFactory.CreateDbContext();
            return mapper.Map<VisitDto>(await context.Visits.Where(x => x.Status == mapper.Map<VisitStatus>(VisitStatusDto.VISIT_ACTIVE)).Include(v => v.Visitor).FirstOrDefaultAsync());
        }

        public async Task RemoveOldVisits()
        {
            using var context = _contextFactory.CreateDbContext();
            var visits = await context.ReadAllVisits()
                .Include(v => v.Visitor)
                .Select(v => mapper.Map<VisitDto>(v))
                .ToListAsync().ConfigureAwait(false);
            var visitors = await context.ReadAllVisitors();
            foreach (var visitor in visitors)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine("NAME: " + visitor.FirstName);
                var visitorVisits = from v in visits
                                    where v.Visitor.Id == visitor.Id
                                    select v;

                int removedVisitCount = 0;

                foreach (var visitorVisit in visitorVisits)
                {
                    Console.WriteLine("VISIT ID: " + visitorVisit.Id);
                    Console.WriteLine("VISITOR ID: " + visitorVisit.Visitor.Id);
                    Console.WriteLine("VISIT END: " + visitorVisit.VisitEnd);
                    Console.WriteLine("TIME SPAN: " + ((DateTime.Now - visitorVisit.VisitEnd) ?? TimeSpan.Zero).ToString());
                    Console.WriteLine("TOTAL DAYS: " + ((DateTime.Now - visitorVisit.VisitEnd) ?? TimeSpan.Zero).TotalDays);
                    if (((DateTime.Now - visitorVisit.VisitEnd) ?? TimeSpan.Zero).TotalDays >= 14.0)
                    {
                        await context.RemoveVisit(context.Visits.Find(visitorVisit.Id)).ConfigureAwait(false);
                        Console.WriteLine("Removed Visit with Id:" + visitorVisit.Id);
                        removedVisitCount++;
                    }
                }

                if (visitorVisits.Count() - removedVisitCount < 1)
                {

                    Console.WriteLine(visitorVisits.Count());
                    Console.WriteLine(removedVisitCount);
                    await context.RemoveVisitor(visitor);
                }
            }
        }
    }
}
