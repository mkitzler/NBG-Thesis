using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NBG.Visitor.Services.DB.Mapping;
using NBG.Visitor.Storage.Dtos;
using NBG.Visitor.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBG.Visitor.Services.DB
{
    public class VisitService : IVisitService
    {
        private VisitContext _context = new();

        IMapper mapper = (new AutoMapperConfiguration()).Configure().CreateMapper();

        public async Task<VisitorDto> ReadVisitorIfExists(string firstName, string lastName, string phoneNumber)
        {
            return mapper.Map<VisitorDto>(await _context.Visitors.Where(x => x.FirstName == firstName && x.LastName == lastName && x.PhoneNumber == phoneNumber).FirstOrDefaultAsync().ConfigureAwait(false));
        }

        /// <summary>
        /// Adds a visit entry to the Database.
        /// </summary>
        /// <remarks>
        /// Will also create a new visitor if not already in Database.
        /// </remarks>
        /// <param name="_context"></param>
        /// <param name="start"></param>
        /// <param name="contactPerson"></param>
        /// <param name="company"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task AddVisit(DateTime start, ContactPerson contactPerson, Company company, string firstName, string lastName, string phoneNumber, string email = null)
        {
            var visitor = mapper.Map<Storage.Models.Visitor>(await ReadVisitorIfExists(firstName, lastName, phoneNumber).ConfigureAwait(false));
            if (visitor == null)
            {
                visitor = new Storage.Models.Visitor() { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, Email = email };
                await _context.AddVisitor(visitor).ConfigureAwait(false);
            }
            await _context.AddVisit(new Visit() { VisitStart = start, Visitor = visitor, ContactPerson = contactPerson, Company = company }).ConfigureAwait(false);
        }
    }
}
