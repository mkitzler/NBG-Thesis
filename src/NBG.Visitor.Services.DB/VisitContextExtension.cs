using Microsoft.EntityFrameworkCore;
using NBG.Visitor.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBG.Visitor.Services.DB
{
    public static class VisitContextExtension
    {
        #region Read
        public static async Task<Storage.Models.Visitor> ReadVisitorIfExists(this VisitContext _context, string firstName, string lastName, string phoneNumber)
        {
            return await _context.Visitors.Where(x => x.FirstName == firstName && x.LastName == lastName && x.PhoneNumber == phoneNumber).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public static async Task<ContactPerson[]> ReadContactPeople(this VisitContext _context)
        {
            return await _context.ContactPeople.ToArrayAsync().ConfigureAwait(false);
        }

        public static async Task<ContactPerson> ReadContactPersonByName(this VisitContext _context, string name)
        {
            return await _context.ContactPeople.FindAsync(name).ConfigureAwait(false);
        }
        
        public static async Task<Company[]> ReadCompanies(this VisitContext _context)
        {
            return await _context.Companies.ToArrayAsync().ConfigureAwait(false);
        }

        public static async Task<Company> ReadCompanyByLabel(this VisitContext _context, string label)
        {
            return await _context.Companies.FindAsync(label).ConfigureAwait(false);
        }
        public static async Task<Visit> ReadVisit(this VisitContext _context, int id)
        {
            return await _context.Visits
                .Include(v => v.Visitor)
                .Include(v => v.ContactPerson)
                .Include(v => v.Company)
                .FirstOrDefaultAsync(v => v.Id == id).ConfigureAwait(false);
        }
        public static async Task<IEnumerable<Visit>> ReadAllVisits(this VisitContext _context)
        {
            return await _context.Visits
                .Select(v => new Visit
                {
                    ContactPerson = v.ContactPerson,
                    Company = v.Company,
                    Visitor = v.Visitor,
                    Id = v.Id,
                    VisitStart = v.VisitStart,
                    VisitEnd = v.VisitEnd,
                    Status = v.Status

                }).ToListAsync().ConfigureAwait(false);
        }
        public static async Task<Storage.Models.Visitor> ReadVisitor(this VisitContext _context, int id)
        {
            return await _context.Visitors.FindAsync(id).ConfigureAwait(false);
        }
        public static async Task<IEnumerable<Storage.Models.Visitor>> ReadAllVisitors(this VisitContext _context)
        {
            return await _context.Visitors.ToListAsync().ConfigureAwait(false);
        }
        #endregion

        #region Add
        public static async Task AddVisitor(this VisitContext _context, Storage.Models.Visitor visitor)
        {
            await _context.Visitors.AddAsync(visitor).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
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
        public static async Task<Visit> AddVisit(this VisitContext _context, DateTime start, ContactPerson contactPerson, Company company, string firstName, string lastName, string phoneNumber, string email = null)
        {
            var visitor = await _context.ReadVisitorIfExists(firstName, lastName, phoneNumber).ConfigureAwait(false);
            if (visitor == null)
            {
                visitor = new Storage.Models.Visitor() { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, Email = email };
                await _context.AddVisitor(visitor).ConfigureAwait(false);
            }
            var visit = (await _context.Visits.AddAsync(new Visit() { VisitStart = start, Visitor = visitor, ContactPerson = contactPerson, Company = company }).ConfigureAwait(false)).Entity;
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return visit;
        }
        #endregion

        #region Remove
        public static async Task RemoveVisitor(this VisitContext _context, Storage.Models.Visitor visitor)
        {
            _context.Visitors.Remove(visitor);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public static async Task RemoveVisit(this VisitContext _context, Visit visit)
        {
            var local = _context.Set<Visit>()
                .Local
                .FirstOrDefault(v => v.Id.Equals(visit.Id));

            // check if local is not null 
            if (local != null)
            {
                // detach
                _context.Entry(local).State = EntityState.Detached;
            }
            // set Modified flag in your entry
            _context.Entry(visit).State = EntityState.Deleted;

            _context.Visits.Remove(visit);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
        #endregion

        #region Update
        public static async Task UpdateVisit(this VisitContext _context, Visit visit)
        {
            var local = _context.Set<Visit>()
            .Local
            .FirstOrDefault(v => v.Id.Equals(visit.Id));

            // check if local is not null 
            if (local != null)
            {
                // detach
                _context.Entry(local).State = EntityState.Detached;
            }
            // set Modified flag in your entry
            _context.Entry(visit).State = EntityState.Modified;

            _context.Update<Visit>(visit);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
        #endregion
    }
}
