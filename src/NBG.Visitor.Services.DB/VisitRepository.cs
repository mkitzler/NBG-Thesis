using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBG.Visitor.Storage;
using NBG.Visitor.Storage.Models;

namespace NBG.Visitor.Services.DB
{
    public class VisitRepository
    {
        private VisitContext _context = new();

        public async Task<Storage.Models.Visitor> GetVisitorIfExists(string firstName, string lastName, string phoneNumber)
        {
            return await _context.Visitors.FindAsync(firstName, lastName, phoneNumber);
        }

        /// <summary>
        /// Adds a visit entry to the Database.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="contactPersonName"></param>
        /// <param name="companyLabel"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="email"></param>
        public async Task AddVisit(DateTime start, ContactPerson contactPerson, Company company, string firstName, string lastName, string phoneNumber, string email = null)
        {
            var visitor = await GetVisitorIfExists(firstName, lastName, phoneNumber);
            if (visitor == null)
            {
                visitor = _context.Visitors.Add(new Storage.Models.Visitor() {  FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, Email = email }).Entity;
            }
            _context.Visits.Add(new Visit() { VisitStart = start, Visitor = visitor, ContactPerson = contactPerson, Company = company });
        }
    }
}
