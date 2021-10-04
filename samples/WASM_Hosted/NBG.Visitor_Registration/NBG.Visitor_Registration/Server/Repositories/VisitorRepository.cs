using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NBG.Visitor_Registration.Server.ModelContexts;
using NBG.Visitor_Registration.Shared.Models;

namespace NBG.Visitor_Registration.Server.Repositories
{
    public class VisitorRepository : IVisitorRepository 
    {
        private readonly IVisitorContext _context;
        public VisitorRepository(IVisitorContext context)
        {
            _context = context;
        }

        public async Task<Visitor> Get(int id)
        {
            return await _context.Visitors.FindAsync(id);
        }

        public async Task<IEnumerable<Visitor>> GetAll()
        {
            return await _context.Visitors.ToListAsync();
        }

        public async Task Add(Visitor visitor)
        {
            if (visitor == null)
                throw new ArgumentNullException(nameof(visitor));
            await _context.Visitors.AddAsync(visitor);
        }

        public async Task Update(int id, Visitor visitor)
        {
            var itemToUpdate = await _context.Visitors.FindAsync(id);
            if(itemToUpdate == null)
                throw new NullReferenceException();

            itemToUpdate.FirstName = visitor.FirstName;
            itemToUpdate.LastName = visitor.LastName;
            itemToUpdate.Email = visitor.Email;
            itemToUpdate.PhoneNumber = visitor.PhoneNumber;
            itemToUpdate.Company = visitor.Company;
        }

        public async Task Delete(int id)
        {
            var itemToDelete = await _context.Visitors.FindAsync(id);
            if (itemToDelete == null)
                throw new NullReferenceException();

            _context.Visitors.Remove(itemToDelete);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
