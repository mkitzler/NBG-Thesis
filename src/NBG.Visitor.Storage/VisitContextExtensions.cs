using Microsoft.EntityFrameworkCore;
using NBG.Visitor.Storage.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NBG.Visitor.Services.DB
{
    public static class VisitContextExtensions
    {
        #region Read
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
            return await _context.Visits.FirstOrDefaultAsync(v => v.Id == id).ConfigureAwait(false);
        }
        public static DbSet<Visit> ReadAllVisits(this VisitContext _context)
        {
            return _context.Visits;
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

        public static async Task AddVisit(this VisitContext _context, Visit visit)
        {
            await _context.Visits.AddAsync(visit).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait (false);
        }

        public static async Task<ContactPerson> AddContactPersonIfNotExists(this VisitContext _context, string name)    //removed when ContactPerson ceases to be seperate table
        {
            return await _context.ContactPeople.FindAsync(name).ConfigureAwait(false) ?? (await _context.ContactPeople.AddAsync(new() { Name = name}).ConfigureAwait(false)).Entity;
        }

        public static async Task<Company> AddCompanyIfNotExists(this VisitContext _context, string label)    //removed when Company ceases to be seperate table
        {
            return await _context.Companies.FindAsync(label).ConfigureAwait(false) ?? (await _context.Companies.AddAsync(new() { CompanyLabel = label }).ConfigureAwait(false)).Entity;
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
            _context.Visits.Remove(visit);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
        #endregion

        #region Update
        public static async Task UpdateVisit(this VisitContext _context, Visit visit)
        {
            _context.Update(visit);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
        #endregion
    }
}
