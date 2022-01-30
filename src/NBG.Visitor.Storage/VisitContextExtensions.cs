using Microsoft.EntityFrameworkCore;
using NBG.Visitor.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NBG.Visitor.Services.DB
{
    public static class VisitContextExtensions
    {
        #region Read
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
        public static async Task<Storage.Models.Visitor> AddVisitor(this VisitContext _context, Storage.Models.Visitor visitor)
        {
            await _context.Visitors.AddAsync(visitor).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return visitor;
        }

        public static async Task<Visit> AddVisit(this VisitContext _context, Visit visit)
        {
            return (await _context.Visits.AddAsync(visit).ConfigureAwait(false)).Entity;
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
