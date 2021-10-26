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
            return await Task.Run(_context.Visitors.Where(x => x.FirstName == firstName && x.LastName == lastName && x.PhoneNumber == phoneNumber).FirstOrDefault);
        }

        public async Task AddVisitor(Storage.Models.Visitor visitor)
        {
            await _context.Visitors.AddAsync(visitor);
            await _context.SaveChangesAsync();
        }

        public async Task<ContactPerson[]> GetContactPeople()
        {
            return await Task.Run(_context.ContactPeople.ToArray);
        }

        public async Task<ContactPerson> GetContactPersonByName(string name)
        {
            return await _context.ContactPeople.FindAsync(name);
        }
        
        public async Task<Company[]> GetCompanies()
        {
            return await Task.Run(_context.Companies.ToArray);
        }

        public async Task<Company> GetCompanyByLabel(string label)
        {
            return await _context.Companies.FindAsync(label);
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
        public async Task<Visit> AddVisit(DateTime start, ContactPerson contactPerson, Company company, string firstName, string lastName, string phoneNumber, string email = null)
        {
            var visitor = await GetVisitorIfExists(firstName, lastName, phoneNumber);
            if (visitor == null)
            {
                visitor = new Storage.Models.Visitor() { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber, Email = email };
                await AddVisitor(visitor);
            }
            var visit = (await _context.Visits.AddAsync(new Visit() { VisitStart = start, Visitor = visitor, ContactPerson = contactPerson, Company = company })).Entity;
            await _context.SaveChangesAsync();
            return visit;
        }
    }
}
